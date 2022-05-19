
namespace JSONExtractor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainerTopVsBottom = new System.Windows.Forms.SplitContainer();
            this.splitContainerTabsVsJSONOnward = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageInput = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxDedupeWithin = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxDedupeFilenames = new System.Windows.Forms.TextBox();
            this.buttonLoadSample = new System.Windows.Forms.Button();
            this.buttonSelectFiles = new System.Windows.Forms.Button();
            this.checkBoxDedupeFilenames = new System.Windows.Forms.CheckBox();
            this.buttonSelectInputDir = new System.Windows.Forms.Button();
            this.tabPageExtract = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelProcessedCount = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelFilteredCount = new System.Windows.Forms.Label();
            this.labelDedupedCount = new System.Windows.Forms.Label();
            this.labelSelectedCount = new System.Windows.Forms.Label();
            this.labelSkippedCount = new System.Windows.Forms.Label();
            this.labelExtractedCount = new System.Windows.Forms.Label();
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSaveConfig = new System.Windows.Forms.Button();
            this.buttonLoadConfig = new System.Windows.Forms.Button();
            this.tabPageAWS = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxS3SecretKey = new System.Windows.Forms.TextBox();
            this.textBoxS3AccessKey = new System.Windows.Forms.TextBox();
            this.textBoxS3Bucket = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonS3CacheDir = new System.Windows.Forms.Button();
            this.buttonS3StartSync = new System.Windows.Forms.Button();
            this.splitContainerJSONandButtonsVsDatagrids = new System.Windows.Forms.SplitContainer();
            this.splitContainerTreeVsOpts = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.treeViewJSON = new System.Windows.Forms.TreeView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxFilterPattern = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxFilterType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxFilterWithin = new System.Windows.Forms.TextBox();
            this.buttonFilterAdd = new System.Windows.Forms.Button();
            this.checkBoxFilterSufficient = new System.Windows.Forms.CheckBox();
            this.checkBoxFilterNegate = new System.Windows.Forms.CheckBox();
            this.checkBoxNullOk = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonExtractAttributeDown = new System.Windows.Forms.Button();
            this.buttonExtractAttributeUp = new System.Windows.Forms.Button();
            this.buttonAddExtractAttribute = new System.Windows.Forms.Button();
            this.numericUpDownExtractAttributePrecision = new System.Windows.Forms.NumericUpDown();
            this.textBoxExtractAttributeDefault = new System.Windows.Forms.TextBox();
            this.comboBoxExtractAttributeAggregateType = new System.Windows.Forms.ComboBox();
            this.textBoxExtractAttributeLabel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBoxInterpolate = new System.Windows.Forms.CheckBox();
            this.groupBoxInterpolation = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownInterpolationStart = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownInterpolationIncr = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownInterpolationEnd = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonUseCoefficients = new System.Windows.Forms.Button();
            this.buttonExcitation = new System.Windows.Forms.Button();
            this.splitContainerFilterVsAttributeTables = new System.Windows.Forms.SplitContainer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataGridViewFilters = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dataGridViewAttributes = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelProgressAndLog = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxEventLog = new System.Windows.Forms.GroupBox();
            this.textBoxEventLog = new System.Windows.Forms.TextBox();
            this.progressBarStatus = new System.Windows.Forms.ProgressBar();
            this.openFileDialogSample = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogInputFiles = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.folderBrowserDialogInputDir = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorkerExtraction = new System.ComponentModel.BackgroundWorker();
            this.saveFileDialogExtract = new System.Windows.Forms.SaveFileDialog();
            this.tabPageInterpolation = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTopVsBottom)).BeginInit();
            this.splitContainerTopVsBottom.Panel1.SuspendLayout();
            this.splitContainerTopVsBottom.Panel2.SuspendLayout();
            this.splitContainerTopVsBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTabsVsJSONOnward)).BeginInit();
            this.splitContainerTabsVsJSONOnward.Panel1.SuspendLayout();
            this.splitContainerTabsVsJSONOnward.Panel2.SuspendLayout();
            this.splitContainerTabsVsJSONOnward.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageInput.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageExtract.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPageConfig.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPageAWS.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerJSONandButtonsVsDatagrids)).BeginInit();
            this.splitContainerJSONandButtonsVsDatagrids.Panel1.SuspendLayout();
            this.splitContainerJSONandButtonsVsDatagrids.Panel2.SuspendLayout();
            this.splitContainerJSONandButtonsVsDatagrids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTreeVsOpts)).BeginInit();
            this.splitContainerTreeVsOpts.Panel1.SuspendLayout();
            this.splitContainerTreeVsOpts.Panel2.SuspendLayout();
            this.splitContainerTreeVsOpts.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExtractAttributePrecision)).BeginInit();
            this.groupBoxInterpolation.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterpolationStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterpolationIncr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterpolationEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFilterVsAttributeTables)).BeginInit();
            this.splitContainerFilterVsAttributeTables.Panel1.SuspendLayout();
            this.splitContainerFilterVsAttributeTables.Panel2.SuspendLayout();
            this.splitContainerFilterVsAttributeTables.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilters)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttributes)).BeginInit();
            this.tableLayoutPanelProgressAndLog.SuspendLayout();
            this.groupBoxEventLog.SuspendLayout();
            this.tabPageInterpolation.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerTopVsBottom
            // 
            this.splitContainerTopVsBottom.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainerTopVsBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTopVsBottom.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTopVsBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerTopVsBottom.Name = "splitContainerTopVsBottom";
            this.splitContainerTopVsBottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTopVsBottom.Panel1
            // 
            this.splitContainerTopVsBottom.Panel1.Controls.Add(this.splitContainerTabsVsJSONOnward);
            // 
            // splitContainerTopVsBottom.Panel2
            // 
            this.splitContainerTopVsBottom.Panel2.Controls.Add(this.tableLayoutPanelProgressAndLog);
            this.splitContainerTopVsBottom.Size = new System.Drawing.Size(2564, 1307);
            this.splitContainerTopVsBottom.SplitterDistance = 977;
            this.splitContainerTopVsBottom.SplitterWidth = 3;
            this.splitContainerTopVsBottom.TabIndex = 0;
            // 
            // splitContainerTabsVsJSONOnward
            // 
            this.splitContainerTabsVsJSONOnward.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainerTabsVsJSONOnward.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTabsVsJSONOnward.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTabsVsJSONOnward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerTabsVsJSONOnward.Name = "splitContainerTabsVsJSONOnward";
            // 
            // splitContainerTabsVsJSONOnward.Panel1
            // 
            this.splitContainerTabsVsJSONOnward.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainerTabsVsJSONOnward.Panel2
            // 
            this.splitContainerTabsVsJSONOnward.Panel2.Controls.Add(this.splitContainerJSONandButtonsVsDatagrids);
            this.splitContainerTabsVsJSONOnward.Size = new System.Drawing.Size(2564, 977);
            this.splitContainerTabsVsJSONOnward.SplitterDistance = 359;
            this.splitContainerTabsVsJSONOnward.SplitterWidth = 3;
            this.splitContainerTabsVsJSONOnward.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPageInput);
            this.tabControl1.Controls.Add(this.tabPageExtract);
            this.tabControl1.Controls.Add(this.tabPageInterpolation);
            this.tabControl1.Controls.Add(this.tabPageConfig);
            this.tabControl1.Controls.Add(this.tabPageAWS);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(5);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(359, 977);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageInput
            // 
            this.tabPageInput.Controls.Add(this.groupBox10);
            this.tabPageInput.Location = new System.Drawing.Point(43, 4);
            this.tabPageInput.Margin = new System.Windows.Forms.Padding(5);
            this.tabPageInput.Name = "tabPageInput";
            this.tabPageInput.Padding = new System.Windows.Forms.Padding(5);
            this.tabPageInput.Size = new System.Drawing.Size(312, 969);
            this.tabPageInput.TabIndex = 4;
            this.tabPageInput.Text = "Input Files";
            this.tabPageInput.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.AutoSize = true;
            this.groupBox10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox10.Controls.Add(this.tableLayoutPanel2);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox10.Location = new System.Drawing.Point(5, 5);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox10.Size = new System.Drawing.Size(302, 959);
            this.groupBox10.TabIndex = 7;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Input Files";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.buttonLoadSample, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonSelectFiles, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxDedupeFilenames, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.buttonSelectInputDir, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 38);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(290, 915);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxDedupeWithin);
            this.groupBox2.Location = new System.Drawing.Point(5, 307);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(275, 146);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Within";
            // 
            // textBoxDedupeWithin
            // 
            this.textBoxDedupeWithin.Location = new System.Drawing.Point(10, 42);
            this.textBoxDedupeWithin.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxDedupeWithin.Multiline = true;
            this.textBoxDedupeWithin.Name = "textBoxDedupeWithin";
            this.textBoxDedupeWithin.Size = new System.Drawing.Size(254, 76);
            this.textBoxDedupeWithin.TabIndex = 3;
            this.toolTip1.SetToolTip(this.textBoxDedupeWithin, "Comma-delimited list of \"allowed\" strings (serial number, etc) from the regular e" +
        "xpression\'s first matching group");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxDedupeFilenames);
            this.groupBox1.Location = new System.Drawing.Point(3, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 104);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Regex";
            // 
            // textBoxDedupeFilenames
            // 
            this.textBoxDedupeFilenames.Location = new System.Drawing.Point(6, 38);
            this.textBoxDedupeFilenames.Name = "textBoxDedupeFilenames";
            this.textBoxDedupeFilenames.Size = new System.Drawing.Size(258, 39);
            this.textBoxDedupeFilenames.TabIndex = 1;
            this.textBoxDedupeFilenames.Text = "^\\d{14}-(.*)$";
            this.toolTip1.SetToolTip(this.textBoxDedupeFilenames, "Regular expression used for dedupping and/or \"Within\" clause (i.e., identifying t" +
        "he serial number portion of a filename appearing after a 14-digit datetime value" +
        ")");
            // 
            // buttonLoadSample
            // 
            this.buttonLoadSample.Location = new System.Drawing.Point(3, 2);
            this.buttonLoadSample.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLoadSample.Name = "buttonLoadSample";
            this.buttonLoadSample.Size = new System.Drawing.Size(172, 46);
            this.buttonLoadSample.TabIndex = 0;
            this.buttonLoadSample.Text = "Load Sample";
            this.buttonLoadSample.UseVisualStyleBackColor = true;
            this.buttonLoadSample.Click += new System.EventHandler(this.buttonLoadSample_Click);
            // 
            // buttonSelectFiles
            // 
            this.buttonSelectFiles.Location = new System.Drawing.Point(3, 102);
            this.buttonSelectFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSelectFiles.Name = "buttonSelectFiles";
            this.buttonSelectFiles.Size = new System.Drawing.Size(172, 46);
            this.buttonSelectFiles.TabIndex = 1;
            this.buttonSelectFiles.Text = "Select Files";
            this.buttonSelectFiles.UseVisualStyleBackColor = true;
            this.buttonSelectFiles.Click += new System.EventHandler(this.buttonSelectFiles_Click);
            // 
            // checkBoxDedupeFilenames
            // 
            this.checkBoxDedupeFilenames.AutoSize = true;
            this.checkBoxDedupeFilenames.Location = new System.Drawing.Point(3, 153);
            this.checkBoxDedupeFilenames.Name = "checkBoxDedupeFilenames";
            this.checkBoxDedupeFilenames.Size = new System.Drawing.Size(131, 36);
            this.checkBoxDedupeFilenames.TabIndex = 0;
            this.checkBoxDedupeFilenames.Text = "Dedupe";
            this.toolTip1.SetToolTip(this.checkBoxDedupeFilenames, "Only process the LAST sequential filename for each unique string in the regular e" +
        "xpression\'s first match group (e.g., only the LAST time a particular serial numb" +
        "er was QC\'d)");
            this.checkBoxDedupeFilenames.UseVisualStyleBackColor = true;
            // 
            // buttonSelectInputDir
            // 
            this.buttonSelectInputDir.Location = new System.Drawing.Point(3, 52);
            this.buttonSelectInputDir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSelectInputDir.Name = "buttonSelectInputDir";
            this.buttonSelectInputDir.Size = new System.Drawing.Size(172, 46);
            this.buttonSelectInputDir.TabIndex = 2;
            this.buttonSelectInputDir.Text = "Select Folder";
            this.buttonSelectInputDir.UseVisualStyleBackColor = true;
            this.buttonSelectInputDir.Click += new System.EventHandler(this.buttonSelectInputDir_Click);
            // 
            // tabPageExtract
            // 
            this.tabPageExtract.Controls.Add(this.groupBox8);
            this.tabPageExtract.Location = new System.Drawing.Point(43, 4);
            this.tabPageExtract.Margin = new System.Windows.Forms.Padding(5);
            this.tabPageExtract.Name = "tabPageExtract";
            this.tabPageExtract.Padding = new System.Windows.Forms.Padding(5);
            this.tabPageExtract.Size = new System.Drawing.Size(312, 969);
            this.tabPageExtract.TabIndex = 2;
            this.tabPageExtract.Text = "Extract";
            this.tabPageExtract.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.AutoSize = true;
            this.groupBox8.Controls.Add(this.tableLayoutPanel1);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(5, 5);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox8.Size = new System.Drawing.Size(302, 959);
            this.groupBox8.TabIndex = 5;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Extract";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelProcessedCount, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonStart, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelFilteredCount, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelDedupedCount, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelSelectedCount, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelSkippedCount, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelExtractedCount, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 38);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(290, 915);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // labelProcessedCount
            // 
            this.labelProcessedCount.AutoSize = true;
            this.labelProcessedCount.Location = new System.Drawing.Point(6, 178);
            this.labelProcessedCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelProcessedCount.Name = "labelProcessedCount";
            this.labelProcessedCount.Size = new System.Drawing.Size(145, 32);
            this.labelProcessedCount.TabIndex = 3;
            this.labelProcessedCount.Text = "Processed: 0";
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(3, 2);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(162, 46);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelFilteredCount
            // 
            this.labelFilteredCount.AutoSize = true;
            this.labelFilteredCount.Location = new System.Drawing.Point(6, 114);
            this.labelFilteredCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelFilteredCount.Name = "labelFilteredCount";
            this.labelFilteredCount.Size = new System.Drawing.Size(119, 32);
            this.labelFilteredCount.TabIndex = 4;
            this.labelFilteredCount.Text = "Filtered: 0";
            // 
            // labelDedupedCount
            // 
            this.labelDedupedCount.AutoSize = true;
            this.labelDedupedCount.Location = new System.Drawing.Point(3, 82);
            this.labelDedupedCount.Name = "labelDedupedCount";
            this.labelDedupedCount.Size = new System.Drawing.Size(138, 32);
            this.labelDedupedCount.TabIndex = 8;
            this.labelDedupedCount.Text = "Deduped: 0";
            // 
            // labelSelectedCount
            // 
            this.labelSelectedCount.AutoSize = true;
            this.labelSelectedCount.Location = new System.Drawing.Point(6, 50);
            this.labelSelectedCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSelectedCount.Name = "labelSelectedCount";
            this.labelSelectedCount.Size = new System.Drawing.Size(130, 32);
            this.labelSelectedCount.TabIndex = 6;
            this.labelSelectedCount.Text = "Selected: 0";
            // 
            // labelSkippedCount
            // 
            this.labelSkippedCount.AutoSize = true;
            this.labelSkippedCount.Location = new System.Drawing.Point(3, 146);
            this.labelSkippedCount.Name = "labelSkippedCount";
            this.labelSkippedCount.Size = new System.Drawing.Size(125, 32);
            this.labelSkippedCount.TabIndex = 7;
            this.labelSkippedCount.Text = "Skipped: 0";
            // 
            // labelExtractedCount
            // 
            this.labelExtractedCount.AutoSize = true;
            this.labelExtractedCount.Location = new System.Drawing.Point(6, 210);
            this.labelExtractedCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelExtractedCount.Name = "labelExtractedCount";
            this.labelExtractedCount.Size = new System.Drawing.Size(136, 32);
            this.labelExtractedCount.TabIndex = 5;
            this.labelExtractedCount.Text = "Extracted: 0";
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.Controls.Add(this.groupBox9);
            this.tabPageConfig.Location = new System.Drawing.Point(43, 4);
            this.tabPageConfig.Margin = new System.Windows.Forms.Padding(5);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Padding = new System.Windows.Forms.Padding(5);
            this.tabPageConfig.Size = new System.Drawing.Size(312, 969);
            this.tabPageConfig.TabIndex = 3;
            this.tabPageConfig.Text = "Configuration";
            this.tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.AutoSize = true;
            this.groupBox9.Controls.Add(this.tableLayoutPanel3);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox9.Location = new System.Drawing.Point(5, 5);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox9.Size = new System.Drawing.Size(302, 959);
            this.groupBox9.TabIndex = 6;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Configurations";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.buttonSaveConfig, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonLoadConfig, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 38);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(290, 915);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // buttonSaveConfig
            // 
            this.buttonSaveConfig.Location = new System.Drawing.Point(3, 2);
            this.buttonSaveConfig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSaveConfig.Name = "buttonSaveConfig";
            this.buttonSaveConfig.Size = new System.Drawing.Size(162, 46);
            this.buttonSaveConfig.TabIndex = 3;
            this.buttonSaveConfig.Text = "Save Config";
            this.buttonSaveConfig.UseVisualStyleBackColor = true;
            this.buttonSaveConfig.Click += new System.EventHandler(this.buttonSaveConfig_Click);
            // 
            // buttonLoadConfig
            // 
            this.buttonLoadConfig.Location = new System.Drawing.Point(3, 52);
            this.buttonLoadConfig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLoadConfig.Name = "buttonLoadConfig";
            this.buttonLoadConfig.Size = new System.Drawing.Size(162, 46);
            this.buttonLoadConfig.TabIndex = 4;
            this.buttonLoadConfig.Text = "Load Config";
            this.buttonLoadConfig.UseVisualStyleBackColor = true;
            this.buttonLoadConfig.Click += new System.EventHandler(this.buttonLoadConfig_Click);
            // 
            // tabPageAWS
            // 
            this.tabPageAWS.Controls.Add(this.groupBox11);
            this.tabPageAWS.Location = new System.Drawing.Point(43, 4);
            this.tabPageAWS.Margin = new System.Windows.Forms.Padding(5);
            this.tabPageAWS.Name = "tabPageAWS";
            this.tabPageAWS.Padding = new System.Windows.Forms.Padding(5);
            this.tabPageAWS.Size = new System.Drawing.Size(312, 969);
            this.tabPageAWS.TabIndex = 0;
            this.tabPageAWS.Text = "AWS";
            this.tabPageAWS.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.tableLayoutPanel4);
            this.groupBox11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox11.Location = new System.Drawing.Point(5, 5);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox11.Size = new System.Drawing.Size(302, 959);
            this.groupBox11.TabIndex = 8;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "AWS S3";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.textBoxS3SecretKey, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.textBoxS3AccessKey, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.textBoxS3Bucket, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.buttonS3CacheDir, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.buttonS3StartSync, 1, 4);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(6, 38);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(290, 915);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // textBoxS3SecretKey
            // 
            this.textBoxS3SecretKey.Location = new System.Drawing.Point(102, 108);
            this.textBoxS3SecretKey.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxS3SecretKey.Name = "textBoxS3SecretKey";
            this.textBoxS3SecretKey.Size = new System.Drawing.Size(157, 39);
            this.textBoxS3SecretKey.TabIndex = 2;
            this.textBoxS3SecretKey.Text = "secretKey";
            this.toolTip1.SetToolTip(this.textBoxS3SecretKey, "AWS Secret Key");
            this.textBoxS3SecretKey.UseSystemPasswordChar = true;
            this.textBoxS3SecretKey.TextChanged += new System.EventHandler(this.textBoxS3SecretKey_TextChanged);
            // 
            // textBoxS3AccessKey
            // 
            this.textBoxS3AccessKey.Location = new System.Drawing.Point(102, 57);
            this.textBoxS3AccessKey.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxS3AccessKey.Name = "textBoxS3AccessKey";
            this.textBoxS3AccessKey.Size = new System.Drawing.Size(157, 39);
            this.textBoxS3AccessKey.TabIndex = 1;
            this.textBoxS3AccessKey.Text = "accessKey";
            this.toolTip1.SetToolTip(this.textBoxS3AccessKey, "AWS Access Key");
            this.textBoxS3AccessKey.TextChanged += new System.EventHandler(this.textBoxS3AccessKey_TextChanged);
            // 
            // textBoxS3Bucket
            // 
            this.textBoxS3Bucket.Location = new System.Drawing.Point(102, 6);
            this.textBoxS3Bucket.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxS3Bucket.Name = "textBoxS3Bucket";
            this.textBoxS3Bucket.Size = new System.Drawing.Size(157, 39);
            this.textBoxS3Bucket.TabIndex = 0;
            this.textBoxS3Bucket.Text = "s3bucket";
            this.toolTip1.SetToolTip(this.textBoxS3Bucket, "AWS S3 bucket");
            this.textBoxS3Bucket.TextChanged += new System.EventHandler(this.textBoxS3Bucket_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bucket";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Access";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 111);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Secret";
            // 
            // buttonS3CacheDir
            // 
            this.buttonS3CacheDir.Location = new System.Drawing.Point(102, 159);
            this.buttonS3CacheDir.Margin = new System.Windows.Forms.Padding(6);
            this.buttonS3CacheDir.Name = "buttonS3CacheDir";
            this.buttonS3CacheDir.Size = new System.Drawing.Size(159, 50);
            this.buttonS3CacheDir.TabIndex = 3;
            this.buttonS3CacheDir.Text = "Cache Dir";
            this.buttonS3CacheDir.UseVisualStyleBackColor = true;
            this.buttonS3CacheDir.Click += new System.EventHandler(this.buttonS3CacheDir_Click);
            // 
            // buttonS3StartSync
            // 
            this.buttonS3StartSync.Location = new System.Drawing.Point(102, 221);
            this.buttonS3StartSync.Margin = new System.Windows.Forms.Padding(6);
            this.buttonS3StartSync.Name = "buttonS3StartSync";
            this.buttonS3StartSync.Size = new System.Drawing.Size(159, 50);
            this.buttonS3StartSync.TabIndex = 4;
            this.buttonS3StartSync.Text = "Start Sync";
            this.buttonS3StartSync.UseVisualStyleBackColor = true;
            this.buttonS3StartSync.Click += new System.EventHandler(this.buttonS3StartSync_Click);
            // 
            // splitContainerJSONandButtonsVsDatagrids
            // 
            this.splitContainerJSONandButtonsVsDatagrids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerJSONandButtonsVsDatagrids.Location = new System.Drawing.Point(0, 0);
            this.splitContainerJSONandButtonsVsDatagrids.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerJSONandButtonsVsDatagrids.Name = "splitContainerJSONandButtonsVsDatagrids";
            // 
            // splitContainerJSONandButtonsVsDatagrids.Panel1
            // 
            this.splitContainerJSONandButtonsVsDatagrids.Panel1.Controls.Add(this.splitContainerTreeVsOpts);
            // 
            // splitContainerJSONandButtonsVsDatagrids.Panel2
            // 
            this.splitContainerJSONandButtonsVsDatagrids.Panel2.Controls.Add(this.splitContainerFilterVsAttributeTables);
            this.splitContainerJSONandButtonsVsDatagrids.Size = new System.Drawing.Size(2202, 977);
            this.splitContainerJSONandButtonsVsDatagrids.SplitterDistance = 975;
            this.splitContainerJSONandButtonsVsDatagrids.SplitterWidth = 3;
            this.splitContainerJSONandButtonsVsDatagrids.TabIndex = 0;
            // 
            // splitContainerTreeVsOpts
            // 
            this.splitContainerTreeVsOpts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTreeVsOpts.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTreeVsOpts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerTreeVsOpts.Name = "splitContainerTreeVsOpts";
            // 
            // splitContainerTreeVsOpts.Panel1
            // 
            this.splitContainerTreeVsOpts.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainerTreeVsOpts.Panel2
            // 
            this.splitContainerTreeVsOpts.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainerTreeVsOpts.Size = new System.Drawing.Size(975, 977);
            this.splitContainerTreeVsOpts.SplitterDistance = 641;
            this.splitContainerTreeVsOpts.SplitterWidth = 3;
            this.splitContainerTreeVsOpts.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.treeViewJSON);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(641, 977);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "JSON Attribute Structure";
            // 
            // treeViewJSON
            // 
            this.treeViewJSON.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewJSON.Location = new System.Drawing.Point(3, 34);
            this.treeViewJSON.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeViewJSON.Name = "treeViewJSON";
            this.treeViewJSON.Size = new System.Drawing.Size(635, 941);
            this.treeViewJSON.TabIndex = 0;
            this.treeViewJSON.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewJSON_AfterSelect);
            this.treeViewJSON.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewJSON_NodeMouseDoubleClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.groupBox4);
            this.flowLayoutPanel1.Controls.Add(this.groupBox7);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(331, 977);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel5);
            this.groupBox4.Location = new System.Drawing.Point(3, 2);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(330, 372);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filter Attributes";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.textBoxFilterPattern, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.comboBoxFilterType, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.textBoxFilterWithin, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.buttonFilterAdd, 1, 6);
            this.tableLayoutPanel5.Controls.Add(this.checkBoxFilterSufficient, 1, 5);
            this.tableLayoutPanel5.Controls.Add(this.checkBoxFilterNegate, 1, 4);
            this.tableLayoutPanel5.Controls.Add(this.checkBoxNullOk, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.label11, 0, 2);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 34);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 7;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(324, 336);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // textBoxFilterPattern
            // 
            this.textBoxFilterPattern.Location = new System.Drawing.Point(100, 6);
            this.textBoxFilterPattern.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxFilterPattern.Name = "textBoxFilterPattern";
            this.textBoxFilterPattern.Size = new System.Drawing.Size(180, 39);
            this.textBoxFilterPattern.TabIndex = 3;
            this.toolTip1.SetToolTip(this.textBoxFilterPattern, "The value or pattern used for matching the field");
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 32);
            this.label4.TabIndex = 7;
            this.label4.Text = "Value";
            // 
            // comboBoxFilterType
            // 
            this.comboBoxFilterType.FormattingEnabled = true;
            this.comboBoxFilterType.Items.AddRange(new object[] {
            "Regex",
            "NumberEquals",
            "LessThanEqualTo",
            "GreaterThanEqualTo",
            "Empty",
            "NonEmpty",
            "DateBefore",
            "DateAfter"});
            this.comboBoxFilterType.Location = new System.Drawing.Point(97, 53);
            this.comboBoxFilterType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxFilterType.Name = "comboBoxFilterType";
            this.comboBoxFilterType.Size = new System.Drawing.Size(183, 40);
            this.comboBoxFilterType.TabIndex = 0;
            this.toolTip1.SetToolTip(this.comboBoxFilterType, "Filter type");
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 57);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 32);
            this.label5.TabIndex = 8;
            this.label5.Text = "Type";
            // 
            // textBoxFilterWithin
            // 
            this.textBoxFilterWithin.Location = new System.Drawing.Point(99, 100);
            this.textBoxFilterWithin.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxFilterWithin.Name = "textBoxFilterWithin";
            this.textBoxFilterWithin.Size = new System.Drawing.Size(182, 39);
            this.textBoxFilterWithin.TabIndex = 9;
            this.toolTip1.SetToolTip(this.textBoxFilterWithin, "Comma-delimited list of values");
            // 
            // buttonFilterAdd
            // 
            this.buttonFilterAdd.Enabled = false;
            this.buttonFilterAdd.Location = new System.Drawing.Point(97, 272);
            this.buttonFilterAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonFilterAdd.Name = "buttonFilterAdd";
            this.buttonFilterAdd.Size = new System.Drawing.Size(150, 46);
            this.buttonFilterAdd.TabIndex = 1;
            this.buttonFilterAdd.Text = "Add";
            this.toolTip1.SetToolTip(this.buttonFilterAdd, "Add this filter");
            this.buttonFilterAdd.UseVisualStyleBackColor = true;
            this.buttonFilterAdd.Click += new System.EventHandler(this.buttonFilterAdd_Click);
            // 
            // checkBoxFilterSufficient
            // 
            this.checkBoxFilterSufficient.AutoSize = true;
            this.checkBoxFilterSufficient.Location = new System.Drawing.Point(97, 231);
            this.checkBoxFilterSufficient.Name = "checkBoxFilterSufficient";
            this.checkBoxFilterSufficient.Size = new System.Drawing.Size(147, 36);
            this.checkBoxFilterSufficient.TabIndex = 5;
            this.checkBoxFilterSufficient.Text = "Sufficient";
            this.toolTip1.SetToolTip(this.checkBoxFilterSufficient, "If this filter matches, the record will be extracted");
            this.checkBoxFilterSufficient.UseVisualStyleBackColor = true;
            // 
            // checkBoxFilterNegate
            // 
            this.checkBoxFilterNegate.AutoSize = true;
            this.checkBoxFilterNegate.Location = new System.Drawing.Point(97, 189);
            this.checkBoxFilterNegate.Name = "checkBoxFilterNegate";
            this.checkBoxFilterNegate.Size = new System.Drawing.Size(124, 36);
            this.checkBoxFilterNegate.TabIndex = 4;
            this.checkBoxFilterNegate.Text = "Negate";
            this.toolTip1.SetToolTip(this.checkBoxFilterNegate, "Invert this filter");
            this.checkBoxFilterNegate.UseVisualStyleBackColor = true;
            // 
            // checkBoxNullOk
            // 
            this.checkBoxNullOk.AutoSize = true;
            this.checkBoxNullOk.Location = new System.Drawing.Point(97, 147);
            this.checkBoxNullOk.Name = "checkBoxNullOk";
            this.checkBoxNullOk.Size = new System.Drawing.Size(127, 36);
            this.checkBoxNullOk.TabIndex = 6;
            this.checkBoxNullOk.Text = "Null Ok";
            this.toolTip1.SetToolTip(this.checkBoxNullOk, "This filter will PASS if input field is empty");
            this.checkBoxNullOk.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 103);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 32);
            this.label11.TabIndex = 10;
            this.label11.Text = "Within";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tableLayoutPanel6);
            this.groupBox7.Location = new System.Drawing.Point(3, 378);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Size = new System.Drawing.Size(296, 423);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Extract Attribute";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.buttonExtractAttributeDown, 1, 7);
            this.tableLayoutPanel6.Controls.Add(this.buttonExtractAttributeUp, 1, 6);
            this.tableLayoutPanel6.Controls.Add(this.buttonAddExtractAttribute, 1, 4);
            this.tableLayoutPanel6.Controls.Add(this.numericUpDownExtractAttributePrecision, 1, 3);
            this.tableLayoutPanel6.Controls.Add(this.textBoxExtractAttributeDefault, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.comboBoxExtractAttributeAggregateType, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.textBoxExtractAttributeLabel, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.checkBoxInterpolate, 1, 8);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 34);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 10;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(290, 387);
            this.tableLayoutPanel6.TabIndex = 3;
            // 
            // buttonExtractAttributeDown
            // 
            this.buttonExtractAttributeDown.Location = new System.Drawing.Point(138, 285);
            this.buttonExtractAttributeDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonExtractAttributeDown.Name = "buttonExtractAttributeDown";
            this.buttonExtractAttributeDown.Size = new System.Drawing.Size(150, 46);
            this.buttonExtractAttributeDown.TabIndex = 5;
            this.buttonExtractAttributeDown.Text = "Down";
            this.toolTip1.SetToolTip(this.buttonExtractAttributeDown, "Move the selected field down");
            this.buttonExtractAttributeDown.UseVisualStyleBackColor = true;
            this.buttonExtractAttributeDown.Click += new System.EventHandler(this.buttonExtractAttributeDown_Click);
            // 
            // buttonExtractAttributeUp
            // 
            this.buttonExtractAttributeUp.Location = new System.Drawing.Point(138, 235);
            this.buttonExtractAttributeUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonExtractAttributeUp.Name = "buttonExtractAttributeUp";
            this.buttonExtractAttributeUp.Size = new System.Drawing.Size(150, 46);
            this.buttonExtractAttributeUp.TabIndex = 4;
            this.buttonExtractAttributeUp.Text = "Up";
            this.toolTip1.SetToolTip(this.buttonExtractAttributeUp, "Move the selected field up");
            this.buttonExtractAttributeUp.UseVisualStyleBackColor = true;
            this.buttonExtractAttributeUp.Click += new System.EventHandler(this.buttonExtractAttributeUp_Click);
            // 
            // buttonAddExtractAttribute
            // 
            this.buttonAddExtractAttribute.Enabled = false;
            this.buttonAddExtractAttribute.Location = new System.Drawing.Point(138, 185);
            this.buttonAddExtractAttribute.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAddExtractAttribute.Name = "buttonAddExtractAttribute";
            this.buttonAddExtractAttribute.Size = new System.Drawing.Size(150, 46);
            this.buttonAddExtractAttribute.TabIndex = 1;
            this.buttonAddExtractAttribute.Text = "Add";
            this.toolTip1.SetToolTip(this.buttonAddExtractAttribute, "Add field to the extract");
            this.buttonAddExtractAttribute.UseVisualStyleBackColor = true;
            this.buttonAddExtractAttribute.Click += new System.EventHandler(this.buttonAttrAdd_Click);
            // 
            // numericUpDownExtractAttributePrecision
            // 
            this.numericUpDownExtractAttributePrecision.Location = new System.Drawing.Point(138, 141);
            this.numericUpDownExtractAttributePrecision.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownExtractAttributePrecision.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDownExtractAttributePrecision.Name = "numericUpDownExtractAttributePrecision";
            this.numericUpDownExtractAttributePrecision.Size = new System.Drawing.Size(143, 39);
            this.numericUpDownExtractAttributePrecision.TabIndex = 8;
            this.toolTip1.SetToolTip(this.numericUpDownExtractAttributePrecision, "Decimal precision (-1 for max)");
            // 
            // textBoxExtractAttributeDefault
            // 
            this.textBoxExtractAttributeDefault.Location = new System.Drawing.Point(141, 93);
            this.textBoxExtractAttributeDefault.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxExtractAttributeDefault.Name = "textBoxExtractAttributeDefault";
            this.textBoxExtractAttributeDefault.Size = new System.Drawing.Size(139, 39);
            this.textBoxExtractAttributeDefault.TabIndex = 7;
            this.textBoxExtractAttributeDefault.Text = "default";
            this.toolTip1.SetToolTip(this.textBoxExtractAttributeDefault, "Default value if input is blank");
            // 
            // comboBoxExtractAttributeAggregateType
            // 
            this.comboBoxExtractAttributeAggregateType.FormattingEnabled = true;
            this.comboBoxExtractAttributeAggregateType.Items.AddRange(new object[] {
            "Count",
            "Sum",
            "Mean",
            "StdDev",
            "Min",
            "Max",
            "CommaDelimited",
            "PipeDelimited",
            "TableRows",
            "TableCols"});
            this.comboBoxExtractAttributeAggregateType.Location = new System.Drawing.Point(138, 45);
            this.comboBoxExtractAttributeAggregateType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxExtractAttributeAggregateType.Name = "comboBoxExtractAttributeAggregateType";
            this.comboBoxExtractAttributeAggregateType.Size = new System.Drawing.Size(143, 40);
            this.comboBoxExtractAttributeAggregateType.TabIndex = 2;
            this.toolTip1.SetToolTip(this.comboBoxExtractAttributeAggregateType, "How to handle lists or arrays");
            // 
            // textBoxExtractAttributeLabel
            // 
            this.textBoxExtractAttributeLabel.Location = new System.Drawing.Point(138, 2);
            this.textBoxExtractAttributeLabel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxExtractAttributeLabel.Name = "textBoxExtractAttributeLabel";
            this.textBoxExtractAttributeLabel.Size = new System.Drawing.Size(142, 39);
            this.textBoxExtractAttributeLabel.TabIndex = 6;
            this.textBoxExtractAttributeLabel.Text = "label";
            this.toolTip1.SetToolTip(this.textBoxExtractAttributeLabel, "Column name in the extract");
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 5);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 32);
            this.label6.TabIndex = 9;
            this.label6.Text = "Label";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 49);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 32);
            this.label7.TabIndex = 10;
            this.label7.Text = "Aggregate";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 96);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 32);
            this.label8.TabIndex = 11;
            this.label8.Text = "Default";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 144);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 32);
            this.label9.TabIndex = 12;
            this.label9.Text = "Precision";
            // 
            // checkBoxInterpolate
            // 
            this.checkBoxInterpolate.AutoSize = true;
            this.checkBoxInterpolate.Enabled = false;
            this.checkBoxInterpolate.Location = new System.Drawing.Point(140, 338);
            this.checkBoxInterpolate.Margin = new System.Windows.Forms.Padding(5);
            this.checkBoxInterpolate.Name = "checkBoxInterpolate";
            this.checkBoxInterpolate.Size = new System.Drawing.Size(162, 36);
            this.checkBoxInterpolate.TabIndex = 13;
            this.checkBoxInterpolate.Text = "Interpolate";
            this.checkBoxInterpolate.UseVisualStyleBackColor = true;
            // 
            // groupBoxInterpolation
            // 
            this.groupBoxInterpolation.Controls.Add(this.tableLayoutPanel7);
            this.groupBoxInterpolation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxInterpolation.Location = new System.Drawing.Point(3, 3);
            this.groupBoxInterpolation.Margin = new System.Windows.Forms.Padding(5);
            this.groupBoxInterpolation.Name = "groupBoxInterpolation";
            this.groupBoxInterpolation.Padding = new System.Windows.Forms.Padding(5);
            this.groupBoxInterpolation.Size = new System.Drawing.Size(306, 963);
            this.groupBoxInterpolation.TabIndex = 1;
            this.groupBoxInterpolation.TabStop = false;
            this.groupBoxInterpolation.Text = "Interpolation";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Controls.Add(this.numericUpDownInterpolationStart, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.numericUpDownInterpolationIncr, 1, 2);
            this.tableLayoutPanel7.Controls.Add(this.numericUpDownInterpolationEnd, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.label12, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.label13, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.buttonUseCoefficients, 0, 3);
            this.tableLayoutPanel7.Controls.Add(this.buttonExcitation, 0, 4);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(5, 37);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 5;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(296, 921);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // numericUpDownInterpolationStart
            // 
            this.numericUpDownInterpolationStart.Location = new System.Drawing.Point(77, 5);
            this.numericUpDownInterpolationStart.Margin = new System.Windows.Forms.Padding(5);
            this.numericUpDownInterpolationStart.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numericUpDownInterpolationStart.Name = "numericUpDownInterpolationStart";
            this.numericUpDownInterpolationStart.Size = new System.Drawing.Size(143, 39);
            this.numericUpDownInterpolationStart.TabIndex = 14;
            this.numericUpDownInterpolationStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownInterpolationStart.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // numericUpDownInterpolationIncr
            // 
            this.numericUpDownInterpolationIncr.DecimalPlaces = 2;
            this.numericUpDownInterpolationIncr.Location = new System.Drawing.Point(77, 103);
            this.numericUpDownInterpolationIncr.Margin = new System.Windows.Forms.Padding(5);
            this.numericUpDownInterpolationIncr.Name = "numericUpDownInterpolationIncr";
            this.numericUpDownInterpolationIncr.Size = new System.Drawing.Size(143, 39);
            this.numericUpDownInterpolationIncr.TabIndex = 16;
            this.numericUpDownInterpolationIncr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownInterpolationIncr.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownInterpolationEnd
            // 
            this.numericUpDownInterpolationEnd.Location = new System.Drawing.Point(77, 54);
            this.numericUpDownInterpolationEnd.Margin = new System.Windows.Forms.Padding(5);
            this.numericUpDownInterpolationEnd.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numericUpDownInterpolationEnd.Name = "numericUpDownInterpolationEnd";
            this.numericUpDownInterpolationEnd.Size = new System.Drawing.Size(143, 39);
            this.numericUpDownInterpolationEnd.TabIndex = 15;
            this.numericUpDownInterpolationEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownInterpolationEnd.Value = new decimal(new int[] {
            2400,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 8);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 32);
            this.label10.TabIndex = 17;
            this.label10.Text = "Start";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 57);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 32);
            this.label12.TabIndex = 18;
            this.label12.Text = "End";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 106);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 32);
            this.label13.TabIndex = 19;
            this.label13.Text = "Incr";
            // 
            // buttonUseCoefficients
            // 
            this.tableLayoutPanel7.SetColumnSpan(this.buttonUseCoefficients, 2);
            this.buttonUseCoefficients.Location = new System.Drawing.Point(5, 152);
            this.buttonUseCoefficients.Margin = new System.Windows.Forms.Padding(5);
            this.buttonUseCoefficients.Name = "buttonUseCoefficients";
            this.buttonUseCoefficients.Size = new System.Drawing.Size(200, 40);
            this.buttonUseCoefficients.TabIndex = 20;
            this.buttonUseCoefficients.Text = "Set Wavecal";
            this.buttonUseCoefficients.UseVisualStyleBackColor = true;
            this.buttonUseCoefficients.Click += new System.EventHandler(this.buttonUseCoefficients_Click);
            // 
            // buttonExcitation
            // 
            this.tableLayoutPanel7.SetColumnSpan(this.buttonExcitation, 2);
            this.buttonExcitation.Location = new System.Drawing.Point(3, 200);
            this.buttonExcitation.Name = "buttonExcitation";
            this.buttonExcitation.Size = new System.Drawing.Size(200, 40);
            this.buttonExcitation.TabIndex = 21;
            this.buttonExcitation.Text = "Set Excitation";
            this.toolTip1.SetToolTip(this.buttonExcitation, "If specified, interpolated axis will be in wavenumber rather than wavelength spac" +
        "e");
            this.buttonExcitation.UseVisualStyleBackColor = true;
            this.buttonExcitation.Click += new System.EventHandler(this.buttonExcitation_Click);
            // 
            // splitContainerFilterVsAttributeTables
            // 
            this.splitContainerFilterVsAttributeTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFilterVsAttributeTables.Location = new System.Drawing.Point(0, 0);
            this.splitContainerFilterVsAttributeTables.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerFilterVsAttributeTables.Name = "splitContainerFilterVsAttributeTables";
            this.splitContainerFilterVsAttributeTables.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerFilterVsAttributeTables.Panel1
            // 
            this.splitContainerFilterVsAttributeTables.Panel1.Controls.Add(this.groupBox5);
            // 
            // splitContainerFilterVsAttributeTables.Panel2
            // 
            this.splitContainerFilterVsAttributeTables.Panel2.Controls.Add(this.groupBox6);
            this.splitContainerFilterVsAttributeTables.Size = new System.Drawing.Size(1224, 977);
            this.splitContainerFilterVsAttributeTables.SplitterDistance = 418;
            this.splitContainerFilterVsAttributeTables.SplitterWidth = 3;
            this.splitContainerFilterVsAttributeTables.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataGridViewFilters);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(1224, 418);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Filters on Selected JSON Files";
            // 
            // dataGridViewFilters
            // 
            this.dataGridViewFilters.AllowUserToAddRows = false;
            this.dataGridViewFilters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewFilters.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewFilters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFilters.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewFilters.Location = new System.Drawing.Point(3, 34);
            this.dataGridViewFilters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewFilters.MultiSelect = false;
            this.dataGridViewFilters.Name = "dataGridViewFilters";
            this.dataGridViewFilters.RowHeadersVisible = false;
            this.dataGridViewFilters.RowHeadersWidth = 82;
            this.dataGridViewFilters.RowTemplate.Height = 41;
            this.dataGridViewFilters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFilters.ShowEditingIcon = false;
            this.dataGridViewFilters.Size = new System.Drawing.Size(1218, 382);
            this.dataGridViewFilters.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dataGridViewAttributes);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Size = new System.Drawing.Size(1224, 556);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Attributes to Extract";
            // 
            // dataGridViewAttributes
            // 
            this.dataGridViewAttributes.AllowUserToAddRows = false;
            this.dataGridViewAttributes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewAttributes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAttributes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewAttributes.Location = new System.Drawing.Point(3, 34);
            this.dataGridViewAttributes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewAttributes.MultiSelect = false;
            this.dataGridViewAttributes.Name = "dataGridViewAttributes";
            this.dataGridViewAttributes.RowHeadersVisible = false;
            this.dataGridViewAttributes.RowHeadersWidth = 82;
            this.dataGridViewAttributes.RowTemplate.Height = 41;
            this.dataGridViewAttributes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAttributes.ShowEditingIcon = false;
            this.dataGridViewAttributes.Size = new System.Drawing.Size(1218, 520);
            this.dataGridViewAttributes.TabIndex = 0;
            this.dataGridViewAttributes.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridViewAttributes_RowsRemoved);
            // 
            // tableLayoutPanelProgressAndLog
            // 
            this.tableLayoutPanelProgressAndLog.AutoSize = true;
            this.tableLayoutPanelProgressAndLog.ColumnCount = 1;
            this.tableLayoutPanelProgressAndLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelProgressAndLog.Controls.Add(this.groupBoxEventLog, 0, 1);
            this.tableLayoutPanelProgressAndLog.Controls.Add(this.progressBarStatus, 0, 0);
            this.tableLayoutPanelProgressAndLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelProgressAndLog.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelProgressAndLog.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanelProgressAndLog.Name = "tableLayoutPanelProgressAndLog";
            this.tableLayoutPanelProgressAndLog.RowCount = 2;
            this.tableLayoutPanelProgressAndLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanelProgressAndLog.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelProgressAndLog.Size = new System.Drawing.Size(2564, 327);
            this.tableLayoutPanelProgressAndLog.TabIndex = 1;
            // 
            // groupBoxEventLog
            // 
            this.groupBoxEventLog.Controls.Add(this.textBoxEventLog);
            this.groupBoxEventLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxEventLog.Location = new System.Drawing.Point(3, 66);
            this.groupBoxEventLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxEventLog.Name = "groupBoxEventLog";
            this.groupBoxEventLog.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxEventLog.Size = new System.Drawing.Size(2670, 259);
            this.groupBoxEventLog.TabIndex = 0;
            this.groupBoxEventLog.TabStop = false;
            this.groupBoxEventLog.Text = "Event Log";
            // 
            // textBoxEventLog
            // 
            this.textBoxEventLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxEventLog.Location = new System.Drawing.Point(3, 34);
            this.textBoxEventLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxEventLog.Multiline = true;
            this.textBoxEventLog.Name = "textBoxEventLog";
            this.textBoxEventLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxEventLog.Size = new System.Drawing.Size(2664, 223);
            this.textBoxEventLog.TabIndex = 0;
            // 
            // progressBarStatus
            // 
            this.progressBarStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBarStatus.Location = new System.Drawing.Point(6, 6);
            this.progressBarStatus.Margin = new System.Windows.Forms.Padding(6);
            this.progressBarStatus.Name = "progressBarStatus";
            this.progressBarStatus.Size = new System.Drawing.Size(2664, 52);
            this.progressBarStatus.TabIndex = 0;
            // 
            // openFileDialogSample
            // 
            this.openFileDialogSample.DefaultExt = "json";
            this.openFileDialogSample.Filter = "JSON files|*.json;*.json.gz";
            this.openFileDialogSample.ShowReadOnly = true;
            // 
            // openFileDialogInputFiles
            // 
            this.openFileDialogInputFiles.DefaultExt = "json";
            this.openFileDialogInputFiles.Filter = "JSON files|*.json;*.json.gz";
            this.openFileDialogInputFiles.Multiselect = true;
            this.openFileDialogInputFiles.ShowReadOnly = true;
            this.openFileDialogInputFiles.SupportMultiDottedExtensions = true;
            // 
            // backgroundWorkerExtraction
            // 
            this.backgroundWorkerExtraction.WorkerReportsProgress = true;
            this.backgroundWorkerExtraction.WorkerSupportsCancellation = true;
            // 
            // saveFileDialogExtract
            // 
            this.saveFileDialogExtract.DefaultExt = "csv";
            this.saveFileDialogExtract.Filter = "CSV Files (*.csv)|*.csv";
            this.saveFileDialogExtract.Title = "Run Extract";
            // 
            // tabPageInterpolation
            // 
            this.tabPageInterpolation.Controls.Add(this.groupBoxInterpolation);
            this.tabPageInterpolation.Location = new System.Drawing.Point(43, 4);
            this.tabPageInterpolation.Name = "tabPageInterpolation";
            this.tabPageInterpolation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInterpolation.Size = new System.Drawing.Size(312, 969);
            this.tabPageInterpolation.TabIndex = 5;
            this.tabPageInterpolation.Text = "Interpolation";
            this.tabPageInterpolation.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2564, 1307);
            this.Controls.Add(this.splitContainerTopVsBottom);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "JSON Extractor";
            this.splitContainerTopVsBottom.Panel1.ResumeLayout(false);
            this.splitContainerTopVsBottom.Panel2.ResumeLayout(false);
            this.splitContainerTopVsBottom.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTopVsBottom)).EndInit();
            this.splitContainerTopVsBottom.ResumeLayout(false);
            this.splitContainerTabsVsJSONOnward.Panel1.ResumeLayout(false);
            this.splitContainerTabsVsJSONOnward.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTabsVsJSONOnward)).EndInit();
            this.splitContainerTabsVsJSONOnward.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageInput.ResumeLayout(false);
            this.tabPageInput.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageExtract.ResumeLayout(false);
            this.tabPageExtract.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPageConfig.ResumeLayout(false);
            this.tabPageConfig.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tabPageAWS.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.splitContainerJSONandButtonsVsDatagrids.Panel1.ResumeLayout(false);
            this.splitContainerJSONandButtonsVsDatagrids.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerJSONandButtonsVsDatagrids)).EndInit();
            this.splitContainerJSONandButtonsVsDatagrids.ResumeLayout(false);
            this.splitContainerTreeVsOpts.Panel1.ResumeLayout(false);
            this.splitContainerTreeVsOpts.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTreeVsOpts)).EndInit();
            this.splitContainerTreeVsOpts.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExtractAttributePrecision)).EndInit();
            this.groupBoxInterpolation.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterpolationStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterpolationIncr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterpolationEnd)).EndInit();
            this.splitContainerFilterVsAttributeTables.Panel1.ResumeLayout(false);
            this.splitContainerFilterVsAttributeTables.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFilterVsAttributeTables)).EndInit();
            this.splitContainerFilterVsAttributeTables.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilters)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttributes)).EndInit();
            this.tableLayoutPanelProgressAndLog.ResumeLayout(false);
            this.groupBoxEventLog.ResumeLayout(false);
            this.groupBoxEventLog.PerformLayout();
            this.tabPageInterpolation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerTopVsBottom;
        private System.Windows.Forms.GroupBox groupBoxEventLog;
        private System.Windows.Forms.TextBox textBoxEventLog;
        private System.Windows.Forms.SplitContainer splitContainerTabsVsJSONOnward;
        private System.Windows.Forms.SplitContainer splitContainerJSONandButtonsVsDatagrids;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.SplitContainer splitContainerFilterVsAttributeTables;
        private System.Windows.Forms.SplitContainer splitContainerTreeVsOpts;
        private System.Windows.Forms.TreeView treeViewJSON;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dataGridViewFilters;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dataGridViewAttributes;
        private System.Windows.Forms.ComboBox comboBoxFilterType;
        private System.Windows.Forms.Button buttonLoadSample;
        private System.Windows.Forms.Button buttonSelectFiles;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonSaveConfig;
        private System.Windows.Forms.Button buttonLoadConfig;
        private System.Windows.Forms.Button buttonAddExtractAttribute;
        private System.Windows.Forms.ComboBox comboBoxExtractAttributeAggregateType;
        private System.Windows.Forms.Button buttonExtractAttributeUp;
        private System.Windows.Forms.Button buttonExtractAttributeDown;
        private System.Windows.Forms.Button buttonFilterAdd;
        private System.Windows.Forms.TextBox textBoxExtractAttributeLabel;
        private System.Windows.Forms.TextBox textBoxExtractAttributeDefault;
        private System.Windows.Forms.OpenFileDialog openFileDialogSample;
        private System.Windows.Forms.OpenFileDialog openFileDialogInputFiles;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBoxFilterPattern;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label labelSelectedCount;
        private System.Windows.Forms.Label labelProcessedCount;
        private System.Windows.Forms.Label labelFilteredCount;
        private System.Windows.Forms.Label labelExtractedCount;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button buttonSelectInputDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogInputDir;
        private System.ComponentModel.BackgroundWorker backgroundWorkerExtraction;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox textBoxS3Bucket;
        private System.Windows.Forms.TextBox textBoxS3AccessKey;
        private System.Windows.Forms.TextBox textBoxS3SecretKey;
        private System.Windows.Forms.Button buttonS3CacheDir;
        private System.Windows.Forms.Button buttonS3StartSync;
        private System.Windows.Forms.ProgressBar progressBarStatus;
        private System.Windows.Forms.CheckBox checkBoxFilterNegate;
        private System.Windows.Forms.SaveFileDialog saveFileDialogExtract;
        private System.Windows.Forms.CheckBox checkBoxFilterSufficient;
        private System.Windows.Forms.Label labelSkippedCount;
        private System.Windows.Forms.CheckBox checkBoxNullOk;
        private System.Windows.Forms.NumericUpDown numericUpDownExtractAttributePrecision;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageInput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabPage tabPageExtract;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabPage tabPageConfig;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TabPage tabPageAWS;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelProgressAndLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxDedupeFilenames;
        private System.Windows.Forms.CheckBox checkBoxDedupeFilenames;
        private System.Windows.Forms.Label labelDedupedCount;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxDedupeWithin;
        private System.Windows.Forms.TextBox textBoxFilterWithin;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBoxInterpolate;
        private System.Windows.Forms.GroupBox groupBoxInterpolation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.NumericUpDown numericUpDownInterpolationStart;
        private System.Windows.Forms.NumericUpDown numericUpDownInterpolationIncr;
        private System.Windows.Forms.NumericUpDown numericUpDownInterpolationEnd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonUseCoefficients;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonExcitation;
        private System.Windows.Forms.TabPage tabPageInterpolation;
    }
}

