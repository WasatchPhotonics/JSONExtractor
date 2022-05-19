using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;

namespace JSONExtractor
{
    public partial class Form1 : Form
    {
        IDictionary<string, object> treeRoot;   // the object structure we generated from the loaded sample JSON (displayed on widget treeViewJSON)

        BindingList<FilterAttribute> filterAttributes = new BindingList<FilterAttribute>();     // attributes we've chosen to filter
        BindingList<ExtractAttribute> extractAttributes = new BindingList<ExtractAttribute>();  // attributes we've chosen to extract
        BindingSource filterBindingSource;
        BindingSource extractBindingSource;

        string interpolationCoefficientsJSONPath;
        string interpolationExcitationJSONPath;

        List<string> selectedPathnames = new();
        List<string> dedupedPathnames = new();

        int filteredCount;      // how many input records failed the filter and were skipped
        int extractedCount;     // how many input records matched the filter and were extracted
        int processedCount;     // how many input records have been processed
        int skipCount;          // how many input records matched the filter but had no exportable data

        string s3CacheDir;      // where to locally store files downloaded from S3
        //bool s3SyncRunning;   // is S3 currently syncing

        bool extractRunning;    // is an extract currently running
        StreamWriter outfile;   // where extracts are written

        List<double> recentCompletionTimesSec = new List<double>();
        const int COMPLETION_TIMES_WINDOW = 100;

        Logger logger = Logger.getInstance();

        ////////////////////////////////////////////////////////////////////////
        // Lifecycle
        ////////////////////////////////////////////////////////////////////////

        public Form1()
        {
            InitializeComponent();
            logger.setTextBox(textBoxEventLog);
            logger.level = Logger.LogLevel.DEBUG;

            configureSplitContainers();

            filterBindingSource = new BindingSource(filterAttributes, null);
            extractBindingSource = new BindingSource(extractAttributes, null);

            dataGridViewAttributes.DataSource = extractAttributes;
            dataGridViewFilters.DataSource = filterAttributes;

            comboBoxExtractAttributeAggregateType.SelectedIndex = 0;
            comboBoxFilterType.SelectedIndex = 0;

            clearFileCounts();

            initFromSettings();

            updateInterpolationControls();

            backgroundWorkerExtraction.DoWork += BackgroundWorkerExtraction_DoWork;
            backgroundWorkerExtraction.ProgressChanged += BackgroundWorkerExtraction_ProgressChanged;
            backgroundWorkerExtraction.RunWorkerCompleted += BackgroundWorkerExtraction_RunWorkerCompleted;
        }

        // balance GUI (Visual Studio keeps resizing things?)
        void configureSplitContainers()
        {
            //    1   2  1      4    = 8
            //  +--+----+--+--------+
            //  |A |  B |C |    D   |
            //  +--+----+--+--------+
            var w8 = (int)(Width / 8);
            splitContainerTabsVsJSONOnward.SplitterDistance = w8;               // (A, BCD)
            splitContainerJSONandButtonsVsDatagrids.SplitterDistance = w8 * 3;  // (BC, D)
            splitContainerTreeVsOpts.SplitterDistance = w8 * 2;                 // (B, C)

            // splitContainerFilterVsAttrControls.SplitterDistance = splitContainerFilterVsAttrControls.Height / 2;
            splitContainerFilterVsAttributeTables.SplitterDistance = splitContainerFilterVsAttributeTables.Height / 2;

            foreach (var splitter in new SplitContainer[] {
                    splitContainerTabsVsJSONOnward,
                    splitContainerJSONandButtonsVsDatagrids,
                    splitContainerTreeVsOpts,
                    // splitContainerFilterVsAttrControls,
                    splitContainerFilterVsAttributeTables })
            {
                splitter.IsSplitterFixed = false;
                splitter.FixedPanel = FixedPanel.None;
            }
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

        void saveSettings() => Properties.Settings.Default.Save();

        ////////////////////////////////////////////////////////////////////////
        // JSON Template
        ////////////////////////////////////////////////////////////////////////

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
                var jsonText = Util.loadText(samplePathname);
                treeRoot = JsonConvert.DeserializeObject<IDictionary<string, object>>(jsonText, new DictionaryConverter());
                toolTip1.SetToolTip(buttonLoadSample, samplePathname);
            }
            catch (Exception ex)
            {
                logger.error($"failed to load and parse {samplePathname}: {ex}");
                return;
            }

