
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
            this.splitContainerAvsBC = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageInput = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLoadSample = new System.Windows.Forms.Button();
            this.buttonSelectFiles = new System.Windows.Forms.Button();
            this.buttonSelectInputDir = new System.Windows.Forms.Button();
            this.tabPageExtract = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelExtractedCount = new System.Windows.Forms.Label();
            this.labelSkippedCount = new System.Windows.Forms.Label();
            this.labelProcessedCount = new System.Windows.Forms.Label();
            this.labelSelectedCount = new System.Windows.Forms.Label();
            this.labelFilteredCount = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
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
            this.splitContainerBvsC = new System.Windows.Forms.SplitContainer();
            this.splitContainerTreeVsOpts = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.treeViewJSON = new System.Windows.Forms.TreeView();
            this.splitContainerFilterVsAttrControls = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxFilterPattern = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxFilterType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxNullOk = new System.Windows.Forms.CheckBox();
            this.checkBoxFilterNegate = new System.Windows.Forms.CheckBox();
            this.checkBoxFilterSufficient = new System.Windows.Forms.CheckBox();
            this.buttonFilterAdd = new System.Windows.Forms.Button();
            this.buttonFilterRemove = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonExtractAttributeDown = new System.Windows.Forms.Button();
            this.buttonExtractAttributeUp = new System.Windows.Forms.Button();
            this.buttonExtractAttributeRemove = new System.Windows.Forms.Button();
            this.buttonAddExtractAttribute = new System.Windows.Forms.Button();
            this.numericUpDownExtractAttributePrecision = new System.Windows.Forms.NumericUpDown();
            this.textBoxExtractAttributeDefault = new System.Windows.Forms.TextBox();
            this.comboBoxExtractAttributeAggregateType = new System.Windows.Forms.ComboBox();
            this.textBoxExtractAttributeLabel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTopVsBottom)).BeginInit();
            this.splitContainerTopVsBottom.Panel1.SuspendLayout();
            this.splitContainerTopVsBottom.Panel2.SuspendLayout();
            this.splitContainerTopVsBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAvsBC)).BeginInit();
            this.splitContainerAvsBC.Panel1.SuspendLayout();
            this.splitContainerAvsBC.Panel2.SuspendLayout();
            this.splitContainerAvsBC.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageInput.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPageExtract.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPageConfig.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPageAWS.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBvsC)).BeginInit();
            this.splitContainerBvsC.Panel1.SuspendLayout();
            this.splitContainerBvsC.Panel2.SuspendLayout();
            this.splitContainerBvsC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTreeVsOpts)).BeginInit();
            this.splitContainerTreeVsOpts.Panel1.SuspendLayout();
            this.splitContainerTreeVsOpts.Panel2.SuspendLayout();
            this.splitContainerTreeVsOpts.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFilterVsAttrControls)).BeginInit();
            this.splitContainerFilterVsAttrControls.Panel1.SuspendLayout();
            this.splitContainerFilterVsAttrControls.Panel2.SuspendLayout();
            this.splitContainerFilterVsAttrControls.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExtractAttributePrecision)).BeginInit();
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
            this.SuspendLayout();
            // 
            // splitContainerTopVsBottom
            // 
            this.splitContainerTopVsBottom.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainerTopVsBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTopVsBottom.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTopVsBottom.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.splitContainerTopVsBottom.Name = "splitContainerTopVsBottom";
            this.splitContainerTopVsBottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTopVsBottom.Panel1
            // 
            this.splitContainerTopVsBottom.Panel1.Controls.Add(this.splitContainerAvsBC);
            // 
            // splitContainerTopVsBottom.Panel2
            // 
            this.splitContainerTopVsBottom.Panel2.Controls.Add(this.tableLayoutPanelProgressAndLog);
            this.splitContainerTopVsBottom.Size = new System.Drawing.Size(1646, 796);
            this.splitContainerTopVsBottom.SplitterDistance = 597;
            this.splitContainerTopVsBottom.SplitterWidth = 2;
            this.splitContainerTopVsBottom.TabIndex = 0;
            // 
            // splitContainerAvsBC
            // 
            this.splitContainerAvsBC.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainerAvsBC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerAvsBC.Location = new System.Drawing.Point(0, 0);
            this.splitContainerAvsBC.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.splitContainerAvsBC.Name = "splitContainerAvsBC";
            // 
            // splitContainerAvsBC.Panel1
            // 
            this.splitContainerAvsBC.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainerAvsBC.Panel2
            // 
            this.splitContainerAvsBC.Panel2.Controls.Add(this.splitContainerBvsC);
            this.splitContainerAvsBC.Size = new System.Drawing.Size(1646, 597);
            this.splitContainerAvsBC.SplitterDistance = 233;
            this.splitContainerAvsBC.SplitterWidth = 2;
            this.splitContainerAvsBC.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPageInput);
            this.tabControl1.Controls.Add(this.tabPageExtract);
            this.tabControl1.Controls.Add(this.tabPageConfig);
            this.tabControl1.Controls.Add(this.tabPageAWS);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(233, 597);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageInput
            // 
            this.tabPageInput.Controls.Add(this.groupBox10);
            this.tabPageInput.Location = new System.Drawing.Point(30, 4);
            this.tabPageInput.Name = "tabPageInput";
            this.tabPageInput.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInput.Size = new System.Drawing.Size(199, 589);
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
            this.groupBox10.Location = new System.Drawing.Point(3, 3);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox10.MinimumSize = new System.Drawing.Size(114, 133);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox10.Size = new System.Drawing.Size(193, 583);
            this.groupBox10.TabIndex = 7;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Input Files";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.buttonLoadSample, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonSelectFiles, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.buttonSelectInputDir, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 24);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(185, 555);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // buttonLoadSample
            // 
            this.buttonLoadSample.Location = new System.Drawing.Point(2, 1);
            this.buttonLoadSample.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonLoadSample.Name = "buttonLoadSample";
            this.buttonLoadSample.Size = new System.Drawing.Size(106, 29);
            this.buttonLoadSample.TabIndex = 0;
            this.buttonLoadSample.Text = "Load Sample";
            this.buttonLoadSample.UseVisualStyleBackColor = true;
            this.buttonLoadSample.Click += new System.EventHandler(this.buttonLoadSample_Click);
            // 
            // buttonSelectFiles
            // 
            this.buttonSelectFiles.Location = new System.Drawing.Point(2, 69);
            this.buttonSelectFiles.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonSelectFiles.Name = "buttonSelectFiles";
            this.buttonSelectFiles.Size = new System.Drawing.Size(106, 29);
            this.buttonSelectFiles.TabIndex = 1;
            this.buttonSelectFiles.Text = "Select Files";
            this.buttonSelectFiles.UseVisualStyleBackColor = true;
            // 
            // buttonSelectInputDir
            // 
            this.buttonSelectInputDir.Location = new System.Drawing.Point(4, 35);
            this.buttonSelectInputDir.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSelectInputDir.Name = "buttonSelectInputDir";
            this.buttonSelectInputDir.Size = new System.Drawing.Size(106, 29);
            this.buttonSelectInputDir.TabIndex = 2;
            this.buttonSelectInputDir.Text = "Select Folder";
            this.buttonSelectInputDir.UseVisualStyleBackColor = true;
            this.buttonSelectInputDir.Click += new System.EventHandler(this.buttonSelectInputDir_Click);
            // 
            // tabPageExtract
            // 
            this.tabPageExtract.Controls.Add(this.groupBox8);
            this.tabPageExtract.Location = new System.Drawing.Point(30, 4);
            this.tabPageExtract.Name = "tabPageExtract";
            this.tabPageExtract.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExtract.Size = new System.Drawing.Size(199, 589);
            this.tabPageExtract.TabIndex = 2;
            this.tabPageExtract.Text = "Extract";
            this.tabPageExtract.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.AutoSize = true;
            this.groupBox8.Controls.Add(this.tableLayoutPanel1);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(3, 3);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox8.MinimumSize = new System.Drawing.Size(114, 156);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox8.Size = new System.Drawing.Size(193, 583);
            this.groupBox8.TabIndex = 5;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Extract";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelExtractedCount, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelSkippedCount, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelProcessedCount, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelSelectedCount, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelFilteredCount, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonStart, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(185, 555);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // labelExtractedCount
            // 
            this.labelExtractedCount.AutoSize = true;
            this.labelExtractedCount.Location = new System.Drawing.Point(4, 111);
            this.labelExtractedCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelExtractedCount.MinimumSize = new System.Drawing.Size(86, 20);
            this.labelExtractedCount.Name = "labelExtractedCount";
            this.labelExtractedCount.Size = new System.Drawing.Size(86, 20);
            this.labelExtractedCount.TabIndex = 5;
            this.labelExtractedCount.Text = "Extracted: 0";
            // 
            // labelSkippedCount
            // 
            this.labelSkippedCount.AutoSize = true;
            this.labelSkippedCount.Location = new System.Drawing.Point(2, 91);
            this.labelSkippedCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSkippedCount.Name = "labelSkippedCount";
            this.labelSkippedCount.Size = new System.Drawing.Size(78, 20);
            this.labelSkippedCount.TabIndex = 7;
            this.labelSkippedCount.Text = "Skipped: 0";
            // 
            // labelProcessedCount
            // 
            this.labelProcessedCount.AutoSize = true;
            this.labelProcessedCount.Location = new System.Drawing.Point(4, 71);
            this.labelProcessedCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProcessedCount.MinimumSize = new System.Drawing.Size(86, 20);
            this.labelProcessedCount.Name = "labelProcessedCount";
            this.labelProcessedCount.Size = new System.Drawing.Size(90, 20);
            this.labelProcessedCount.TabIndex = 3;
            this.labelProcessedCount.Text = "Processed: 0";
            // 
            // labelSelectedCount
            // 
            this.labelSelectedCount.AutoSize = true;
            this.labelSelectedCount.Location = new System.Drawing.Point(4, 51);
            this.labelSelectedCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSelectedCount.MinimumSize = new System.Drawing.Size(86, 20);
            this.labelSelectedCount.Name = "labelSelectedCount";
            this.labelSelectedCount.Size = new System.Drawing.Size(86, 20);
            this.labelSelectedCount.TabIndex = 6;
            this.labelSelectedCount.Text = "Selected: 0";
            // 
            // labelFilteredCount
            // 
            this.labelFilteredCount.AutoSize = true;
            this.labelFilteredCount.Location = new System.Drawing.Point(4, 31);
            this.labelFilteredCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFilteredCount.MinimumSize = new System.Drawing.Size(86, 20);
            this.labelFilteredCount.Name = "labelFilteredCount";
            this.labelFilteredCount.Size = new System.Drawing.Size(86, 20);
            this.labelFilteredCount.TabIndex = 4;
            this.labelFilteredCount.Text = "Filtered: 0";
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(2, 1);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(100, 29);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.Controls.Add(this.groupBox9);
            this.tabPageConfig.Location = new System.Drawing.Point(30, 4);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfig.Size = new System.Drawing.Size(199, 589);
            this.tabPageConfig.TabIndex = 3;
            this.tabPageConfig.Text = "Configuration";
            this.tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.AutoSize = true;
            this.groupBox9.Controls.Add(this.tableLayoutPanel3);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox9.Location = new System.Drawing.Point(3, 3);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox9.MinimumSize = new System.Drawing.Size(114, 100);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox9.Size = new System.Drawing.Size(193, 583);
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
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 24);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(185, 555);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // buttonSaveConfig
            // 
            this.buttonSaveConfig.Location = new System.Drawing.Point(2, 1);
            this.buttonSaveConfig.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonSaveConfig.Name = "buttonSaveConfig";
            this.buttonSaveConfig.Size = new System.Drawing.Size(100, 29);
            this.buttonSaveConfig.TabIndex = 3;
            this.buttonSaveConfig.Text = "Save Config";
            this.buttonSaveConfig.UseVisualStyleBackColor = true;
            this.buttonSaveConfig.Click += new System.EventHandler(this.buttonSaveConfig_Click);
            // 
            // buttonLoadConfig
            // 
            this.buttonLoadConfig.Location = new System.Drawing.Point(2, 32);
            this.buttonLoadConfig.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonLoadConfig.Name = "buttonLoadConfig";
            this.buttonLoadConfig.Size = new System.Drawing.Size(100, 29);
            this.buttonLoadConfig.TabIndex = 4;
            this.buttonLoadConfig.Text = "Load Config";
            this.buttonLoadConfig.UseVisualStyleBackColor = true;
            this.buttonLoadConfig.Click += new System.EventHandler(this.buttonLoadConfig_Click);
            // 
            // tabPageAWS
            // 
            this.tabPageAWS.Controls.Add(this.groupBox11);
            this.tabPageAWS.Location = new System.Drawing.Point(30, 4);
            this.tabPageAWS.Name = "tabPageAWS";
            this.tabPageAWS.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAWS.Size = new System.Drawing.Size(199, 589);
            this.tabPageAWS.TabIndex = 0;
            this.tabPageAWS.Text = "AWS";
            this.tabPageAWS.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.tableLayoutPanel4);
            this.groupBox11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox11.Location = new System.Drawing.Point(3, 3);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox11.Size = new System.Drawing.Size(193, 583);
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
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 24);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(185, 555);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // textBoxS3SecretKey
            // 
            this.textBoxS3SecretKey.Location = new System.Drawing.Point(63, 74);
            this.textBoxS3SecretKey.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxS3SecretKey.Name = "textBoxS3SecretKey";
            this.textBoxS3SecretKey.Size = new System.Drawing.Size(98, 27);
            this.textBoxS3SecretKey.TabIndex = 2;
            this.textBoxS3SecretKey.Text = "secretKey";
            this.toolTip1.SetToolTip(this.textBoxS3SecretKey, "AWS Secret Key");
            this.textBoxS3SecretKey.UseSystemPasswordChar = true;
            this.textBoxS3SecretKey.TextChanged += new System.EventHandler(this.textBoxS3SecretKey_TextChanged);
            // 
            // textBoxS3AccessKey
            // 
            this.textBoxS3AccessKey.Location = new System.Drawing.Point(63, 39);
            this.textBoxS3AccessKey.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxS3AccessKey.Name = "textBoxS3AccessKey";
            this.textBoxS3AccessKey.Size = new System.Drawing.Size(98, 27);
            this.textBoxS3AccessKey.TabIndex = 1;
            this.textBoxS3AccessKey.Text = "accessKey";
            this.toolTip1.SetToolTip(this.textBoxS3AccessKey, "AWS Access Key");
            this.textBoxS3AccessKey.TextChanged += new System.EventHandler(this.textBoxS3AccessKey_TextChanged);
            // 
            // textBoxS3Bucket
            // 
            this.textBoxS3Bucket.Location = new System.Drawing.Point(63, 4);
            this.textBoxS3Bucket.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxS3Bucket.Name = "textBoxS3Bucket";
            this.textBoxS3Bucket.Size = new System.Drawing.Size(98, 27);
            this.textBoxS3Bucket.TabIndex = 0;
            this.textBoxS3Bucket.Text = "s3bucket";
            this.toolTip1.SetToolTip(this.textBoxS3Bucket, "AWS S3 bucket");
            this.textBoxS3Bucket.TextChanged += new System.EventHandler(this.textBoxS3Bucket_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bucket";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Access";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Secret";
            // 
            // buttonS3CacheDir
            // 
            this.buttonS3CacheDir.Location = new System.Drawing.Point(63, 109);
            this.buttonS3CacheDir.Margin = new System.Windows.Forms.Padding(4);
            this.buttonS3CacheDir.Name = "buttonS3CacheDir";
            this.buttonS3CacheDir.Size = new System.Drawing.Size(98, 31);
            this.buttonS3CacheDir.TabIndex = 3;
            this.buttonS3CacheDir.Text = "Cache Dir";
            this.buttonS3CacheDir.UseVisualStyleBackColor = true;
            this.buttonS3CacheDir.Click += new System.EventHandler(this.buttonS3CacheDir_Click);
            // 
            // buttonS3StartSync
            // 
            this.buttonS3StartSync.Location = new System.Drawing.Point(63, 148);
            this.buttonS3StartSync.Margin = new System.Windows.Forms.Padding(4);
            this.buttonS3StartSync.Name = "buttonS3StartSync";
            this.buttonS3StartSync.Size = new System.Drawing.Size(98, 31);
            this.buttonS3StartSync.TabIndex = 4;
            this.buttonS3StartSync.Text = "Start Sync";
            this.buttonS3StartSync.UseVisualStyleBackColor = true;
            this.buttonS3StartSync.Click += new System.EventHandler(this.buttonS3StartSync_Click);
            // 
            // splitContainerBvsC
            // 
            this.splitContainerBvsC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerBvsC.Location = new System.Drawing.Point(0, 0);
            this.splitContainerBvsC.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.splitContainerBvsC.Name = "splitContainerBvsC";
            // 
            // splitContainerBvsC.Panel1
            // 
            this.splitContainerBvsC.Panel1.Controls.Add(this.splitContainerTreeVsOpts);
            // 
            // splitContainerBvsC.Panel2
            // 
            this.splitContainerBvsC.Panel2.Controls.Add(this.splitContainerFilterVsAttributeTables);
            this.splitContainerBvsC.Size = new System.Drawing.Size(1411, 597);
            this.splitContainerBvsC.SplitterDistance = 627;
            this.splitContainerBvsC.SplitterWidth = 2;
            this.splitContainerBvsC.TabIndex = 0;
            // 
            // splitContainerTreeVsOpts
            // 
            this.splitContainerTreeVsOpts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTreeVsOpts.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTreeVsOpts.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.splitContainerTreeVsOpts.Name = "splitContainerTreeVsOpts";
            // 
            // splitContainerTreeVsOpts.Panel1
            // 
            this.splitContainerTreeVsOpts.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainerTreeVsOpts.Panel2
            // 
            this.splitContainerTreeVsOpts.Panel2.Controls.Add(this.splitContainerFilterVsAttrControls);
            this.splitContainerTreeVsOpts.Size = new System.Drawing.Size(627, 597);
            this.splitContainerTreeVsOpts.SplitterDistance = 415;
            this.splitContainerTreeVsOpts.SplitterWidth = 2;
            this.splitContainerTreeVsOpts.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.treeViewJSON);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox3.Size = new System.Drawing.Size(415, 597);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "JSON Attribute Structure";
            // 
            // treeViewJSON
            // 
            this.treeViewJSON.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewJSON.Location = new System.Drawing.Point(2, 21);
            this.treeViewJSON.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.treeViewJSON.MinimumSize = new System.Drawing.Size(200, 200);
            this.treeViewJSON.Name = "treeViewJSON";
            this.treeViewJSON.Size = new System.Drawing.Size(411, 575);
            this.treeViewJSON.TabIndex = 0;
            this.treeViewJSON.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewJSON_AfterSelect);
            this.treeViewJSON.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewJSON_NodeMouseDoubleClick);
            // 
            // splitContainerFilterVsAttrControls
            // 
            this.splitContainerFilterVsAttrControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFilterVsAttrControls.Location = new System.Drawing.Point(0, 0);
            this.splitContainerFilterVsAttrControls.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.splitContainerFilterVsAttrControls.Name = "splitContainerFilterVsAttrControls";
            this.splitContainerFilterVsAttrControls.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerFilterVsAttrControls.Panel1
            // 
            this.splitContainerFilterVsAttrControls.Panel1.Controls.Add(this.groupBox4);
            // 
            // splitContainerFilterVsAttrControls.Panel2
            // 
            this.splitContainerFilterVsAttrControls.Panel2.Controls.Add(this.groupBox7);
            this.splitContainerFilterVsAttrControls.Size = new System.Drawing.Size(210, 597);
            this.splitContainerFilterVsAttrControls.SplitterDistance = 295;
            this.splitContainerFilterVsAttrControls.SplitterWidth = 2;
            this.splitContainerFilterVsAttrControls.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel5);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox4.Size = new System.Drawing.Size(210, 295);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filter";
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
            this.tableLayoutPanel5.Controls.Add(this.checkBoxNullOk, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.checkBoxFilterNegate, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.checkBoxFilterSufficient, 1, 4);
            this.tableLayoutPanel5.Controls.Add(this.buttonFilterAdd, 1, 5);
            this.tableLayoutPanel5.Controls.Add(this.buttonFilterRemove, 1, 6);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(2, 21);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 7;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(206, 273);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // textBoxFilterPattern
            // 
            this.textBoxFilterPattern.Location = new System.Drawing.Point(55, 4);
            this.textBoxFilterPattern.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFilterPattern.Name = "textBoxFilterPattern";
            this.textBoxFilterPattern.Size = new System.Drawing.Size(114, 27);
            this.textBoxFilterPattern.TabIndex = 3;
            this.textBoxFilterPattern.Text = "pattern";
            this.toolTip1.SetToolTip(this.textBoxFilterPattern, "The value or pattern used for matching the field");
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Value";
            // 
            // comboBoxFilterType
            // 
            this.comboBoxFilterType.FormattingEnabled = true;
            this.comboBoxFilterType.Items.AddRange(new object[] {
            "NumberEquals",
            "LessThanEqualTo",
            "GreaterThanEqualTo",
            "Empty",
            "NonEmpty",
            "Regex"});
            this.comboBoxFilterType.Location = new System.Drawing.Point(53, 36);
            this.comboBoxFilterType.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.comboBoxFilterType.Name = "comboBoxFilterType";
            this.comboBoxFilterType.Size = new System.Drawing.Size(123, 28);
            this.comboBoxFilterType.TabIndex = 0;
            this.toolTip1.SetToolTip(this.comboBoxFilterType, "Filter type");
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Type";
            // 
            // checkBoxNullOk
            // 
            this.checkBoxNullOk.AutoSize = true;
            this.checkBoxNullOk.Location = new System.Drawing.Point(53, 67);
            this.checkBoxNullOk.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxNullOk.Name = "checkBoxNullOk";
            this.checkBoxNullOk.Size = new System.Drawing.Size(80, 24);
            this.checkBoxNullOk.TabIndex = 6;
            this.checkBoxNullOk.Text = "Null Ok";
            this.toolTip1.SetToolTip(this.checkBoxNullOk, "This filter will PASS if input field is empty");
            this.checkBoxNullOk.UseVisualStyleBackColor = true;
            // 
            // checkBoxFilterNegate
            // 
            this.checkBoxFilterNegate.AutoSize = true;
            this.checkBoxFilterNegate.Location = new System.Drawing.Point(53, 95);
            this.checkBoxFilterNegate.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxFilterNegate.Name = "checkBoxFilterNegate";
            this.checkBoxFilterNegate.Padding = new System.Windows.Forms.Padding(0, 0, 62, 0);
            this.checkBoxFilterNegate.Size = new System.Drawing.Size(142, 24);
            this.checkBoxFilterNegate.TabIndex = 4;
            this.checkBoxFilterNegate.Text = "Negate";
            this.toolTip1.SetToolTip(this.checkBoxFilterNegate, "Invert this filter");
            this.checkBoxFilterNegate.UseVisualStyleBackColor = true;
            // 
            // checkBoxFilterSufficient
            // 
            this.checkBoxFilterSufficient.AutoSize = true;
            this.checkBoxFilterSufficient.Location = new System.Drawing.Point(53, 123);
            this.checkBoxFilterSufficient.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxFilterSufficient.Name = "checkBoxFilterSufficient";
            this.checkBoxFilterSufficient.Padding = new System.Windows.Forms.Padding(0, 0, 31, 0);
            this.checkBoxFilterSufficient.Size = new System.Drawing.Size(124, 24);
            this.checkBoxFilterSufficient.TabIndex = 5;
            this.checkBoxFilterSufficient.Text = "Sufficient";
            this.toolTip1.SetToolTip(this.checkBoxFilterSufficient, "If this filter matches, the record will be extracted");
            this.checkBoxFilterSufficient.UseVisualStyleBackColor = true;
            // 
            // buttonFilterAdd
            // 
            this.buttonFilterAdd.Enabled = false;
            this.buttonFilterAdd.Location = new System.Drawing.Point(53, 150);
            this.buttonFilterAdd.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonFilterAdd.Name = "buttonFilterAdd";
            this.buttonFilterAdd.Size = new System.Drawing.Size(92, 29);
            this.buttonFilterAdd.TabIndex = 1;
            this.buttonFilterAdd.Text = "Add";
            this.toolTip1.SetToolTip(this.buttonFilterAdd, "Add this filter");
            this.buttonFilterAdd.UseVisualStyleBackColor = true;
            this.buttonFilterAdd.Click += new System.EventHandler(this.buttonFilterAdd_Click);
            // 
            // buttonFilterRemove
            // 
            this.buttonFilterRemove.Enabled = false;
            this.buttonFilterRemove.Location = new System.Drawing.Point(53, 181);
            this.buttonFilterRemove.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonFilterRemove.Name = "buttonFilterRemove";
            this.buttonFilterRemove.Size = new System.Drawing.Size(92, 29);
            this.buttonFilterRemove.TabIndex = 2;
            this.buttonFilterRemove.Text = "Remove";
            this.toolTip1.SetToolTip(this.buttonFilterRemove, "Remove the selected filter");
            this.buttonFilterRemove.UseVisualStyleBackColor = true;
            this.buttonFilterRemove.Click += new System.EventHandler(this.buttonFilterRemove_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tableLayoutPanel6);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox7.Size = new System.Drawing.Size(210, 300);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Attribute";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.buttonExtractAttributeDown, 1, 7);
            this.tableLayoutPanel6.Controls.Add(this.buttonExtractAttributeUp, 1, 6);
            this.tableLayoutPanel6.Controls.Add(this.buttonExtractAttributeRemove, 1, 5);
            this.tableLayoutPanel6.Controls.Add(this.buttonAddExtractAttribute, 1, 4);
            this.tableLayoutPanel6.Controls.Add(this.numericUpDownExtractAttributePrecision, 1, 3);
            this.tableLayoutPanel6.Controls.Add(this.textBoxExtractAttributeDefault, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.comboBoxExtractAttributeAggregateType, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.textBoxExtractAttributeLabel, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(2, 21);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 8;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(206, 278);
            this.tableLayoutPanel6.TabIndex = 3;
            // 
            // buttonExtractAttributeDown
            // 
            this.buttonExtractAttributeDown.Enabled = false;
            this.buttonExtractAttributeDown.Location = new System.Drawing.Point(88, 219);
            this.buttonExtractAttributeDown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonExtractAttributeDown.Name = "buttonExtractAttributeDown";
            this.buttonExtractAttributeDown.Size = new System.Drawing.Size(92, 29);
            this.buttonExtractAttributeDown.TabIndex = 5;
            this.buttonExtractAttributeDown.Text = "Down";
            this.toolTip1.SetToolTip(this.buttonExtractAttributeDown, "Move the selected field down");
            this.buttonExtractAttributeDown.UseVisualStyleBackColor = true;
            // 
            // buttonExtractAttributeUp
            // 
            this.buttonExtractAttributeUp.Enabled = false;
            this.buttonExtractAttributeUp.Location = new System.Drawing.Point(88, 188);
            this.buttonExtractAttributeUp.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonExtractAttributeUp.Name = "buttonExtractAttributeUp";
            this.buttonExtractAttributeUp.Size = new System.Drawing.Size(92, 29);
            this.buttonExtractAttributeUp.TabIndex = 4;
            this.buttonExtractAttributeUp.Text = "Up";
            this.toolTip1.SetToolTip(this.buttonExtractAttributeUp, "Move the selected field up");
            this.buttonExtractAttributeUp.UseVisualStyleBackColor = true;
            // 
            // buttonExtractAttributeRemove
            // 
            this.buttonExtractAttributeRemove.Enabled = false;
            this.buttonExtractAttributeRemove.Location = new System.Drawing.Point(88, 157);
            this.buttonExtractAttributeRemove.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonExtractAttributeRemove.Name = "buttonExtractAttributeRemove";
            this.buttonExtractAttributeRemove.Size = new System.Drawing.Size(92, 29);
            this.buttonExtractAttributeRemove.TabIndex = 3;
            this.buttonExtractAttributeRemove.Text = "Remove";
            this.toolTip1.SetToolTip(this.buttonExtractAttributeRemove, "Remove selected field from the extract");
            this.buttonExtractAttributeRemove.UseVisualStyleBackColor = true;
            this.buttonExtractAttributeRemove.Click += new System.EventHandler(this.buttonExtractAttributeRemove_Click);
            // 
            // buttonAddExtractAttribute
            // 
            this.buttonAddExtractAttribute.Enabled = false;
            this.buttonAddExtractAttribute.Location = new System.Drawing.Point(88, 126);
            this.buttonAddExtractAttribute.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonAddExtractAttribute.Name = "buttonAddExtractAttribute";
            this.buttonAddExtractAttribute.Size = new System.Drawing.Size(92, 29);
            this.buttonAddExtractAttribute.TabIndex = 1;
            this.buttonAddExtractAttribute.Text = "Add";
            this.toolTip1.SetToolTip(this.buttonAddExtractAttribute, "Add field to the extract");
            this.buttonAddExtractAttribute.UseVisualStyleBackColor = true;
            this.buttonAddExtractAttribute.Click += new System.EventHandler(this.buttonAttrAdd_Click);
            // 
            // numericUpDownExtractAttributePrecision
            // 
            this.numericUpDownExtractAttributePrecision.Location = new System.Drawing.Point(88, 96);
            this.numericUpDownExtractAttributePrecision.Margin = new System.Windows.Forms.Padding(2);
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
            this.numericUpDownExtractAttributePrecision.Size = new System.Drawing.Size(124, 27);
            this.numericUpDownExtractAttributePrecision.TabIndex = 8;
            this.toolTip1.SetToolTip(this.numericUpDownExtractAttributePrecision, "Decimal precision (-1 for max)");
            // 
            // textBoxExtractAttributeDefault
            // 
            this.textBoxExtractAttributeDefault.Location = new System.Drawing.Point(90, 63);
            this.textBoxExtractAttributeDefault.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxExtractAttributeDefault.Name = "textBoxExtractAttributeDefault";
            this.textBoxExtractAttributeDefault.Size = new System.Drawing.Size(114, 27);
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
            "TableRows",
            "TableCols"});
            this.comboBoxExtractAttributeAggregateType.Location = new System.Drawing.Point(88, 30);
            this.comboBoxExtractAttributeAggregateType.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.comboBoxExtractAttributeAggregateType.Name = "comboBoxExtractAttributeAggregateType";
            this.comboBoxExtractAttributeAggregateType.Size = new System.Drawing.Size(123, 28);
            this.comboBoxExtractAttributeAggregateType.TabIndex = 2;
            this.toolTip1.SetToolTip(this.comboBoxExtractAttributeAggregateType, "How to handle lists or arrays");
            // 
            // textBoxExtractAttributeLabel
            // 
            this.textBoxExtractAttributeLabel.Location = new System.Drawing.Point(88, 1);
            this.textBoxExtractAttributeLabel.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBoxExtractAttributeLabel.Name = "textBoxExtractAttributeLabel";
            this.textBoxExtractAttributeLabel.Size = new System.Drawing.Size(125, 27);
            this.textBoxExtractAttributeLabel.TabIndex = 6;
            this.textBoxExtractAttributeLabel.Text = "label";
            this.toolTip1.SetToolTip(this.textBoxExtractAttributeLabel, "Column name in the extract");
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Label";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Aggregate";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Default";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 20);
            this.label9.TabIndex = 12;
            this.label9.Text = "Precision";
            // 
            // splitContainerFilterVsAttributeTables
            // 
            this.splitContainerFilterVsAttributeTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFilterVsAttributeTables.Location = new System.Drawing.Point(0, 0);
            this.splitContainerFilterVsAttributeTables.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.splitContainerFilterVsAttributeTables.Size = new System.Drawing.Size(782, 597);
            this.splitContainerFilterVsAttributeTables.SplitterDistance = 257;
            this.splitContainerFilterVsAttributeTables.SplitterWidth = 2;
            this.splitContainerFilterVsAttributeTables.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataGridViewFilters);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox5.Size = new System.Drawing.Size(782, 257);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Filters on Selected JSON Files";
            // 
            // dataGridViewFilters
            // 
            this.dataGridViewFilters.AllowUserToAddRows = false;
            this.dataGridViewFilters.AllowUserToDeleteRows = false;
            this.dataGridViewFilters.AllowUserToOrderColumns = true;
            this.dataGridViewFilters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewFilters.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewFilters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFilters.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewFilters.Location = new System.Drawing.Point(2, 21);
            this.dataGridViewFilters.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dataGridViewFilters.MinimumSize = new System.Drawing.Size(200, 100);
            this.dataGridViewFilters.MultiSelect = false;
            this.dataGridViewFilters.Name = "dataGridViewFilters";
            this.dataGridViewFilters.RowHeadersVisible = false;
            this.dataGridViewFilters.RowHeadersWidth = 82;
            this.dataGridViewFilters.RowTemplate.Height = 41;
            this.dataGridViewFilters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFilters.ShowEditingIcon = false;
            this.dataGridViewFilters.Size = new System.Drawing.Size(778, 235);
            this.dataGridViewFilters.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dataGridViewAttributes);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox6.Size = new System.Drawing.Size(782, 338);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Attributes to Extract";
            // 
            // dataGridViewAttributes
            // 
            this.dataGridViewAttributes.ColumnHeadersHeight = 46;
            this.dataGridViewAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAttributes.Location = new System.Drawing.Point(2, 21);
            this.dataGridViewAttributes.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dataGridViewAttributes.MinimumSize = new System.Drawing.Size(200, 100);
            this.dataGridViewAttributes.Name = "dataGridViewAttributes";
            this.dataGridViewAttributes.RowHeadersWidth = 82;
            this.dataGridViewAttributes.RowTemplate.Height = 41;
            this.dataGridViewAttributes.Size = new System.Drawing.Size(778, 316);
            this.dataGridViewAttributes.TabIndex = 0;
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
            this.tableLayoutPanelProgressAndLog.Name = "tableLayoutPanelProgressAndLog";
            this.tableLayoutPanelProgressAndLog.RowCount = 2;
            this.tableLayoutPanelProgressAndLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelProgressAndLog.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelProgressAndLog.Size = new System.Drawing.Size(1646, 197);
            this.tableLayoutPanelProgressAndLog.TabIndex = 1;
            // 
            // groupBoxEventLog
            // 
            this.groupBoxEventLog.Controls.Add(this.textBoxEventLog);
            this.groupBoxEventLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxEventLog.Location = new System.Drawing.Point(2, 41);
            this.groupBoxEventLog.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBoxEventLog.Name = "groupBoxEventLog";
            this.groupBoxEventLog.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBoxEventLog.Size = new System.Drawing.Size(1642, 155);
            this.groupBoxEventLog.TabIndex = 0;
            this.groupBoxEventLog.TabStop = false;
            this.groupBoxEventLog.Text = "Event Log";
            // 
            // textBoxEventLog
            // 
            this.textBoxEventLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxEventLog.Location = new System.Drawing.Point(2, 21);
            this.textBoxEventLog.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBoxEventLog.Multiline = true;
            this.textBoxEventLog.Name = "textBoxEventLog";
            this.textBoxEventLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxEventLog.Size = new System.Drawing.Size(1638, 133);
            this.textBoxEventLog.TabIndex = 0;
            // 
            // progressBarStatus
            // 
            this.progressBarStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBarStatus.Location = new System.Drawing.Point(4, 4);
            this.progressBarStatus.Margin = new System.Windows.Forms.Padding(4);
            this.progressBarStatus.Name = "progressBarStatus";
            this.progressBarStatus.Size = new System.Drawing.Size(1638, 32);
            this.progressBarStatus.TabIndex = 0;
            // 
            // openFileDialogSample
            // 
            this.openFileDialogSample.DefaultExt = "json";
            this.openFileDialogSample.Filter = "JSON files|*.json|GZ files|*.json.gz";
            this.openFileDialogSample.ShowReadOnly = true;
            // 
            // openFileDialogInputFiles
            // 
            this.openFileDialogInputFiles.DefaultExt = "json";
            this.openFileDialogInputFiles.Filter = "JSON files|*.json|GZ files|*.json.gz";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1646, 796);
            this.Controls.Add(this.splitContainerTopVsBottom);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "Form1";
            this.Text = "JSON Extractor";
            this.splitContainerTopVsBottom.Panel1.ResumeLayout(false);
            this.splitContainerTopVsBottom.Panel2.ResumeLayout(false);
            this.splitContainerTopVsBottom.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTopVsBottom)).EndInit();
            this.splitContainerTopVsBottom.ResumeLayout(false);
            this.splitContainerAvsBC.Panel1.ResumeLayout(false);
            this.splitContainerAvsBC.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAvsBC)).EndInit();
            this.splitContainerAvsBC.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageInput.ResumeLayout(false);
            this.tabPageInput.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
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
            this.splitContainerBvsC.Panel1.ResumeLayout(false);
            this.splitContainerBvsC.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBvsC)).EndInit();
            this.splitContainerBvsC.ResumeLayout(false);
            this.splitContainerTreeVsOpts.Panel1.ResumeLayout(false);
            this.splitContainerTreeVsOpts.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTreeVsOpts)).EndInit();
            this.splitContainerTreeVsOpts.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.splitContainerFilterVsAttrControls.Panel1.ResumeLayout(false);
            this.splitContainerFilterVsAttrControls.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFilterVsAttrControls)).EndInit();
            this.splitContainerFilterVsAttrControls.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExtractAttributePrecision)).EndInit();
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerTopVsBottom;
        private System.Windows.Forms.GroupBox groupBoxEventLog;
        private System.Windows.Forms.TextBox textBoxEventLog;
        private System.Windows.Forms.SplitContainer splitContainerAvsBC;
        private System.Windows.Forms.SplitContainer splitContainerBvsC;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.SplitContainer splitContainerFilterVsAttributeTables;
        private System.Windows.Forms.SplitContainer splitContainerTreeVsOpts;
        private System.Windows.Forms.TreeView treeViewJSON;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.SplitContainer splitContainerFilterVsAttrControls;
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
        private System.Windows.Forms.Button buttonExtractAttributeRemove;
        private System.Windows.Forms.Button buttonExtractAttributeUp;
        private System.Windows.Forms.Button buttonExtractAttributeDown;
        private System.Windows.Forms.Button buttonFilterAdd;
        private System.Windows.Forms.Button buttonFilterRemove;
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
    }
}

