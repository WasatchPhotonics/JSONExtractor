using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace JSONExtractor
{
    public partial class Form1 : Form
    {
        IDictionary<string, object> treeRoot;   // the object structure we generated from the loaded sample JSON (displayed on widget treeViewJSON)

        BindingList<FilterAttribute> filterAttributes = new BindingList<FilterAttribute>();     // attributes we've chosen to filter
        BindingList<ExtractAttribute> extractAttributes = new BindingList<ExtractAttribute>();  // attributes we've chosen to extract
        BindingSource filterBindingSource;
        BindingSource extractBindingSource;

        List<string> inputPathnames = new();

        int filteredCount;      // how many input records failed the filter and were skipped
        int extractedCount;     // how many input records matched the filter and were extracted
        int processedCount;     // how many input records have been processed

        string s3CacheDir;      // where to locally store files downloaded from S3
        bool s3SyncRunning;     // is S3 currently syncing

        bool extractRunning;    // is an extract currently running

        Logger logger = Logger.getInstance();

        public Form1()
        {
            InitializeComponent();
            logger.setTextBox(textBoxEventLog);
            logger.level = Logger.LogLevel.DEBUG;

            filterBindingSource = new BindingSource(filterAttributes, null);
            extractBindingSource = new BindingSource(extractAttributes, null);

            dataGridViewAttributes.DataSource = extractAttributes;
            dataGridViewFilters.DataSource = filterAttributes;

            comboBoxExtractAttributeAggregateType.SelectedIndex = 0;
            comboBoxFilterType.SelectedIndex = 0;

            clearFileCounts();

            initFromSettings();

            backgroundWorkerExtraction.DoWork += BackgroundWorkerExtraction_DoWork;
            backgroundWorkerExtraction.ProgressChanged += BackgroundWorkerExtraction_ProgressChanged;
            backgroundWorkerExtraction.RunWorkerCompleted += BackgroundWorkerExtraction_RunWorkerCompleted;
        }

        void initFromSettings()
        {
            var k = Properties.Settings.Default;

            if (k.s3AccessKey is not null) textBoxS3AccessKey.Text = k.s3AccessKey;
            if (k.s3SecretKey is not null) textBoxS3SecretKey.Text = k.s3SecretKey;
            if (k.s3Bucket is not null) textBoxS3Bucket.Text = k.s3Bucket;

            if (k.s3CacheDir is not null)
            {
                s3CacheDir = k.s3CacheDir;
                toolTip1.SetToolTip(buttonS3CacheDir, s3CacheDir);
                folderBrowserDialogInputDir.SelectedPath = s3CacheDir;
            }
            else if (k.inputDir is not null)
            {
                folderBrowserDialogInputDir.SelectedPath = k.inputDir;
            }
        }

        /// <summary>
        /// The user clicked the "Load Sample" button, so let them pick a JSON
        /// file, load and it, then re-populate the "tree view" from its structure.
        /// </summary>
        /// <see cref="https://stackoverflow.com/a/31250524/6436775"/>
        private void buttonLoadSample_Click(object sender, EventArgs e)
        {
            treeRoot = null;
            treeViewJSON.Nodes.Clear();
            toolTip1.SetToolTip(buttonLoadSample, null);

            var result = openFileDialogSample.ShowDialog();
            if (result != DialogResult.OK)
                return;

            var samplePathname = openFileDialogSample.FileName;
            try
            {
                logger.info($"loading {samplePathname}");
                var jsonText = File.ReadAllText(samplePathname);
                treeRoot = JsonConvert.DeserializeObject<IDictionary<string, object>>(jsonText, new DictionaryConverter());
                toolTip1.SetToolTip(buttonLoadSample, samplePathname);
            }
            catch (Exception ex)
            {
                logger.error($"failed to load and parse {samplePathname}: {ex}");
                return;
            }

            treeViewJSON.Nodes.Add(Path.GetFileName(samplePathname));

            treeViewJSON.BeginUpdate();
            populateTreeView(treeRoot, treeViewJSON.Nodes[0]);
            treeViewJSON.EndUpdate();
        }

        // Traverse down the loaded JSON object tree starting at jsonNode, populating
        // the contents into the TreeView branch at treeNode.  
        void populateTreeView(IDictionary<string, object> jsonNode, TreeNode treeNode)
        {
            foreach (string key in jsonNode.Keys)
            {
                object value = jsonNode[key];
                if (value is IDictionary<string, object> dict)
                    populateTreeView(dict, treeNode.Nodes.Add(key));
                else if (value is List<object>)
                    treeNode.Nodes.Add(key + "[]");
                else
                    treeNode.Nodes.Add(key);
            }
        }

        /// <summary>
        /// The user clicked the button to add the selected JSON TreeView Node
        /// to the list of FilterAttributes.
        /// </summary>
        private void buttonFilterAdd_Click(object sender, EventArgs e)
        {
            var tvn = treeViewJSON.SelectedNode; // "tree view node"
            if (tvn is null)
                return;

            // validate that "pattern" is appropriate for FilterType
            string pattern = textBoxFilterPattern.Text;
            var filterType = (FilterAttribute.FilterType)Enum.Parse(typeof(FilterAttribute.FilterType), comboBoxFilterType.SelectedItem.ToString());
            switch (filterType)
            {
                case FilterAttribute.FilterType.Regex:
                    if (pattern.Length == 0)
                    {
                        logger.error("can't use a Regex FilterType without a pattern");
                        return;
                    }
                    break;
                case FilterAttribute.FilterType.Empty:
                case FilterAttribute.FilterType.NonEmpty:
                    pattern = null;
                    break;
                case FilterAttribute.FilterType.GreaterThanEqualTo:
                case FilterAttribute.FilterType.LessThanEqualTo:
                case FilterAttribute.FilterType.NumberEquals:
                    double d = 0;
                    if (!Double.TryParse(pattern, out d))
                    {
                        logger.error("cannot use pattern '{0}' with FilterType {1}",
                            pattern, filterType.ToString());
                        return;
                    }
                    break;
            }

            var fa = new FilterAttribute()
            {
                jsonFullPath = tvn.FullPath,
                filterType = filterType,
                pattern = pattern,
                negate = checkBoxFilterNegate.Checked
            };
            filterAttributes.Add(fa);
            filterBindingSource.ResetBindings(false);
        }

        private void buttonFilterRemove_Click(object sender, EventArgs e)
        {
            var tvn = treeViewJSON.SelectedNode; // "tree view node"
            if (tvn is null)
                return;

            foreach (var fa in filterAttributes)
            {
                if (fa.jsonFullPath == tvn.FullPath)
                {
                    filterAttributes.Remove(fa);
                    logger.info($"removed filter attribute {tvn.FullPath}");
                }
            }
        }

        /// <summary>
        /// Determine whether we have met the necessary preconditions to start an extract.
        /// </summary>
        void updateStartability()
        {
            buttonStart.Enabled = extractAttributes.Count > 0 && inputPathnames.Count > 0;
        }

        /// <summary>
        /// The user clicked the button to add the selected JSON TreeView Node
        /// to the list of ExtractAttributes.
        /// </summary>
        private void buttonAttrAdd_Click(object sender, EventArgs e)
        {
            var tvn = treeViewJSON.SelectedNode; // "tree view node"
            if (tvn is null)
                return;

            var defaultValue = textBoxExtractAttributeDefault.Text;
            if (defaultValue.Length == 0)
                defaultValue = null;

            var ea = new ExtractAttribute()
            {
                label = textBoxExtractAttributeLabel.Text,
                jsonFullPath = tvn.FullPath,
                defaultValue = defaultValue
            };

            if (tvn.Name.EndsWith("[]"))
                ea.aggregateType = (ExtractAttribute.AggregateType)Enum.Parse(
                    typeof(ExtractAttribute.AggregateType),
                    comboBoxExtractAttributeAggregateType.SelectedItem.ToString());

            extractAttributes.Add(ea);
            extractBindingSource.ResetBindings(false);
            updateStartability();
        }

        private void buttonExtractAttributeRemove_Click(object sender, EventArgs e)
        {
            var tvn = treeViewJSON.SelectedNode; // "tree view node"
            if (tvn is null)
                return;

            foreach (var ea in extractAttributes)
            {
                if (ea.jsonFullPath == tvn.FullPath)
                {
                    extractAttributes.Remove(ea);
                    logger.info($"Removed extract attribute {tvn.FullPath}");
                }
            }
            extractBindingSource.ResetBindings(false);
            updateStartability();
        }

        /// <summary>
        /// The user has now selected an attribute in the JSON TreeView, so
        /// update the "add filter" and "add extract" regions accordingly.
        /// </summary>
        private void treeViewJSON_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var tvn = treeViewJSON.SelectedNode;
            if (tvn is null)
            {
                buttonAddExtractAttribute.Enabled =
                buttonFilterAdd.Enabled = false;
                return;
            }
            logger.debug($"selected {tvn.FullPath}");

            buttonAddExtractAttribute.Enabled =
            buttonFilterAdd.Enabled = true;

            if (tvn.Name.EndsWith("[]"))
            {
                // this is a List attribute, so let (make) them pick an
                // aggregation method
                comboBoxExtractAttributeAggregateType.SelectedIndex = 0;
                comboBoxExtractAttributeAggregateType.Enabled = true;
            }
            else
            {
                // deselect aggregation
                comboBoxExtractAttributeAggregateType.SelectedIndex = -1;
                comboBoxExtractAttributeAggregateType.Enabled = false;
            }

            var label = tvn.Name;
            if (label.EndsWith("[]"))
                label = label.Substring(0, label.Length - 2);
            textBoxExtractAttributeLabel.Text = label;
            textBoxExtractAttributeDefault.Text = "";
        }

        void clearFileCounts()
        {
            filteredCount = 0;
            extractedCount = 0;
            processedCount = 0;

            labelSelectedCount.Text = "Selected: 0";
            labelFilteredCount.Text = "Filtered: 0";
            labelExtractedCount.Text = "Extracted: 0";
            labelProcessedCount.Text = "Processed: 0";
        }

        /// <summary>
        /// The user clicked the button to select an input directory, so let
        /// them choose the directory and then read-in the list of .json files.
        /// </summary>
        /// <todo>create a file iterator...no need to actually keep these names in memory</todo>
        private void buttonSelectInputDir_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialogInputDir.ShowDialog();
            if (result != DialogResult.OK)
                return;

            inputPathnames = new List<string>();
            inputPathnames.AddRange(Directory.GetFiles(folderBrowserDialogInputDir.SelectedPath, "*.json"));
            inputPathnames.AddRange(Directory.GetFiles(folderBrowserDialogInputDir.SelectedPath, "*.json.gz"));
            inputPathnames.Sort();
            labelSelectedCount.Text = $"Selected: {inputPathnames.Count}";
            updateStartability();
            Properties.Settings.Default.inputDir = folderBrowserDialogInputDir.SelectedPath;
        }
        
        /// <summary>
        /// Rather than select a whole directory, the user clicked the button to manually select one or more input files.
        /// </summary>
        private void buttonSelectFiles_Click(object sender, EventArgs e)
        {
            var result = openFileDialogInputFiles.ShowDialog();
            if (result != DialogResult.OK)
                return;

            inputPathnames = new List<string>();
            inputPathnames.AddRange(openFileDialogInputFiles.FileNames);
            labelSelectedCount.Text = $"Selected: {inputPathnames.Count}";
            updateStartability();
        }

        /// <summary>
        /// The user clicked the button to start an extract.
        /// </summary>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (extractRunning)
            {
                backgroundWorkerExtraction.CancelAsync();
            }
            else
            {
                buttonStart.Text = "Stop";
                extractRunning = true;
                backgroundWorkerExtraction.RunWorkerAsync();
            }
        }

        /// <summary>
        /// The user clicked the button to select a directory to where S3 blobs
        /// should be sync'd (sunk?), or alternately have already been sync'd
        /// via awscli.
        /// </summary>
        private void buttonS3CacheDir_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialogInputDir.ShowDialog();
            if (result != DialogResult.OK)
                return;

            s3CacheDir = folderBrowserDialogInputDir.SelectedPath;
        }

        private void buttonS3StartSync_Click(object sender, EventArgs e)
        {
            MessageBox.Show("S3 Sync not yet implemented");
        }


        ////////////////////////////////////////////////////////////////////////
        //                                                                    //
        //                    Background Worker Extraction                    //
        //                                                                    //
        ////////////////////////////////////////////////////////////////////////

        private void BackgroundWorkerExtraction_DoWork(object sender, DoWorkEventArgs e)
        {
            // iterate over the selected input files
            for (int i = 0; i < inputPathnames.Count; i++)
            {
                if (e.Cancel)
                {
                    logger.info("Extraction cancelled");
                    return;
                }

                var pathname = inputPathnames[i];
                logger.debug($"loading {pathname}");

                var jsonText = Util.loadText(pathname);
                var jsonObj = JsonConvert.DeserializeObject<IDictionary<string, object>>(jsonText, new DictionaryConverter());
                
                foreach (var filterAttribute in filterAttributes)
                {
                    logger.debug($"testing {filterAttribute}");
                }

                foreach (var extractAttribute in extractAttributes)
                {
                    logger.debug($"extracting {extractAttribute}");
                }
            }
            logger.info("Extraction done");
        }

        private void BackgroundWorkerExtraction_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void BackgroundWorkerExtraction_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            logger.info("Extraction completed");
        }

    }
}