            // special case for filename-based matching (allows fast pruning of
            // input pathnames without gunzipping, loading and parsing JSON)
            treeViewJSON.Nodes.Add("filename");

            var rootNode = treeViewJSON.Nodes.Add("root");

            treeViewJSON.BeginUpdate();
            populateTreeView(treeRoot, rootNode);
            treeViewJSON.EndUpdate();

            rootNode.Expand();
        }

        // Traverse down the loaded JSON object tree starting at jsonNode, populating
        // the contents into the TreeView branch at treeNode.  
        void populateTreeView(IDictionary<string, object> jsonNode, TreeNode treeNode)
        {
            foreach (string key in jsonNode.Keys)
            {
                object value = jsonNode[key];
                if (value is IDictionary<string, object> dict)
                {
                    if (dict.Count > 0)
                    {
                        var tvn = treeNode.Nodes.Add(key);
                        tvn.ForeColor = SystemColors.GrayText;
                        populateTreeView(dict, tvn);
                    }
                    else
                        logger.debug($"ignoring empty JSON dict {key}");
                }
                else if (value is List<object>)
                {
                    var tvn = treeNode.Nodes.Add(key + "[]");
                    tvn.ForeColor = SystemColors.HotTrack;
                }
                else
                    treeNode.Nodes.Add(key);
            }
        }

