using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading.Tasks;

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

        bool extractRunning;    // is an extract currently running
        StreamWriter outfile;   // where extracts are written

        List<double> recentCompletionTimesSec = new List<double>();
        const int COMPLETION_TIMES_WINDOW = 100;

        TreeNode collect2DPivotNode = null;
        List<string> collect2DRelativePath = null;
        bool collect2DLoL;

        Cloud cloud;

        Chart previewChart = new Chart();
        string previewNodePath = "";
        object previewMut = new object();

        Chart extractChart = new Chart();
        List<ExtractAttribute> chartAttributes = new();

        Logger logger = Logger.getInstance();

        ////////////////////////////////////////////////////////////////////////
        //                                                                    //
        //                             Lifecycle                              //
        //                                                                    //
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

            comboBoxCollect1D.SelectedIndex = 0;
            comboBoxFilterType.SelectedIndex = 0;

            clearFileCounts();

            initFromSettings();

            updateInterpolationControls();
            updateCollect2D(null);

            backgroundWorkerExtraction.DoWork += BackgroundWorkerExtraction_DoWork;
            backgroundWorkerExtraction.ProgressChanged += BackgroundWorkerExtraction_ProgressChanged;
            backgroundWorkerExtraction.RunWorkerCompleted += BackgroundWorkerExtraction_RunWorkerCompleted;

            initPreviewChart();
            initExtractChart();

            cloud = new Cloud(buttonS3StartSync, progressBarStatus, toolTip1);

            labelSelectedName.Text =
                labelSelectedType.Text = "";
            updateExplanation();

            Task.Delay(1000).ContinueWith(t => this.BeginInvoke(new MethodInvoker(delegate { postConstruction(); })));

            logger.initializationComplete = true;
        }

        // do these after the constructor, so the form is fully visible and you can see the log messages
        void postConstruction()
        {
            loadPathnamesFromInputDir();
            loadSampleJsonFile();
        }

        // Balance GUI (Visual Studio keeps resizing things?).
        // Even with this, I still can't resize the splitContainers at runtime...
        // no idea why :-(
        void configureSplitContainers()
        {
            //    1   2  1      4    = 8
            //  +--+----+--+--------+
            //  |A |  B |C |    D   |
            //  +--+----+--+--------+
            var w8 = (int)(Width / 8);
            splitContainerTabsVsJSONOnward.SplitterDistance = (int)(w8 * 1.1);  // (A, BCD)
            splitContainerTabsVsJSONOnward.FixedPanel = FixedPanel.Panel1;
            splitContainerJSONandButtonsVsDatagrids.SplitterDistance = w8 * 3;  // (BC, D)
            splitContainerTreeVsOpts.SplitterDistance = (int)(w8 * 1.8);        // (B, C)
            splitContainerTreeVsOpts.FixedPanel = FixedPanel.Panel2;

            splitContainerFilterVsAttributeTables.SplitterDistance = splitContainerFilterVsAttributeTables.Height / 2;

            foreach (var splitter in new SplitContainer[] {
                    // splitContainerTabsVsJSONOnward,
                    splitContainerJSONandButtonsVsDatagrids,
                    // splitContainerTreeVsOpts,
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
            if (k.inputDir is not null) folderBrowserDialogInputDir.SelectedPath = k.inputDir;
            if (k.dedupeRegex is not null && k.dedupeRegex.Length > 0) textBoxDedupeRegex.Text = k.dedupeRegex;
            if (k.dedupeWithin is not null) textBoxDedupeWithin.Text = k.dedupeWithin;

            if (k.s3CacheDir is not null)
            {
                s3CacheDir = k.s3CacheDir;
                folderBrowserDialogInputDir.SelectedPath = s3CacheDir;
                toolTip1.SetToolTip(buttonS3CacheDir, s3CacheDir);
            }
        }

        ////////////////////////////////////////////////////////////////////////
        //                                                                    //
        //                              AWS S3                                //
        //                                                                    //
        ////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// The user clicked the button to select a directory to where S3 blobs
        /// should be sync'd (sunk?), or alternately have already been sync'd
        /// via awscli.
        /// </summary>
        void buttonS3CacheDir_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialogInputDir.ShowDialog();
            if (result != DialogResult.OK)
                return;

            s3CacheDir = folderBrowserDialogInputDir.SelectedPath;
            toolTip1.SetToolTip(buttonS3CacheDir, s3CacheDir);
            Properties.Settings.Default.s3CacheDir = s3CacheDir;
            saveSettings();
        }

        /// <todo>add "time remaining" indicator</todo>
        void buttonS3StartSync_Click(object sender, EventArgs e)
        {
            if (s3CacheDir is null || !Directory.Exists(s3CacheDir))
            {
                logger.error("must select S3 cache folder first");
                return;
            }

            if (cloud.running)
            {
                logger.info("cancelling sync");
                cloud.stop();
            }
            else
            {
                logger.info("starting sync");
                buttonS3StartSync.Text = "Pause Sync";
                cloud.start(textBoxS3AccessKey.Text, textBoxS3SecretKey.Text, textBoxS3Bucket.Text, s3CacheDir);
            }
        }

        void textBoxS3Bucket_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.s3Bucket = textBoxS3Bucket.Text;
            saveSettings();
        }

        void textBoxS3AccessKey_TextChanged(object sender, EventArgs e) 
        {
            Properties.Settings.Default.s3AccessKey = textBoxS3AccessKey.Text;
            saveSettings();
        }

        void textBoxS3SecretKey_TextChanged(object sender, EventArgs e) 
        {
            Properties.Settings.Default.s3SecretKey = textBoxS3SecretKey.Text;
            saveSettings();
        }

        void saveSettings() => Properties.Settings.Default.Save();

        ////////////////////////////////////////////////////////////////////////
        //                                                                    //
        //                         Saved Configurations                       //
        //                                                                    //
        ////////////////////////////////////////////////////////////////////////

        void buttonSaveConfig_Click(object sender, EventArgs e)
        {
            DialogResult ok = saveFileDialogConfig.ShowDialog();
            if (ok != DialogResult.OK)
                return;

            Config config = new Config();
            foreach (var ea in extractAttributes)
                config.extractAttributes.Add(ExtractAttribute.Serialized.serialize(ea));
            foreach (var fa in filterAttributes)
                config.filterAttributes.Add(FilterAttribute.Serialized.serialize(fa));

            using StreamWriter configFile = new(saveFileDialogConfig.FileName);
                configFile.WriteLine(JsonConvert.SerializeObject(config, Formatting.Indented));

            logger.info($"saved config to {saveFileDialogConfig.FileName}");
        }

        void buttonLoadConfig_Click(object sender, EventArgs e)
        {
            DialogResult ok = openFileDialogConfig.ShowDialog();
            if (ok != DialogResult.OK)
                return;

            string json = Util.loadText(openFileDialogConfig.FileName);
            Config config = JsonConvert.DeserializeObject<Config>(json);

            filterAttributes.Clear();
            extractAttributes.Clear();

            foreach (var fas in config.filterAttributes)
                filterAttributes.Add(fas.deserialize());
            foreach (var eas in config.extractAttributes)
            {
                var ea = eas.deserialize();
                extractAttributes.Add(ea);
            }

            filterBindingSource.ResetBindings(false);
            extractBindingSource.ResetBindings(false);
            updateStartability();
        }

        ////////////////////////////////////////////////////////////////////////
        //                                                                    //
        //                       Select Input Files                           //
        //                                                                    //
        ////////////////////////////////////////////////////////////////////////

        void clearFileCounts()
        {
            filteredCount = 0;
            extractedCount = 0;
            processedCount = 0;
            skipCount = 0;

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
        void buttonSelectInputDir_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialogInputDir.ShowDialog();
            if (result != DialogResult.OK)
                return;

            Properties.Settings.Default.inputDir = folderBrowserDialogInputDir.SelectedPath;
            saveSettings();

            loadPathnamesFromInputDir();
        }

        /// <summary>
        /// Rather than select a whole directory, the user clicked the button to manually select one or more input files.
        /// </summary>
        void buttonSelectFiles_Click(object sender, EventArgs e)
        {
            var result = openFileDialogInputFiles.ShowDialog();
            if (result != DialogResult.OK)
                return;

            selectedPathnames = new List<string>();
            selectedPathnames.AddRange(openFileDialogInputFiles.FileNames);

            dedupeInputPathnames();
        }

        void loadPathnamesFromInputDir()
        {
            selectedPathnames = new List<string>();

            var inputDir = Properties.Settings.Default.inputDir;
            if (!Directory.Exists(inputDir))
                return;

            logger.info($"loading JSON filenames from {inputDir}");
            selectedPathnames.AddRange(Directory.GetFiles(inputDir, "*.json"));
            selectedPathnames.AddRange(Directory.GetFiles(inputDir, "*.json.gz"));

            dedupeInputPathnames();
        }

        private void textBoxDedupeWithin_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.dedupeWithin = textBoxDedupeWithin.Text;
            saveSettings();

            dedupeInputPathnames();
        }

        private void textBoxDedupeRegex_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.dedupeRegex = textBoxDedupeRegex.Text;
            saveSettings();

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
            dedupedPathnames = selectedPathnames;

            if (checkBoxDedupeFilenames.Checked)
            {
                // parse Within list (on comma if found, else whitespace)
                HashSet<string> withinSet = new();
                string withinStr = Properties.Settings.Default.dedupeWithin.Trim().ToLower();
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
                }

                // Dedupe on unique token
                Regex re = null;
                try
                {
                    re = new Regex(textBoxDedupeRegex.Text, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                }
                catch(Exception)
                {
                    logger.error($"invalid regex: {textBoxDedupeRegex.Text}");
                }

                if (re != null)
                {
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

                                // latestUnique[basename] = pathname;
                            }
                        }
                    }

                    dedupedPathnames = new();
                    foreach (var pair in latestUnique)
                        dedupedPathnames.Add(pair.Value);
                    dedupedPathnames.Sort();
                }
            }

            logger.info($"deduped {dedupedPathnames.Count} filenames out of {selectedPathnames.Count}");
            labelDedupedCount.Text = $"Deduped: {dedupedPathnames.Count}";

            updateStartability();
        }

        void checkBoxDedupeFilenames_CheckedChanged(object sender, EventArgs e) => dedupeInputPathnames();

        ////////////////////////////////////////////////////////////////////////
        //                                                                    //
        //                         Load JSON Template                         //
        //                                                                    //
        ////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// The user clicked the "Load Sample" button, so let them pick a JSON
        /// file, load and it, then re-populate the "tree view" from its structure.
        /// </summary>
        /// <see cref="https://stackoverflow.com/a/31250524/6436775"/>
        void buttonLoadSample_Click(object sender, EventArgs e)
        {
            var result = openFileDialogSample.ShowDialog();
            if (result != DialogResult.OK)
                return;

            Properties.Settings.Default.sampleJsonFile = openFileDialogSample.FileName;
            saveSettings();

            loadSampleJsonFile();
        }

        void loadSampleJsonFile()
        { 
            treeRoot = null;
            treeViewJSON.Nodes.Clear();
            toolTip1.SetToolTip(buttonLoadSample, "load JSON file to use as schema template");

            var samplePathname = Properties.Settings.Default.sampleJsonFile;
            if (!File.Exists(samplePathname))
                return;

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
            treeViewJSON.ShowNodeToolTips = true;

            rootNode.Expand();
        }

        /// <summary>
        /// Traverse down the loaded JSON object tree starting at jsonNode, populating
        /// the contents into the TreeView branch at treeNode.  
        /// </summary>
        /// <param name="jsonNode">the current node in the loaded sample JSON template</param>
        /// <param name="treeNode">the current node in the TreeView we're populating from the sample JSON template</param>
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
                    {
                        // logger.debug($"ignoring empty JSON dict {key}");
                    }
                }
                else if (value is List<object>)
                {
                    // array leaf node
                    var tvn = treeNode.Nodes.Add(key + "[]");
                    tvn.ForeColor = SystemColors.HotTrack;
                    var typeName = Util.getJsonType(treeRoot, tvn.FullPath);
                    var tt = typeName.StartsWith("List<List<") ? typeName : Util.getJsonValueShortString(treeRoot, tvn.FullPath);
                    tvn.ToolTipText = tt;
                }
                else
                {
                    // scalar leaf node
                    var tvn = treeNode.Nodes.Add(key);
                    var tt = Util.getJsonValueShortString(treeRoot, tvn.FullPath).ToString();
                    tvn.ToolTipText = tt;
                }
            }
        }

        /// <summary>
        /// Automatically add double-clicked tree nodes to the extract.
        /// </summary>
        void treeViewJSON_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
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
        void treeViewJSON_AfterSelect(object sender, TreeViewEventArgs e)
        {
            labelSelectedName.Text = "";
            labelSelectedType.Text = "";

            TreeNode tvn = treeViewJSON.SelectedNode;
            if (tvn is null)
            {
                buttonAddExtractAttribute.Enabled =
                    buttonFilterAdd.Enabled = false;
                updateExplanation();
                return;
            }

            buttonAddExtractAttribute.Enabled =
                buttonFilterAdd.Enabled = true;

            if (tvn.Text.EndsWith("[]"))
            {
                // this is a List attribute, so let (make) them pick a Collect1D
                // method
                comboBoxCollect1D.SelectedIndex = 0;
                comboBoxCollect1D.Enabled = true;
            }
            else
            {
                // deselect 1D collection
                comboBoxCollect1D.SelectedIndex = -1;
                comboBoxCollect1D.Enabled = false;
            }

            var label = tvn.Text;

            labelSelectedName.Text = label;
            labelSelectedType.Text = Util.getJsonType(treeRoot, tvn.FullPath);

            if (label.EndsWith("[]"))
                label = label.Substring(0, label.Length - 2);
            textBoxExtractAttributeLabel.Text = label;
            textBoxExtractAttributeDefault.Text = "";

            updateInterpolationControls();
            updateCollect2D(tvn);
        }

        ////////////////////////////////////////////////////////////////////////
        //                                                                    //
        //                           Preview Chart                            //
        //                                                                    //
        ////////////////////////////////////////////////////////////////////////

        void initPreviewChart()
        {
            this.Controls.Add(previewChart);

            // preview.Width = this.Width / 3;
            // preview.Height = this.Height / 3;
            previewChart.BorderlineWidth = 1;
            previewChart.BorderlineColor = Color.Gray;
            previewChart.IsSoftShadows = true;
            previewChart.BringToFront();
            previewChart.BorderlineDashStyle = ChartDashStyle.Solid;

            ChartArea area = new();
            area.BorderWidth = 1;
            area.BorderColor = Color.Gray;
            area.BorderDashStyle = ChartDashStyle.Solid;
            area.ShadowOffset = 5;
            previewChart.ChartAreas.Add(area);

            previewChart.Visible = false;
        }

        void treeViewJSON_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            var tvn = e.Node;
            if (!checkBoxPreview.Checked)
            {
                previewChart.Visible = false;
                return;
            }

            bool isLoL = Util.isLoL(treeRoot, tvn.FullPath);
            bool isLoD = Util.isLoD(treeRoot, tvn.FullPath);
            if (!isLoL && !isLoD)
            {
                previewChart.Visible = false;
                return;
            }

            lock (previewMut)
            {
                if (previewNodePath == tvn.FullPath)
                    return;
                previewNodePath = tvn.FullPath;
            }

            var relPos = PointToClient(MousePosition);
            previewChart.Location = new Point(x: relPos.X + 150, y: relPos.Y + 50);
            previewChart.Width = Width / 3;
            previewChart.Height = Height / 3;
            previewChart.Visible = true;
            previewChart.Series.Clear();

            if (isLoL)
            {
                var data = Util.toLoL(treeRoot, tvn.FullPath);
                foreach (var array in data)
                {
                    var s = newPreviewSeries(mono: false);
                    for (int i = 0; i < array.Count; i++)
                        s.Points.AddXY(i, array[i]);
                }
            }
            else
            {
                var s = newPreviewSeries();
                List<double> values = Util.toLoD(treeRoot, tvn.FullPath);
                if (values != null)
                    for (int i = 0; i < values.Count; i++)
                        s.Points.AddXY(i, values[i]);
            }
        }

        Series newPreviewSeries(bool mono=true)
        {
            Series s = new Series();
            s.ChartType = SeriesChartType.Line;
            if (mono)
                s.Color = Color.Blue;
            previewChart.Series.Add(s);
            return s;
        }

        void treeViewJSON_MouseLeave(object sender, EventArgs e) => hidePreview();

        void hidePreview()
        {
            previewChart.Visible = false;
            previewNodePath = "";
        }

        ////////////////////////////////////////////////////////////////////////
        //                                                                    //
        //                           Extract Filters                          //
        //                                                                    //
        ////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// The user clicked the button to add the selected JSON TreeView Node
        /// to the list of FilterAttributes.
        /// </summary>
        void buttonFilterAdd_Click(object sender, EventArgs e)
        {
            var tvn = treeViewJSON.SelectedNode; // "tree view node"
            if (tvn is null)
                return;

            // validate that "pattern" is appropriate for FilterType
            // todo: move to FilterAttribute
            string pattern = textBoxFilterPattern.Text;
            var filterType = (FilterAttribute.FilterType)Enum.Parse(
                typeof(FilterAttribute.FilterType), comboBoxFilterType.Text);
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

        ////////////////////////////////////////////////////////////////////////
        //                                                                    //
        //                        Extract Attributes                          //
        //                                                                    //
        ////////////////////////////////////////////////////////////////////////

        void updateExplanation()
        {
            string name = labelSelectedName.Text;
            string collect1D = comboBoxCollect1D.Text;
            string collect2D = comboBoxCollect2D.Text;
            string s = "No attribute has been selected.";

            if (name != "")
            {
                s = $"The attribute '{name}', a {labelSelectedType.Text}, will be extracted to the report. ";

                if (!name.EndsWith("[]"))
                    s += $"Since {name} is a scalar type (not a list or array), no additional aggregation options are available (Collect1D or Collect2D), nor is interpolation possible. Graphing is also currently disabled for scalars. ";
                else
                {
                    s += $"\n\n{name} is an array attribute, so interpolation, graphing and aggregation are possible. ";
                    if (checkBoxInterpolate.Checked)
                    {
                        s += $"Since Interpolate is checked, the values will be interpolated against an x-axis ";
                        if (interpolationExcitationJSONPath is null)
                            s += $"in wavelengths (nm) generated from each record's coefficients found in {interpolationCoefficientsJSONPath}. ";
                        else
                            s += $"generated from each record's wavelength coefficients found in {interpolationCoefficientsJSONPath} " +
                                 $"and then converted to Raman shift (wavenumbers in 1/cm) from the excitation wavelength " +
                                 $"found in the record's {interpolationExcitationJSONPath} attribute. ";
                    }
                    else
                        s += "Because Interpolate is not checked, the values will be graphed against an ordinal x-axis (1, 2, 3, etc), AKA 'pixel space'. ";

                    if (collect2DPivotNode != null)
                    {
                        if (collect2DLoL)
                        {
                            s += $"\n\nSince '{collect2DPivotNode.Text}' is a list-of-lists, Collect2D aggregation is REQUIRED. ";
                        }
                        else
                        {
                            string path = string.Join(" -> ", collect2DRelativePath);
                            s += $"\n\nSince the path {path} can be found repeated under each key of '{collect2DPivotNode.Text}' (with the same type and dimension), Collect2D aggregation is available. ";
                        }
                        if (comboBoxCollect2D.SelectedIndex > -1)
                        {
                            if (collect2D != "Collate")
                                s += $"As Collect2D has been enabled, each individual value of the '{name}' array under '{collect2DPivotNode.Text}' will be aggregated across attributes using {collect2D}(). ";
                            else
                                s += $"As 'Collate' has been selected, each '{name}' array under '{collect2DPivotNode.Text}' will be extracted and added to the resulting table" +
                                      (checkBoxGraph.Checked ? " (and graph)." : ".");
                        }
                        else
                        {
                            s += "However, no Collect2D function has been selected, so no 2-dimensional aggregation will be performed. ";
                        }
                    }

                    s += "\n\nOne-dimensional aggregation (Collect1D) is available on all numeric array attributes. ";
                    var noneSelected = "However, as no aggregation function was selected, no aggregation will be performed. ";
                    if (comboBoxCollect1D.SelectedIndex > -1)
                    {
                        if (collect1D != "None")
                        {
                            s += $"As Collect1D {collect1D} was selected, the attribute will be ";
                            switch (collect1D)
                            {
                                case "TableRows": s += "appended as a block of row-ordered, comma-delimited arrays at the bottom of the extract. "; break;
                                case "TableCols": s += "appended as a block of column-ordered, comma-delimited arrays at the bottom of the extract. "; break;
                                case "PipeDelimited": s += "collapsed to a single pipe-delimited string (|) and included in the standard extract table. "; break;
                                case "CommaDelimited": s += "appended to the ongoing extract CSV as a series of comma-delimited vaues. "; break;
                                default: s += $"collapsed into a single scalar value using the {collect1D}() function. "; break;
                            }

                            if (collect2DPivotNode != null)
                                s += $"It is important to note that Collect2D aggregation ({collect2D}) will be performed BEFORE Collect1D aggregation. ";
                        }
                        else
                            s += noneSelected;
                    }
                    else
                        s += noneSelected;

                    if (checkBoxGraph.Checked)
                        s += "\n\nAs Graph is checked, each array will be plotted to a chart in the other tab during extraction. ";
                    else
                        s += "\n\nNo graph will be generated for this attribute as that option was not selected. ";
                }
            }

            // https://stackoverflow.com/a/3230908/11615696
            Regex re = new Regex("(.{80} )"); 
            s = re.Replace(s, "$1\n");

            toolTip1.SetToolTip(labelExtractAttributeExplain, s);
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

            updateExplanation();
        }

        /// <summary>
        /// The user clicked the button to add the selected JSON TreeView Node
        /// to the list of ExtractAttributes.
        /// </summary>
        void buttonAttrAdd_Click(object sender, EventArgs e)
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

            // if 2D collection is selected, store the path to the pivot node, and the relative path to THIS attribute
            if (comboBoxCollect2D.SelectedIndex > 0)
            {
                ea.collect2DPivotPath = collect2DPivotNode.FullPath;
                ea.collect2DRelativePath = collect2DRelativePath;
                ea.collect2DLoL = collect2DLoL;
                ea.collect2D = (ExtractAttribute.Collect2D)Enum.Parse(
                    typeof(ExtractAttribute.Collect2D), comboBoxCollect2D.Text);
            }

            ea.graph = checkBoxGraph.Checked;

            if (collect2DLoL && !ea.doingCollect2D())
            {
                logger.error("Collect2D is currently required for List-of-Lists");
                return;
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
        void buttonUseCoefficients_Click(object sender, EventArgs e)
        {
            if (interpolationCoefficientsJSONPath is null)
            {
                var ea = generateExtractAttributeFromSelectedJSONNode();
                if (ea.collect1D is null)
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
            updateExplanation();
        }

        void numericUpDownInterpolationStart_ValueChanged(object sender, EventArgs e) => updateInterpolationControls();
        void numericUpDownInterpolationEnd_ValueChanged(object sender, EventArgs e) => updateInterpolationControls();
        void numericUpDownInterpolationIncr_ValueChanged(object sender, EventArgs e) => updateInterpolationControls();

        void buttonExcitation_Click(object sender, EventArgs e)
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
                ea.collect1D = (ExtractAttribute.Collect1D)Enum.Parse(
                    typeof(ExtractAttribute.Collect1D),
                    comboBoxCollect1D.Text);

            return ea;
        }

        void dataGridViewAttributes_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            updateStartability();
        }

        void dataGridViewAttributes_SelectionChanged(object sender, EventArgs e)
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

        void buttonExtractAttributeUp_Click(object sender, EventArgs e)
        {
            var row = dataGridViewAttributes.CurrentCell.RowIndex;
            if (row < 1)
                return;
            var ea = extractAttributes[row];
            extractAttributes.RemoveAt(row);
            extractAttributes.Insert(row - 1, ea);
        }

        void buttonExtractAttributeDown_Click(object sender, EventArgs e)
        {
            var row = dataGridViewAttributes.CurrentCell.RowIndex;
            if (row + 1 >= extractAttributes.Count)
                return;
            var ea = extractAttributes[row];
            extractAttributes.RemoveAt(row);
            extractAttributes.Insert(row + 1, ea);
        }

        /// <summary>
        /// is 2D collection possible from the selected attribute?
        /// </summary>
        /// <param name="tvn">The just-selected TreeViewNode</param>
        void updateCollect2D(TreeNode tvn)
        {
            if (tvn != null && tvn.Parent != null && tvn.Text.EndsWith("[]"))
            {
                List<string> pathTok = tvn.FullPath.Split('\\').ToList();
                var obj = Util.getJsonValue(treeRoot, tvn.FullPath);
                if (obj is null)
                {
                    logger.error("updateCollect2D: obj null?");
                    setCollect2DNotPossible();
                    return;
                }

                // is this a List<List<double>> (BaselineTest)?
                if (Util.isLoL(obj))
                { 
                    setCollect2DPossible(tvn, tvn, new List<string>());
                    return;
                }

                // this is not a list-of-lists, so search upwards for a pivot node
                List<object> l = (List<object>)obj;
                Collect2DSignature sigNode = new()
                {
                    name = pathTok.Last(),      // e.g. 'processed[]'
                    count = l.Count,            // e.g. 2048
                    type = l.GetType(),         // e.g. List<double> 
                    subtype = l[0].GetType(),   // e.g. double       
                };
                List<Collect2DSignature> sigList = new() { sigNode };

                Tuple<TreeNode, List<string>> retval = findPivot(tvn.Parent.Parent, sigList);
                if (retval != null)
                {
                    setCollect2DPossible(tvn, retval.Item1, retval.Item2);
                    return;
                }
            }
            setCollect2DNotPossible();
        }

        void setCollect2DPossible(TreeNode srcNode, TreeNode pivotNode, List<string>relativePath)
        {
            collect2DPivotNode = pivotNode;
            collect2DRelativePath = relativePath;
            collect2DLoL = relativePath.Count == 0;

            string hint = collect2DLoL ? "list-of-lists" : (collect2DPivotNode.Text + " -> " + Util.joinAny(collect2DRelativePath));
            logger.debug($"collect2D possible for {srcNode.Text} ({hint})");
            comboBoxCollect2D.Enabled = true;
            toolTip1.SetToolTip(comboBoxCollect2D, hint);
            labelCollect2D.ForeColor = SystemColors.ControlText;
            updateExplanation();
        }

        void setCollect2DNotPossible()
        {
            var msg = "Collect2D is not possible for the selected attribute.";
            collect2DPivotNode = null;
            collect2DRelativePath = null;
            collect2DLoL = false;
            comboBoxCollect2D.Enabled = false;
            comboBoxCollect2D.SelectedIndex = 0;
            toolTip1.SetToolTip(comboBoxCollect2D, msg);
            labelCollect2D.ForeColor = SystemColors.GrayText;
            logger.debug(msg);
            updateExplanation();
        }

        ////////////////////////////////////////////////////////////////////////
        // Some of this should definitely be moved out of the Form
        ////////////////////////////////////////////////////////////////////////

        bool nodeContainsPath(TreeNode tvn, List<Collect2DSignature> sigList)
        {
            var topSig = sigList.First();
            var topName = topSig.name; // may need to use this
            var children = tvn.Nodes;
            for (int i = 0; i < children.Count; i++)
            {
                var child = tvn.Nodes[i];
                if (child.Text != topSig.name)
                    continue;

                if (sigList.Count > 1)
                    return nodeContainsPath(child, sigList.Take(1).ToList());

                var value = Util.getJsonValue(treeRoot, child.FullPath);
                List<object> valueList = (List<object>)value;
                try {
                    valueList = (List<object>)value;
                } catch {
                    return false;
                }

                if (valueList.Count != topSig.count)
                    return false;

                var elementType = valueList[0].GetType();
                if (elementType != topSig.subtype)
                    return false;
                return true;
            }
            return false;
        }

        Tuple<TreeNode, List<string>> findPivot(TreeNode node, List<Collect2DSignature> sigList)
        {
            if (node is null)
                return null; 

            var children = node.Nodes;
            bool allMatched = true;
            int matchCount = 0;
            for (int i = 0; i < children.Count; i++)
            {
                var child = children[i];
                if (nodeContainsPath(child, sigList))
                {
                    matchCount++;
                }
                else
                {
                    allMatched = false;
                    break;
                }
            }

            if (allMatched && matchCount > 1)
            {
                var path = sigList.Select(x => x.name).ToList();
                return new Tuple<TreeNode, List<string>>(node, path);
            }
            
            if (node.Parent is null)
                return null;

            var parent = node.Parent;
            var parentSig = new Collect2DSignature() { type = parent.GetType(), name = parent.Text };
            return findPivot(parent, sigList.Prepend(parentSig).ToList());
        }

        private void comboBoxCollect1D_SelectedIndexChanged(object sender, EventArgs e) => updateExplanation();
        private void comboBoxCollect2D_SelectedIndexChanged(object sender, EventArgs e) => updateExplanation();
        private void checkBoxInterpolate_CheckedChanged(object sender, EventArgs e) => updateExplanation();
        private void checkBoxGraph_CheckedChanged(object sender, EventArgs e) => updateExplanation();

        ////////////////////////////////////////////////////////////////////////
        //                                                                    //
        //                         Perform Extract                            //
        //                                                                    //
        ////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// The user clicked the button to start an extract.
        /// </summary>
        void buttonStart_Click(object sender, EventArgs e)
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
                initExtractChartForExtract();

                backgroundWorkerExtraction.RunWorkerAsync();
            }
        }

        ////////////////////////////////////////////////////////////////////////
        //                                                                    //
        //                           Extract Chart                            //
        //                                                                    //
        ////////////////////////////////////////////////////////////////////////

        // doing this programmatically because I deleted SQLServer and broke
        // Visual Studio :-(
        void initExtractChart()
        {
            extractChart.Parent = splitContainerSeriesVsChart.Panel2;
            extractChart.Dock = DockStyle.Fill;

            ChartArea area = new();
            area.BorderWidth = 1;
            area.BorderColor = Color.Gray;
            area.BorderDashStyle = ChartDashStyle.Solid;
            area.ShadowOffset = 5;
            area.AxisX.ScaleView.Zoomable = true;
            area.AxisY.ScaleView.Zoomable = true;
            area.CursorX.IsUserSelectionEnabled = true;
            area.CursorY.IsUserSelectionEnabled = true;
            area.AxisX.LabelStyle.Format = "f2";
            extractChart.ChartAreas.Add(area);

            Legend legend = new();
            extractChart.Legends.Add(legend);
        }

        void initExtractChartForExtract()
        {
            extractChart.Series.Clear();
            chartAttributes = new();
            comboBoxChart.Items.Clear();
            foreach (var ea in extractAttributes)
            {
                if (ea.graph)
                {
                    // currently only support tables
                    if (ea.isTable())
                    {
                        ea.abbr = Convert.ToChar('A' + chartAttributes.Count).ToString();
                        chartAttributes.Add(ea);
                        comboBoxChart.Items.Add(ea.label);
                        logger.debug($"assigned abbr {ea.abbr} to {ea}");
                    }
                }
            }

            // default to the first attribute
            if (chartAttributes.Count > 0)
                comboBoxChart.SelectedIndex = 0;
        }

        /// <see href="https://stackoverflow.com/a/40884366/11615696"/>
        void addGraphableRecords(ExtractAttribute ea, Dictionary<string, List<double>> graphableRecords)
        {
            if (!ea.graph || graphableRecords is null)
                return;

            foreach (var pair in graphableRecords)
            {
                var key = pair.Key;
                var values = pair.Value;

                if (key is null || key.Length == 0 || values is null || values.Count == 0)
                    continue;

                CheckBox cb = new();
                cb.Text = key;
                cb.Checked = true;
                cb.CheckedChanged += checkBoxExtractChart_CheckedChanged;
                cb.AutoSize = true;

                var panel = tableLayoutPanelSeries;

                // base new rows on the first row
                RowStyle first = panel.RowStyles[0];

                var rowStyle = new RowStyle(SizeType.AutoSize, first.Height);
                panel.RowStyles.Add(rowStyle);
                panel.Controls.Add(cb, 0, panel.RowCount);
                panel.RowCount++;

                string label = ea.abbr + "." + key;
                Series s = new Series(label);
                s.ChartType = SeriesChartType.Line;

                if (ea.interpolatedAxis is null)
                    for (int i = 0; i < values.Count; i++)
                        s.Points.AddXY(i, values[i]);
                else
                    for (int i = 0; i < ea.interpolatedAxis.newX.Count; i++)
                        s.Points.AddXY(ea.interpolatedAxis.newX[i], values[i]);

                extractChart.Series.Add(s);

                GraphSeries gs = new GraphSeries()
                {
                    series = s,
                    checkBox = cb,
                    intendedCheckState = true
                };
                cb.Tag = gs; // urk
                ea.graphSeries.Add(gs);

                if (ea != selectedChartAttribute())
                {
                    gs.checkBox.Visible = false;
                    gs.series.Enabled = false;
                }
            }
        }

        void checkBoxExtractChart_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            var gs = (GraphSeries)cb.Tag;

            gs.series.Enabled =
            gs.intendedCheckState = cb.Checked;

            // logger.debug($"toggled {gs}");
        }

        private void buttonSelectNone_Click(object sender, EventArgs e)
        {
            foreach (var ea in chartAttributes)
                if (ea == selectedChartAttribute())
                    foreach (var gs in ea.graphSeries)
                        gs.checkBox.Checked = gs.intendedCheckState = false;

        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            foreach (var ea in chartAttributes)
                if (ea == selectedChartAttribute())
                    foreach (var gs in ea.graphSeries)
                        gs.checkBox.Checked = gs.intendedCheckState = true;
        }

        ExtractAttribute selectedChartAttribute()
        {
            if (comboBoxChart.SelectedIndex == -1)
                return null;
            return chartAttributes[comboBoxChart.SelectedIndex];
        }

        void comboBoxChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = selectedChartAttribute();
            logger.debug($"updating graph to show {selected}");

            labelSelectedSeries.Text = $"{selected.label}\n{selected.jsonFullPath}\nCollect1D {selected.collect1D}\nCollect2D {selected.collect2D}";

            foreach (var ea in chartAttributes)
            {
                if (ea == selected)
                {
                    foreach (var gs in ea.graphSeries)
                    {
                        gs.checkBox.Visible = gs.series.Enabled = true;
                        gs.checkBox.Checked = gs.intendedCheckState;
                    }
                }
                else
                {
                    foreach (var gs in ea.graphSeries)
                        gs.checkBox.Visible = gs.series.Enabled = false;
                }
            }
            extractChart.ChartAreas[0].RecalculateAxesScale();
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

        void BackgroundWorkerExtraction_DoWork(object sender, DoWorkEventArgs e)
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

                    if (ea.isTable())
                    {
                        var graphableRecords = ea.storeTable(value, recordKey, jsonObj);
                        if (ea.graph)
                            extractChart.BeginInvoke(new MethodInvoker(delegate { addGraphableRecords(ea, graphableRecords); }));
                    }
                    else
                        values.Add(ea.formatValue(value, jsonObj));
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
                    outfile.WriteLine(ea.formatTable());
                }
            }

            logger.info("Extraction done");
        }

        void BackgroundWorkerExtraction_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        void BackgroundWorkerExtraction_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            logger.info("Extraction completed");
            outfile.Close();
            buttonStart.Text = "Start";
            extractRunning = false;
            progressBarStatus.Value = 0;
        }
    }
}