        /// <summary>
        /// Automatically add double-clicked tree nodes to the extract.
        /// </summary>
        private void treeViewJSON_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node is null)
                return;
            treeViewJSON.SelectedNode = e.Node;
            buttonAttrAdd_Click(null, null);
        }

        /// <summary>
        /// The user has now selected an attribute in the JSON TreeView, so
        /// update the "add filter" and "add extract" regions accordingly.
        /// </summary>
        private void treeViewJSON_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode tvn = treeViewJSON.SelectedNode;
            if (tvn is null)
            {
                buttonAddExtractAttribute.Enabled =
                    buttonFilterAdd.Enabled = false;
                return;
            }
            logger.debug($"selected {tvn.FullPath}");

            buttonAddExtractAttribute.Enabled =
                buttonFilterAdd.Enabled = true;

            if (tvn.Text.EndsWith("[]"))
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

            var label = tvn.Text;
            if (label.EndsWith("[]"))
                label = label.Substring(0, label.Length - 2);
            textBoxExtractAttributeLabel.Text = label;
            textBoxExtractAttributeDefault.Text = "";

            updateInterpolationControls();
        }

        ////////////////////////////////////////////////////////////////////////
        // Filters
        ////////////////////////////////////////////////////////////////////////

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
            // todo: move to FilterAttribute
            string pattern = textBoxFilterPattern.Text;
            var filterType = (FilterAttribute.FilterType)Enum.Parse(
                typeof(FilterAttribute.FilterType), comboBoxFilterType.SelectedItem.ToString());
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

            var fa = new FilterAttribute(tvn.FullPath, filterType, pattern, checkBoxFilterNegate.Checked);
            filterAttributes.Add(fa);
            filterBindingSource.ResetBindings(false);
        }

        /// <summary>
        /// Determine whether we have met the necessary preconditions to start an extract.
        /// </summary>
        void updateStartability()
        {
            var haveAttr = extractAttributes.Count > 0;
            buttonStart.Enabled = haveAttr && dedupedPathnames.Count > 0;

            buttonExtractAttributeDown.Enabled =
            buttonExtractAttributeUp.Enabled = haveAttr;
        }

        ////////////////////////////////////////////////////////////////////////
        // Extract Attributes
        ////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// The user clicked the button to add the selected JSON TreeView Node
        /// to the list of ExtractAttributes.
        /// </summary>
        private void buttonAttrAdd_Click(object sender, EventArgs e)
        {
            // this is the actual attribute we're going to extract
            var ea = generateExtractAttributeFromSelectedJSONNode();

            // if interpolation is enabled, store the path to the coeffs we're to use for interpolating THIS ExtractAttribute
            if (checkBoxInterpolate.Checked)
            {
                // the new interpolated axis can be created immediately
                logger.debug("instantiating Interpolator.Axis");
                ea.interpolatedAxis = new Interpolator.Axis(
                    (int)numericUpDownInterpolationStart.Value,
                    (int)numericUpDownInterpolationEnd.Value,
                    (float)numericUpDownInterpolationIncr.Value
                );

                // the old wavelength/wavenumber axis will have to be generated per-record
                logger.debug("instantiating WavecalGenerator");
                ea.wavecalGenerator = new SpectrumUtil.WavecalGenerator(interpolationCoefficientsJSONPath, interpolationExcitationJSONPath);
            }

            logger.debug($"adding {ea}");
            extractAttributes.Add(ea);
            extractBindingSource.ResetBindings(false);
            updateStartability();
        }

        /// <summary>
        /// The user clicked "Use Coeffs", so use the currently-selected 
        /// JSON array attribute as the polynomial coefficients we will use
        /// in interpolating other aggregate data (e.g. spectra) against the
        /// generated x-axis.
        /// </summary>
        private void buttonUseCoefficients_Click(object sender, EventArgs e)
        {
            if (interpolationCoefficientsJSONPath is null)
            {
                var ea = generateExtractAttributeFromSelectedJSONNode();
                if (ea.aggregateType is null)
                {
                    logger.error("Coefficients must be an array type");
                    return;
                }

                interpolationCoefficientsJSONPath = ea.jsonFullPath;
                logger.info($"taking wavecal from {ea.jsonFullPath}");
            }
            else
            {
                interpolationCoefficientsJSONPath = null;
                buttonUseCoefficients.Text = "Set Wavecal";
            }
            updateInterpolationControls();
        }

        /// <todo>
        /// - update ToolTip to show on disabled controls
        /// </todo>
        void updateInterpolationControls()
        {
            // checkBoxInterpolate
            if (interpolationCoefficientsJSONPath != null)
            {
                checkBoxInterpolate.Enabled = true;
                toolTip1.SetToolTip(checkBoxInterpolate, "Interpolation is available because a wavecal was selected");
            }
            else
            {
                checkBoxInterpolate.Checked = 
                    checkBoxInterpolate.Enabled = false;
                toolTip1.SetToolTip(checkBoxInterpolate, "Interpolation requires a wavecal");
            }

            // buttonUseCoefficients
            if (interpolationCoefficientsJSONPath == null)
            {
                buttonUseCoefficients.Text = "Set Wavecal";
                buttonExcitation.Enabled = false;

                if (isArrayNodeSelected())
                {
                    buttonUseCoefficients.Enabled = true;
                    toolTip1.SetToolTip(buttonUseCoefficients, "Select a JSON element providing wavecal coefficients to enable interpolation (wavelength or wavenumber depending whether excitation is also provided)");
                }
                else
                {
                    buttonUseCoefficients.Enabled = false;
                    toolTip1.SetToolTip(buttonUseCoefficients, "Wavecal requires an array element");
                }
            }
            else
            {
                buttonUseCoefficients.Text = "Clear Wavecal";
                toolTip1.SetToolTip(buttonUseCoefficients, "Clearing wavecal will disable interpolation");
                buttonExcitation.Enabled = true;
            }

            // buttonExcitation
            if (interpolationExcitationJSONPath is null)
            {
                toolTip1.SetToolTip(buttonExcitation, "Select a JSON element providing laser excitation to interpolate data against a wavenumber axis");
                buttonExcitation.Text = "Set Excitation";
            }
            else
            {
                buttonExcitation.Text = "Clear Excitation";
                toolTip1.SetToolTip(buttonExcitation, "Clearing excitation will cause interpolated x-axis to use wavelength space");
            }
        }

        private void buttonExcitation_Click(object sender, EventArgs e)
        {
            if (interpolationExcitationJSONPath is null)
            {
                var ea = generateExtractAttributeFromSelectedJSONNode();
                interpolationExcitationJSONPath = ea.jsonFullPath;
                logger.info($"taking excitation wavelength from {ea.jsonFullPath}");
            }
            else
            {
                interpolationExcitationJSONPath = null;
            }
            updateInterpolationControls();
        }

        bool isArrayNodeSelected()
        {
            var tvn = treeViewJSON.SelectedNode; 
            return (tvn != null && tvn.Text.EndsWith("[]"));
        }

        ExtractAttribute generateExtractAttributeFromSelectedJSONNode()
        {
            var tvn = treeViewJSON.SelectedNode; // "tree view node"
            if (tvn is null)
                return null;

            if (tvn.Nodes.Count > 0)
            {
                logger.error("adding dict nodes to report is not currently supported");
                return null;
            }

            var defaultValue = textBoxExtractAttributeDefault.Text;
            if (defaultValue.Length == 0)
                defaultValue = null;

            var ea = new ExtractAttribute()
            {
                label = textBoxExtractAttributeLabel.Text,
                jsonFullPath = tvn.FullPath,
                defaultValue = defaultValue,
                precision = (int)numericUpDownExtractAttributePrecision.Value
            };

            if (tvn.Text.EndsWith("[]"))
                ea.aggregateType = (ExtractAttribute.AggregateType)Enum.Parse(
                    typeof(ExtractAttribute.AggregateType),
                    comboBoxExtractAttributeAggregateType.SelectedItem.ToString());

            return ea;
        }

        private void dataGridViewAttributes_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            updateStartability();
        }

        private void buttonExtractAttributeUp_Click(object sender, EventArgs e)
        {
            var row = dataGridViewAttributes.CurrentCell.RowIndex;
            if (row < 1)
                return;
            var ea = extractAttributes[row];
            extractAttributes.RemoveAt(row);
            extractAttributes.Insert(row - 1, ea);
            // dataGridViewAttributes.Rows[row - 1].Selected = true;
        }

        private void buttonExtractAttributeDown_Click(object sender, EventArgs e)
        {
            var row = dataGridViewAttributes.CurrentCell.RowIndex;
            if (row + 1 >= extractAttributes.Count)
                return;
            var ea = extractAttributes[row];
            extractAttributes.RemoveAt(row);
            extractAttributes.Insert(row + 1, ea);
            // dataGridViewAttributes.Rows[row + 1].Selected = true;
        }

        ////////////////////////////////////////////////////////////////////////
        // Select Input Files
        ////////////////////////////////////////////////////////////////////////

        void clearFileCounts()
        {
            filteredCount = 0;
            extractedCount = 0;
            processedCount = 0;
            skipCount = 0;

            foreach (var fa in filterAttributes)
                fa.rejectCount = 0;

            progressBarStatus.Maximum = dedupedPathnames.Count;
            progressBarStatus.Value = 0;

            updateFileCounts();
        }

        void updateFileCounts()
        {
            labelSelectedCount.Text = $"Selected: {selectedPathnames.Count}";
            labelDedupedCount.Text = $"Deduped: {dedupedPathnames.Count}";
            labelFilteredCount.Text = $"Filtered: {filteredCount}";
            labelExtractedCount.Text = $"Extracted: {extractedCount}";
            labelProcessedCount.Text = $"Processed: {processedCount}";
            labelSkippedCount.Text = $"Skipped: {skipCount}";

            progressBarStatus.Value = processedCount;

            string tt = "unknown time remaining";
            if (recentCompletionTimesSec.Count > 0)
            {
                var secPerRec = recentCompletionTimesSec.Average();
                var secRemaining = (dedupedPathnames.Count - processedCount) * secPerRec;
                tt = Util.timeRemainingLabel(secRemaining);
            }
            toolTip1.SetToolTip(progressBarStatus, tt);
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

            Properties.Settings.Default.inputDir = folderBrowserDialogInputDir.SelectedPath;
            saveSettings();

            selectedPathnames = new List<string>();
            selectedPathnames.AddRange(Directory.GetFiles(folderBrowserDialogInputDir.SelectedPath, "*.json"));
            selectedPathnames.AddRange(Directory.GetFiles(folderBrowserDialogInputDir.SelectedPath, "*.json.gz"));

            dedupeInputPathnames();
        }

        /// <summary>
        /// Rather than select a whole directory, the user clicked the button to manually select one or more input files.
        /// </summary>
        private void buttonSelectFiles_Click(object sender, EventArgs e)
        {
            var result = openFileDialogInputFiles.ShowDialog();
            if (result != DialogResult.OK)
                return;

            selectedPathnames = new List<string>();
            selectedPathnames.AddRange(openFileDialogInputFiles.FileNames);

            dedupeInputPathnames();
        }

        /// <summary>
        /// This performs BOTH de-duping of "unique" filename tokens (like serial
        /// number), to ensure that only the last record of a given token is 
        /// processed, AND checking the "Within" clause using the same token.
        /// </summary>
        void dedupeInputPathnames()
        {
            selectedPathnames.Sort();
            labelSelectedCount.Text = $"Selected: {selectedPathnames.Count}";

            if (checkBoxDedupeFilenames.Checked)
            {
                ////////////////////////////////////////////////////////////////
                // parse Within list (on comma if found, else whitespace)
                ////////////////////////////////////////////////////////////////

                HashSet<string> withinSet = new();
                string withinStr = textBoxDedupeWithin.Text.Trim().ToLower();
                if (withinStr.Length > 0)
                {
                    List<string> tok = new();
                    if (withinStr.Contains(','))
                    {
                        foreach (var s in withinStr.Split(","))
                            if (s.Trim().Length > 0)
                                withinSet.Add(s.Trim());
                    }
                    else
                    {
                        foreach (var s in withinStr.Split())
                            if (s.Trim().Length > 0)
                                withinSet.Add(s.Trim());
                    }
                    logger.debug($"applying withinSet: {string.Join(", ", withinSet)}");
                }

                ////////////////////////////////////////////////////////////////
                // Dedupe on unique token
                ////////////////////////////////////////////////////////////////

                var re = new Regex(textBoxDedupeFilenames.Text, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                Dictionary<string, string> latestUnique = new Dictionary<string, string>();
                foreach (var pathname in selectedPathnames)
                {
                    var basename = Path.GetFileName(pathname).Split(".").First();
                    var match = re.Match(basename);
                    if (match.Success && match.Groups.Count > 1)
                    {
                        var unique = match.Groups[1].Value;

                        // if we defined a Within list, then first ensure this is
                        // a valid element
                        if (withinSet.Count > 0)
                            if (!withinSet.Contains(unique.ToLower()))
                                continue;
                        
                        latestUnique[unique] = pathname;
                    }
                    else
                    {
                        if (withinSet.Count == 0)
                        {
                            // we didn't match the pattern, so just store the
                            // pathname directly (do this if we're "just"
                            // dedupping...if a "Within" list was specified, this
                            // is a fail)
                            latestUnique[basename] = pathname;
                        }
                    }
                }
                dedupedPathnames = new();
                foreach (var pair in latestUnique)
                    dedupedPathnames.Add(pair.Value);
                dedupedPathnames.Sort();
            }

            labelDedupedCount.Text = $"Deduped: {dedupedPathnames.Count}";
            updateStartability();
        }

        ////////////////////////////////////////////////////////////////////////
        // Running an Extract
        ////////////////////////////////////////////////////////////////////////

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
                DialogResult result = saveFileDialogExtract.ShowDialog();
                if (result != DialogResult.OK)
                    return;

                var pathname = saveFileDialogExtract.FileName;
                logger.info($"generating extract to {pathname}");
                outfile = new StreamWriter(pathname);
                outfile.AutoFlush = true;

                buttonStart.Text = "Stop";
                extractRunning = true;

                clearFileCounts();

                backgroundWorkerExtraction.RunWorkerAsync();
            }
        }

        ////////////////////////////////////////////////////////////////////////
        // Saved Configurations
        ////////////////////////////////////////////////////////////////////////

        private void buttonSaveConfig_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Save Config not yet implemented");
        }

        private void buttonLoadConfig_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Load Config not yet implemented");
        }

        ////////////////////////////////////////////////////////////////////////
        // AWS S3
        ////////////////////////////////////////////////////////////////////////

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
            Properties.Settings.Default.s3CacheDir = s3CacheDir;
            saveSettings();
        }

        private void buttonS3StartSync_Click(object sender, EventArgs e)
        {
            MessageBox.Show("S3 Sync not yet implemented");
        }

        private void textBoxS3Bucket_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.s3Bucket = textBoxS3Bucket.Text;
            saveSettings();
        }

        private void textBoxS3AccessKey_TextChanged(object sender, EventArgs e) 
        {
            Properties.Settings.Default.s3AccessKey = textBoxS3AccessKey.Text;
            saveSettings();
        }

        private void textBoxS3SecretKey_TextChanged(object sender, EventArgs e) 
        {
            Properties.Settings.Default.s3SecretKey = textBoxS3SecretKey.Text;
            saveSettings();
        }

        ////////////////////////////////////////////////////////////////////////
        //                                                                    //
        //                    Background Worker Extraction                    //
        //                                                                    //
        ////////////////////////////////////////////////////////////////////////

        /// <returns>
        /// Tuple of (passed, sufficient) where "passed" indicates "this" filter,
        /// and "sufficient" means "the overall filter set passes regardless of 
        /// other filters.
        /// </returns>
        bool filterPasses(FilterAttribute fa, object value)
        {
            if (value is null)
                return fa.nullOk;

            var valueStr = value.ToString();
            bool passed = fa.passesFilter(valueStr);
            // logger.debug($"filter({fa}, {valueStr}) -> {passed}");
            return passed;
        }

        void updateFileCountsDelegate() => labelExtractedCount.BeginInvoke(new MethodInvoker(delegate { updateFileCounts(); }));

        private void BackgroundWorkerExtraction_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;

            // header rows
            List<string> headersLong = new List<string>();
            List<string> headersShort = new List<string>();
            foreach (var ea in extractAttributes)
            {
                if (!ea.isTable())
                {
                    string full = ea.jsonFullPath;
                    if (full.StartsWith("root\\"))
                        full = full.Substring(5);

                    headersLong.Add(full == ea.label ? "" : full);
                    headersShort.Add(ea.label);
                }
            }
            outfile.WriteLine("," + string.Join(',', headersLong));
            outfile.WriteLine("," + string.Join(',', headersShort));

            processedCount = 0;

            // group filters by type
            List<FilterAttribute> filenameFilters = new List<FilterAttribute>();
            List<FilterAttribute> jsonFilters = new List<FilterAttribute>();
            foreach (var fa in filterAttributes)
                if (fa.isFilenameFilter)
                    filenameFilters.Add(fa);
                else
                    jsonFilters.Add(fa);

            DateTime lastStart = DateTime.Now;

            // iterate over the deduped input files
            for (int i = 0; i < dedupedPathnames.Count; i++)
            {
                if (worker.CancellationPending)
                {
                    logger.info("Extraction cancelled");
                    e.Cancel = true;
                    break;
                }

                // track recent processing times for progressBar
                if (i > 0)
                {
                    var elapsedSec = (DateTime.Now - lastStart).TotalSeconds;
                    while (recentCompletionTimesSec.Count >= COMPLETION_TIMES_WINDOW)
                        recentCompletionTimesSec.RemoveAt(0);
                    recentCompletionTimesSec.Add(elapsedSec);
                }
                lastStart = DateTime.Now;

                var pathname = dedupedPathnames[i];
                processedCount++;

                ////////////////////////////////////////////////////////////////
                // test filename
                ////////////////////////////////////////////////////////////////

                bool passedAll = true;
                bool sufficient = false;
                foreach (var fa in filenameFilters)
                {
                    var value = Path.GetFileName(pathname).Split(".").First();
                    var passed = filterPasses(fa, value);
                    if (!passed)
                        passedAll = false;
                    if (passed && fa.sufficient)
                        sufficient = true;
                }

                bool shouldLoad = passedAll || sufficient;
                if (!shouldLoad)
                { 
                    // for speed, don't log or update the GUI on these
                    skipCount++;
                    continue;
                }

                ////////////////////////////////////////////////////////////////
                // test record
                ////////////////////////////////////////////////////////////////

                logger.debug($"loading {pathname}");

                // Given "C:\Users\mzieg\Documents\foo.json.gz", extracts "foo".
                // We need this for labeling records in tables.
                var recordKey = pathname.Split("\\").Last().Split(".").First();

                var jsonText = Util.loadText(pathname);
                var jsonObj = JsonConvert.DeserializeObject<IDictionary<string, object>>(jsonText, new DictionaryConverter());

                passedAll = true;
                sufficient = false;
                foreach (var fa in jsonFilters)
                {
                    var value = Util.getJsonValue(jsonObj, fa.jsonFullPath);
                    var passed = filterPasses(fa, value);
                    if (!passed)
                        passedAll = false;
                    if (passed && fa.sufficient)
                        sufficient = true;
                }

                bool shouldExport = passedAll || sufficient;
                if (!shouldExport)
                {
                    // logger.debug($"filtering {pathname}");
                    filteredCount++;
                    updateFileCountsDelegate();
                    continue;
                }

                ////////////////////////////////////////////////////////////////
                // extract fields
                ////////////////////////////////////////////////////////////////

                // filters passed, so extract new record
                List<string> values = new List<string>();

                // just do this automatically
                values.Add(recordKey);  

                bool hasData = false;
                foreach (var ea in extractAttributes)
                {
                    var value = Util.getJsonValue(jsonObj, ea.jsonFullPath, ea.defaultValue);
                    if (value != null)
                        hasData = true;

                    // pass jsonObj so the ExtractAttribute can find its
                    // coefficients if interpolation is called for
                    if (ea.isTable())
                        ea.storeTable(value, recordKey, jsonObj);
                    else
                        values.Add(ea.formatValue(value));
                }

                if (!hasData)
                {
                    logger.debug($"skipping {pathname} (filters passed but no data to extract)");
                    skipCount++;
                    updateFileCountsDelegate();
                    continue;
                }

                ////////////////////////////////////////////////////////////////
                // export record
                ////////////////////////////////////////////////////////////////

                outfile.WriteLine(string.Join(',', values));
                extractedCount++;
                updateFileCountsDelegate();
            }

            // if this extract had any tabular attributes, append them at the bottom
            foreach (var ea in extractAttributes)
            {
                if (ea.isTable())
                {
                    outfile.WriteLine();
                    outfile.WriteLine($"[{ea.jsonFullPath}]");
                    outfile.WriteLine(ea.formatTable());
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
            outfile.Close();
            buttonStart.Text = "Start";
            extractRunning = false;
            progressBarStatus.Value = 0;
        }

        private void dataGridViewAttributes_SelectionChanged(object sender, EventArgs e)
        {
            var rows = dataGridViewAttributes.SelectedRows;
            if (rows.Count == 0)
            {
                logger.debug($"no rows selected");
            }
            else
            {
                logger.debug($"Attribute rows selected: {rows}");
            }
        }
    }
}
