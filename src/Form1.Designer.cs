
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxS3Bucket = new System.Windows.Forms.TextBox();
            this.textBoxS3AccessKey = new System.Windows.Forms.TextBox();
            this.textBoxS3SecretKey = new System.Windows.Forms.TextBox();
            this.buttonS3CacheDir = new System.Windows.Forms.Button();
            this.buttonS3StartSync = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelProcessedCount = new System.Windows.Forms.Label();
            this.labelSelectedCount = new System.Windows.Forms.Label();
            this.labelFilteredCount = new System.Windows.Forms.Label();
            this.labelExtractedCount = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonSaveConfig = new System.Windows.Forms.Button();
            this.buttonLoadConfig = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonLoadSample = new System.Windows.Forms.Button();
            this.buttonSelectInputDir = new System.Windows.Forms.Button();
            this.buttonSelectFiles = new System.Windows.Forms.Button();
            this.splitContainerBvsC = new System.Windows.Forms.SplitContainer();
            this.splitContainerTreeVsOpts = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.treeViewJSON = new System.Windows.Forms.TreeView();
            this.splitContainerFilterVsAttrControls = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBoxFilterType = new System.Windows.Forms.ComboBox();
            this.textBoxFilterPattern = new System.Windows.Forms.TextBox();
            this.buttonFilterAdd = new System.Windows.Forms.Button();
            this.buttonFilterRemove = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxExtractAttributeLabel = new System.Windows.Forms.TextBox();
            this.comboBoxExtractAttributeAggregateType = new System.Windows.Forms.ComboBox();
            this.buttonAddExtractAttribute = new System.Windows.Forms.Button();
            this.buttonExtractAttributeRemove = new System.Windows.Forms.Button();
            this.buttonExtractAttributeUp = new System.Windows.Forms.Button();
            this.buttonExtractAttributeDown = new System.Windows.Forms.Button();
            this.textBoxExtractAttributeDefault = new System.Windows.Forms.TextBox();
            this.splitContainerC1vsC2 = new System.Windows.Forms.SplitContainer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataGridViewFilters = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dataGridViewAttributes = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            this.progressBarStatus = new System.Windows.Forms.ProgressBar();
            this.groupBoxEventLog = new System.Windows.Forms.GroupBox();
            this.textBoxEventLog = new System.Windows.Forms.TextBox();
            this.openFileDialogSample = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogInputFiles = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.folderBrowserDialogInputDir = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorkerExtraction = new System.ComponentModel.BackgroundWorker();
            this.checkBoxFilterNegate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTopVsBottom)).BeginInit();
            this.splitContainerTopVsBottom.Panel1.SuspendLayout();
            this.splitContainerTopVsBottom.Panel2.SuspendLayout();
            this.splitContainerTopVsBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAvsBC)).BeginInit();
            this.splitContainerAvsBC.Panel1.SuspendLayout();
            this.splitContainerAvsBC.Panel2.SuspendLayout();
            this.splitContainerAvsBC.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
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
            this.flowLayoutPanel3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerC1vsC2)).BeginInit();
            this.splitContainerC1vsC2.Panel1.SuspendLayout();
            this.splitContainerC1vsC2.Panel2.SuspendLayout();
            this.splitContainerC1vsC2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilters)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttributes)).BeginInit();
            this.flowLayoutPanel8.SuspendLayout();
            this.groupBoxEventLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerTopVsBottom
            // 
            this.splitContainerTopVsBottom.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainerTopVsBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTopVsBottom.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTopVsBottom.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.splitContainerTopVsBottom.Name = "splitContainerTopVsBottom";
            this.splitContainerTopVsBottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTopVsBottom.Panel1
            // 
            this.splitContainerTopVsBottom.Panel1.Controls.Add(this.splitContainerAvsBC);
            // 
            // splitContainerTopVsBottom.Panel2
            // 
            this.splitContainerTopVsBottom.Panel2.Controls.Add(this.flowLayoutPanel8);
            this.splitContainerTopVsBottom.Size = new System.Drawing.Size(2526, 1308);
            this.splitContainerTopVsBottom.SplitterDistance = 982;
            this.splitContainerTopVsBottom.TabIndex = 0;
            // 
            // splitContainerAvsBC
            // 
            this.splitContainerAvsBC.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainerAvsBC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerAvsBC.Location = new System.Drawing.Point(0, 0);
            this.splitContainerAvsBC.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.splitContainerAvsBC.Name = "splitContainerAvsBC";
            // 
            // splitContainerAvsBC.Panel1
            // 
            this.splitContainerAvsBC.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainerAvsBC.Panel2
            // 
            this.splitContainerAvsBC.Panel2.Controls.Add(this.splitContainerBvsC);
            this.splitContainerAvsBC.Size = new System.Drawing.Size(2526, 982);
            this.splitContainerAvsBC.SplitterDistance = 359;
            this.splitContainerAvsBC.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox2.Size = new System.Drawing.Size(359, 982);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.groupBox11);
            this.flowLayoutPanel1.Controls.Add(this.groupBox8);
            this.flowLayoutPanel1.Controls.Add(this.groupBox9);
            this.flowLayoutPanel1.Controls.Add(this.groupBox10);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 34);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(351, 946);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.flowLayoutPanel7);
            this.groupBox11.Location = new System.Drawing.Point(6, 6);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox11.Size = new System.Drawing.Size(182, 363);
            this.groupBox11.TabIndex = 8;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "AWS S3";
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.Controls.Add(this.textBoxS3Bucket);
            this.flowLayoutPanel7.Controls.Add(this.textBoxS3AccessKey);
            this.flowLayoutPanel7.Controls.Add(this.textBoxS3SecretKey);
            this.flowLayoutPanel7.Controls.Add(this.buttonS3CacheDir);
            this.flowLayoutPanel7.Controls.Add(this.buttonS3StartSync);
            this.flowLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel7.Location = new System.Drawing.Point(6, 38);
            this.flowLayoutPanel7.Margin = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(170, 319);
            this.flowLayoutPanel7.TabIndex = 1;
            // 
            // textBoxS3Bucket
            // 
            this.textBoxS3Bucket.Location = new System.Drawing.Point(6, 6);
            this.textBoxS3Bucket.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxS3Bucket.Name = "textBoxS3Bucket";
            this.textBoxS3Bucket.Size = new System.Drawing.Size(156, 39);
            this.textBoxS3Bucket.TabIndex = 0;
            this.textBoxS3Bucket.Text = "s3bucket";
            this.toolTip1.SetToolTip(this.textBoxS3Bucket, "AWS S3 bucket");
            // 
            // textBoxS3AccessKey
            // 
            this.textBoxS3AccessKey.Location = new System.Drawing.Point(6, 57);
            this.textBoxS3AccessKey.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxS3AccessKey.Name = "textBoxS3AccessKey";
            this.textBoxS3AccessKey.Size = new System.Drawing.Size(156, 39);
            this.textBoxS3AccessKey.TabIndex = 1;
            this.textBoxS3AccessKey.Text = "accessKey";
            this.toolTip1.SetToolTip(this.textBoxS3AccessKey, "AWS Access Key");
            // 
            // textBoxS3SecretKey
            // 
            this.textBoxS3SecretKey.Location = new System.Drawing.Point(6, 108);
            this.textBoxS3SecretKey.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxS3SecretKey.Name = "textBoxS3SecretKey";
            this.textBoxS3SecretKey.Size = new System.Drawing.Size(156, 39);
            this.textBoxS3SecretKey.TabIndex = 2;
            this.textBoxS3SecretKey.Text = "secretKey";
            this.toolTip1.SetToolTip(this.textBoxS3SecretKey, "AWS Secret Key");
            this.textBoxS3SecretKey.UseSystemPasswordChar = true;
            // 
            // buttonS3CacheDir
            // 
            this.buttonS3CacheDir.Location = new System.Drawing.Point(6, 159);
            this.buttonS3CacheDir.Margin = new System.Windows.Forms.Padding(6);
            this.buttonS3CacheDir.Name = "buttonS3CacheDir";
            this.buttonS3CacheDir.Size = new System.Drawing.Size(160, 49);
            this.buttonS3CacheDir.TabIndex = 3;
            this.buttonS3CacheDir.Text = "Cache Dir";
            this.buttonS3CacheDir.UseVisualStyleBackColor = true;
            this.buttonS3CacheDir.Click += new System.EventHandler(this.buttonS3CacheDir_Click);
            // 
            // buttonS3StartSync
            // 
            this.buttonS3StartSync.Location = new System.Drawing.Point(6, 220);
            this.buttonS3StartSync.Margin = new System.Windows.Forms.Padding(6);
            this.buttonS3StartSync.Name = "buttonS3StartSync";
            this.buttonS3StartSync.Size = new System.Drawing.Size(160, 49);
            this.buttonS3StartSync.TabIndex = 4;
            this.buttonS3StartSync.Text = "Start Sync";
            this.buttonS3StartSync.UseVisualStyleBackColor = true;
            this.buttonS3StartSync.Click += new System.EventHandler(this.buttonS3StartSync_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.AutoSize = true;
            this.groupBox8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox8.Controls.Add(this.flowLayoutPanel4);
            this.groupBox8.Location = new System.Drawing.Point(6, 381);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox8.MinimumSize = new System.Drawing.Size(186, 235);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox8.Size = new System.Drawing.Size(186, 235);
            this.groupBox8.TabIndex = 5;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Extract";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.buttonStart);
            this.flowLayoutPanel4.Controls.Add(this.labelProcessedCount);
            this.flowLayoutPanel4.Controls.Add(this.labelSelectedCount);
            this.flowLayoutPanel4.Controls.Add(this.labelFilteredCount);
            this.flowLayoutPanel4.Controls.Add(this.labelExtractedCount);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(6, 38);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(174, 191);
            this.flowLayoutPanel4.TabIndex = 0;
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(4, 2);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(162, 47);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelProcessedCount
            // 
            this.labelProcessedCount.AutoSize = true;
            this.labelProcessedCount.Location = new System.Drawing.Point(6, 51);
            this.labelProcessedCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelProcessedCount.MinimumSize = new System.Drawing.Size(139, 32);
            this.labelProcessedCount.Name = "labelProcessedCount";
            this.labelProcessedCount.Size = new System.Drawing.Size(145, 32);
            this.labelProcessedCount.TabIndex = 3;
            this.labelProcessedCount.Text = "Processed: 0";
            // 
            // labelSelectedCount
            // 
            this.labelSelectedCount.AutoSize = true;
            this.labelSelectedCount.Location = new System.Drawing.Point(6, 83);
            this.labelSelectedCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSelectedCount.MinimumSize = new System.Drawing.Size(139, 32);
            this.labelSelectedCount.Name = "labelSelectedCount";
            this.labelSelectedCount.Size = new System.Drawing.Size(139, 32);
            this.labelSelectedCount.TabIndex = 6;
            this.labelSelectedCount.Text = "Selected: 0";
            // 
            // labelFilteredCount
            // 
            this.labelFilteredCount.AutoSize = true;
            this.labelFilteredCount.Location = new System.Drawing.Point(6, 115);
            this.labelFilteredCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelFilteredCount.MinimumSize = new System.Drawing.Size(139, 32);
            this.labelFilteredCount.Name = "labelFilteredCount";
            this.labelFilteredCount.Size = new System.Drawing.Size(139, 32);
            this.labelFilteredCount.TabIndex = 4;
            this.labelFilteredCount.Text = "Filtered: 0";
            // 
            // labelExtractedCount
            // 
            this.labelExtractedCount.AutoSize = true;
            this.labelExtractedCount.Location = new System.Drawing.Point(6, 147);
            this.labelExtractedCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelExtractedCount.MinimumSize = new System.Drawing.Size(139, 32);
            this.labelExtractedCount.Name = "labelExtractedCount";
            this.labelExtractedCount.Size = new System.Drawing.Size(139, 32);
            this.labelExtractedCount.TabIndex = 5;
            this.labelExtractedCount.Text = "Extracted: 0";
            // 
            // groupBox9
            // 
            this.groupBox9.AutoSize = true;
            this.groupBox9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox9.Controls.Add(this.flowLayoutPanel5);
            this.groupBox9.Location = new System.Drawing.Point(6, 628);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox9.MinimumSize = new System.Drawing.Size(186, 160);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox9.Size = new System.Drawing.Size(186, 160);
            this.groupBox9.TabIndex = 6;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Configurations";
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.buttonSaveConfig);
            this.flowLayoutPanel5.Controls.Add(this.buttonLoadConfig);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(6, 38);
            this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(174, 116);
            this.flowLayoutPanel5.TabIndex = 0;
            // 
            // buttonSaveConfig
            // 
            this.buttonSaveConfig.Location = new System.Drawing.Point(4, 2);
            this.buttonSaveConfig.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.buttonSaveConfig.Name = "buttonSaveConfig";
            this.buttonSaveConfig.Size = new System.Drawing.Size(162, 47);
            this.buttonSaveConfig.TabIndex = 3;
            this.buttonSaveConfig.Text = "Save Config";
            this.buttonSaveConfig.UseVisualStyleBackColor = true;
            // 
            // buttonLoadConfig
            // 
            this.buttonLoadConfig.Location = new System.Drawing.Point(4, 53);
            this.buttonLoadConfig.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.buttonLoadConfig.Name = "buttonLoadConfig";
            this.buttonLoadConfig.Size = new System.Drawing.Size(162, 47);
            this.buttonLoadConfig.TabIndex = 4;
            this.buttonLoadConfig.Text = "Load Config";
            this.buttonLoadConfig.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.AutoSize = true;
            this.groupBox10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox10.Controls.Add(this.flowLayoutPanel6);
            this.groupBox10.Location = new System.Drawing.Point(6, 800);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox10.MinimumSize = new System.Drawing.Size(186, 213);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox10.Size = new System.Drawing.Size(186, 213);
            this.groupBox10.TabIndex = 7;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Input Files";
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.buttonLoadSample);
            this.flowLayoutPanel6.Controls.Add(this.buttonSelectInputDir);
            this.flowLayoutPanel6.Controls.Add(this.buttonSelectFiles);
            this.flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(6, 38);
            this.flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(174, 169);
            this.flowLayoutPanel6.TabIndex = 0;
            // 
            // buttonLoadSample
            // 
            this.buttonLoadSample.Location = new System.Drawing.Point(4, 2);
            this.buttonLoadSample.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.buttonLoadSample.Name = "buttonLoadSample";
            this.buttonLoadSample.Size = new System.Drawing.Size(173, 47);
            this.buttonLoadSample.TabIndex = 0;
            this.buttonLoadSample.Text = "Load Sample";
            this.buttonLoadSample.UseVisualStyleBackColor = true;
            this.buttonLoadSample.Click += new System.EventHandler(this.buttonLoadSample_Click);
            // 
            // buttonSelectInputDir
            // 
            this.buttonSelectInputDir.Location = new System.Drawing.Point(6, 57);
            this.buttonSelectInputDir.Margin = new System.Windows.Forms.Padding(6);
            this.buttonSelectInputDir.Name = "buttonSelectInputDir";
            this.buttonSelectInputDir.Size = new System.Drawing.Size(173, 47);
            this.buttonSelectInputDir.TabIndex = 2;
            this.buttonSelectInputDir.Text = "Select Folder";
            this.buttonSelectInputDir.UseVisualStyleBackColor = true;
            this.buttonSelectInputDir.Click += new System.EventHandler(this.buttonSelectInputDir_Click);
            // 
            // buttonSelectFiles
            // 
            this.buttonSelectFiles.Location = new System.Drawing.Point(4, 112);
            this.buttonSelectFiles.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.buttonSelectFiles.Name = "buttonSelectFiles";
            this.buttonSelectFiles.Size = new System.Drawing.Size(173, 47);
            this.buttonSelectFiles.TabIndex = 1;
            this.buttonSelectFiles.Text = "Select Files";
            this.buttonSelectFiles.UseVisualStyleBackColor = true;
            // 
            // splitContainerBvsC
            // 
            this.splitContainerBvsC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerBvsC.Location = new System.Drawing.Point(0, 0);
            this.splitContainerBvsC.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.splitContainerBvsC.Name = "splitContainerBvsC";
            // 
            // splitContainerBvsC.Panel1
            // 
            this.splitContainerBvsC.Panel1.Controls.Add(this.splitContainerTreeVsOpts);
            // 
            // splitContainerBvsC.Panel2
            // 
            this.splitContainerBvsC.Panel2.Controls.Add(this.splitContainerC1vsC2);
            this.splitContainerBvsC.Size = new System.Drawing.Size(2163, 982);
            this.splitContainerBvsC.SplitterDistance = 962;
            this.splitContainerBvsC.TabIndex = 0;
            // 
            // splitContainerTreeVsOpts
            // 
            this.splitContainerTreeVsOpts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTreeVsOpts.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTreeVsOpts.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.splitContainerTreeVsOpts.Name = "splitContainerTreeVsOpts";
            // 
            // splitContainerTreeVsOpts.Panel1
            // 
            this.splitContainerTreeVsOpts.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainerTreeVsOpts.Panel2
            // 
            this.splitContainerTreeVsOpts.Panel2.Controls.Add(this.splitContainerFilterVsAttrControls);
            this.splitContainerTreeVsOpts.Size = new System.Drawing.Size(962, 982);
            this.splitContainerTreeVsOpts.SplitterDistance = 638;
            this.splitContainerTreeVsOpts.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.treeViewJSON);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox3.Size = new System.Drawing.Size(638, 982);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "JSON Attribute Structure";
            // 
            // treeViewJSON
            // 
            this.treeViewJSON.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewJSON.Location = new System.Drawing.Point(4, 34);
            this.treeViewJSON.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.treeViewJSON.Name = "treeViewJSON";
            this.treeViewJSON.Size = new System.Drawing.Size(630, 946);
            this.treeViewJSON.TabIndex = 0;
            this.treeViewJSON.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewJSON_AfterSelect);
            // 
            // splitContainerFilterVsAttrControls
            // 
            this.splitContainerFilterVsAttrControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFilterVsAttrControls.Location = new System.Drawing.Point(0, 0);
            this.splitContainerFilterVsAttrControls.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
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
            this.splitContainerFilterVsAttrControls.Size = new System.Drawing.Size(320, 982);
            this.splitContainerFilterVsAttrControls.SplitterDistance = 488;
            this.splitContainerFilterVsAttrControls.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.flowLayoutPanel3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox4.Size = new System.Drawing.Size(320, 488);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filter";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.comboBoxFilterType);
            this.flowLayoutPanel3.Controls.Add(this.textBoxFilterPattern);
            this.flowLayoutPanel3.Controls.Add(this.checkBoxFilterNegate);
            this.flowLayoutPanel3.Controls.Add(this.buttonFilterAdd);
            this.flowLayoutPanel3.Controls.Add(this.buttonFilterRemove);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(4, 34);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(312, 452);
            this.flowLayoutPanel3.TabIndex = 3;
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
            this.comboBoxFilterType.Location = new System.Drawing.Point(4, 2);
            this.comboBoxFilterType.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.comboBoxFilterType.Name = "comboBoxFilterType";
            this.comboBoxFilterType.Size = new System.Drawing.Size(197, 40);
            this.comboBoxFilterType.TabIndex = 0;
            // 
            // textBoxFilterPattern
            // 
            this.textBoxFilterPattern.Location = new System.Drawing.Point(6, 50);
            this.textBoxFilterPattern.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxFilterPattern.Name = "textBoxFilterPattern";
            this.textBoxFilterPattern.Size = new System.Drawing.Size(182, 39);
            this.textBoxFilterPattern.TabIndex = 3;
            this.textBoxFilterPattern.Text = "pattern";
            this.toolTip1.SetToolTip(this.textBoxFilterPattern, "The threshold used for numeric comparisons, or regular expression for matching fi" +
        "lters");
            // 
            // buttonFilterAdd
            // 
            this.buttonFilterAdd.Enabled = false;
            this.buttonFilterAdd.Location = new System.Drawing.Point(134, 97);
            this.buttonFilterAdd.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.buttonFilterAdd.Name = "buttonFilterAdd";
            this.buttonFilterAdd.Size = new System.Drawing.Size(150, 47);
            this.buttonFilterAdd.TabIndex = 1;
            this.buttonFilterAdd.Text = "Add";
            this.buttonFilterAdd.UseVisualStyleBackColor = true;
            this.buttonFilterAdd.Click += new System.EventHandler(this.buttonFilterAdd_Click);
            // 
            // buttonFilterRemove
            // 
            this.buttonFilterRemove.Enabled = false;
            this.buttonFilterRemove.Location = new System.Drawing.Point(4, 148);
            this.buttonFilterRemove.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.buttonFilterRemove.Name = "buttonFilterRemove";
            this.buttonFilterRemove.Size = new System.Drawing.Size(150, 47);
            this.buttonFilterRemove.TabIndex = 2;
            this.buttonFilterRemove.Text = "Remove";
            this.buttonFilterRemove.UseVisualStyleBackColor = true;
            this.buttonFilterRemove.Click += new System.EventHandler(this.buttonFilterRemove_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.flowLayoutPanel2);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox7.Size = new System.Drawing.Size(320, 490);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Attribute";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.textBoxExtractAttributeLabel);
            this.flowLayoutPanel2.Controls.Add(this.comboBoxExtractAttributeAggregateType);
            this.flowLayoutPanel2.Controls.Add(this.buttonAddExtractAttribute);
            this.flowLayoutPanel2.Controls.Add(this.buttonExtractAttributeRemove);
            this.flowLayoutPanel2.Controls.Add(this.buttonExtractAttributeUp);
            this.flowLayoutPanel2.Controls.Add(this.buttonExtractAttributeDown);
            this.flowLayoutPanel2.Controls.Add(this.textBoxExtractAttributeDefault);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(4, 34);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(312, 454);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // textBoxExtractAttributeLabel
            // 
            this.textBoxExtractAttributeLabel.Location = new System.Drawing.Point(4, 2);
            this.textBoxExtractAttributeLabel.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.textBoxExtractAttributeLabel.Name = "textBoxExtractAttributeLabel";
            this.textBoxExtractAttributeLabel.Size = new System.Drawing.Size(201, 39);
            this.textBoxExtractAttributeLabel.TabIndex = 6;
            this.textBoxExtractAttributeLabel.Text = "label";
            this.toolTip1.SetToolTip(this.textBoxExtractAttributeLabel, "column name in the extract");
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
            this.comboBoxExtractAttributeAggregateType.Location = new System.Drawing.Point(4, 45);
            this.comboBoxExtractAttributeAggregateType.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.comboBoxExtractAttributeAggregateType.Name = "comboBoxExtractAttributeAggregateType";
            this.comboBoxExtractAttributeAggregateType.Size = new System.Drawing.Size(197, 40);
            this.comboBoxExtractAttributeAggregateType.TabIndex = 2;
            this.toolTip1.SetToolTip(this.comboBoxExtractAttributeAggregateType, "how you want this array of numbers aggregated or extracted");
            // 
            // buttonAddExtractAttribute
            // 
            this.buttonAddExtractAttribute.Enabled = false;
            this.buttonAddExtractAttribute.Location = new System.Drawing.Point(4, 89);
            this.buttonAddExtractAttribute.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.buttonAddExtractAttribute.Name = "buttonAddExtractAttribute";
            this.buttonAddExtractAttribute.Size = new System.Drawing.Size(150, 47);
            this.buttonAddExtractAttribute.TabIndex = 1;
            this.buttonAddExtractAttribute.Text = "Add";
            this.buttonAddExtractAttribute.UseVisualStyleBackColor = true;
            this.buttonAddExtractAttribute.Click += new System.EventHandler(this.buttonAttrAdd_Click);
            // 
            // buttonExtractAttributeRemove
            // 
            this.buttonExtractAttributeRemove.Enabled = false;
            this.buttonExtractAttributeRemove.Location = new System.Drawing.Point(4, 140);
            this.buttonExtractAttributeRemove.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.buttonExtractAttributeRemove.Name = "buttonExtractAttributeRemove";
            this.buttonExtractAttributeRemove.Size = new System.Drawing.Size(150, 47);
            this.buttonExtractAttributeRemove.TabIndex = 3;
            this.buttonExtractAttributeRemove.Text = "Remove";
            this.buttonExtractAttributeRemove.UseVisualStyleBackColor = true;
            this.buttonExtractAttributeRemove.Click += new System.EventHandler(this.buttonExtractAttributeRemove_Click);
            // 
            // buttonExtractAttributeUp
            // 
            this.buttonExtractAttributeUp.Enabled = false;
            this.buttonExtractAttributeUp.Location = new System.Drawing.Point(4, 191);
            this.buttonExtractAttributeUp.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.buttonExtractAttributeUp.Name = "buttonExtractAttributeUp";
            this.buttonExtractAttributeUp.Size = new System.Drawing.Size(150, 47);
            this.buttonExtractAttributeUp.TabIndex = 4;
            this.buttonExtractAttributeUp.Text = "Up";
            this.buttonExtractAttributeUp.UseVisualStyleBackColor = true;
            // 
            // buttonExtractAttributeDown
            // 
            this.buttonExtractAttributeDown.Enabled = false;
            this.buttonExtractAttributeDown.Location = new System.Drawing.Point(4, 242);
            this.buttonExtractAttributeDown.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.buttonExtractAttributeDown.Name = "buttonExtractAttributeDown";
            this.buttonExtractAttributeDown.Size = new System.Drawing.Size(150, 47);
            this.buttonExtractAttributeDown.TabIndex = 5;
            this.buttonExtractAttributeDown.Text = "Down";
            this.buttonExtractAttributeDown.UseVisualStyleBackColor = true;
            // 
            // textBoxExtractAttributeDefault
            // 
            this.textBoxExtractAttributeDefault.Location = new System.Drawing.Point(6, 297);
            this.textBoxExtractAttributeDefault.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxExtractAttributeDefault.Name = "textBoxExtractAttributeDefault";
            this.textBoxExtractAttributeDefault.Size = new System.Drawing.Size(182, 39);
            this.textBoxExtractAttributeDefault.TabIndex = 7;
            this.textBoxExtractAttributeDefault.Text = "default";
            // 
            // splitContainerC1vsC2
            // 
            this.splitContainerC1vsC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerC1vsC2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerC1vsC2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.splitContainerC1vsC2.Name = "splitContainerC1vsC2";
            this.splitContainerC1vsC2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerC1vsC2.Panel1
            // 
            this.splitContainerC1vsC2.Panel1.Controls.Add(this.groupBox5);
            // 
            // splitContainerC1vsC2.Panel2
            // 
            this.splitContainerC1vsC2.Panel2.Controls.Add(this.groupBox6);
            this.splitContainerC1vsC2.Size = new System.Drawing.Size(1197, 982);
            this.splitContainerC1vsC2.SplitterDistance = 424;
            this.splitContainerC1vsC2.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataGridViewFilters);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox5.Size = new System.Drawing.Size(1197, 424);
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
            this.dataGridViewFilters.Location = new System.Drawing.Point(4, 34);
            this.dataGridViewFilters.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dataGridViewFilters.MultiSelect = false;
            this.dataGridViewFilters.Name = "dataGridViewFilters";
            this.dataGridViewFilters.RowHeadersVisible = false;
            this.dataGridViewFilters.RowHeadersWidth = 82;
            this.dataGridViewFilters.RowTemplate.Height = 41;
            this.dataGridViewFilters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFilters.ShowEditingIcon = false;
            this.dataGridViewFilters.Size = new System.Drawing.Size(1189, 388);
            this.dataGridViewFilters.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dataGridViewAttributes);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox6.Size = new System.Drawing.Size(1197, 554);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Attributes to Extract";
            // 
            // dataGridViewAttributes
            // 
            this.dataGridViewAttributes.ColumnHeadersHeight = 46;
            this.dataGridViewAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAttributes.Location = new System.Drawing.Point(4, 34);
            this.dataGridViewAttributes.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dataGridViewAttributes.Name = "dataGridViewAttributes";
            this.dataGridViewAttributes.RowHeadersWidth = 82;
            this.dataGridViewAttributes.RowTemplate.Height = 41;
            this.dataGridViewAttributes.Size = new System.Drawing.Size(1189, 518);
            this.dataGridViewAttributes.TabIndex = 0;
            // 
            // flowLayoutPanel8
            // 
            this.flowLayoutPanel8.Controls.Add(this.progressBarStatus);
            this.flowLayoutPanel8.Controls.Add(this.groupBoxEventLog);
            this.flowLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel8.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel8.Margin = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel8.Name = "flowLayoutPanel8";
            this.flowLayoutPanel8.Size = new System.Drawing.Size(2526, 322);
            this.flowLayoutPanel8.TabIndex = 1;
            // 
            // progressBarStatus
            // 
            this.progressBarStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarStatus.Location = new System.Drawing.Point(6, 6);
            this.progressBarStatus.Margin = new System.Windows.Forms.Padding(6);
            this.progressBarStatus.Name = "progressBarStatus";
            this.progressBarStatus.Size = new System.Drawing.Size(1684, 49);
            this.progressBarStatus.TabIndex = 0;
            // 
            // groupBoxEventLog
            // 
            this.groupBoxEventLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxEventLog.Controls.Add(this.textBoxEventLog);
            this.groupBoxEventLog.Location = new System.Drawing.Point(4, 63);
            this.groupBoxEventLog.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBoxEventLog.Name = "groupBoxEventLog";
            this.groupBoxEventLog.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBoxEventLog.Size = new System.Drawing.Size(1696, 209);
            this.groupBoxEventLog.TabIndex = 0;
            this.groupBoxEventLog.TabStop = false;
            this.groupBoxEventLog.Text = "Event Log";
            // 
            // textBoxEventLog
            // 
            this.textBoxEventLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxEventLog.Location = new System.Drawing.Point(4, 34);
            this.textBoxEventLog.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.textBoxEventLog.Multiline = true;
            this.textBoxEventLog.Name = "textBoxEventLog";
            this.textBoxEventLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxEventLog.Size = new System.Drawing.Size(1688, 173);
            this.textBoxEventLog.TabIndex = 0;
            // 
            // openFileDialogSample
            // 
            this.openFileDialogSample.DefaultExt = "json";
            this.openFileDialogSample.Filter = "JSON files|*.json";
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
            // checkBoxFilterNegate
            // 
            this.checkBoxFilterNegate.AutoSize = true;
            this.checkBoxFilterNegate.Location = new System.Drawing.Point(3, 98);
            this.checkBoxFilterNegate.Name = "checkBoxFilterNegate";
            this.checkBoxFilterNegate.Size = new System.Drawing.Size(124, 36);
            this.checkBoxFilterNegate.TabIndex = 4;
            this.checkBoxFilterNegate.Text = "Negate";
            this.checkBoxFilterNegate.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2526, 1308);
            this.Controls.Add(this.splitContainerTopVsBottom);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "Form1";
            this.Text = "JSON Extractor";
            this.splitContainerTopVsBottom.Panel1.ResumeLayout(false);
            this.splitContainerTopVsBottom.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTopVsBottom)).EndInit();
            this.splitContainerTopVsBottom.ResumeLayout(false);
            this.splitContainerAvsBC.Panel1.ResumeLayout(false);
            this.splitContainerAvsBC.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAvsBC)).EndInit();
            this.splitContainerAvsBC.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.flowLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.flowLayoutPanel6.ResumeLayout(false);
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
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.splitContainerC1vsC2.Panel1.ResumeLayout(false);
            this.splitContainerC1vsC2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerC1vsC2)).EndInit();
            this.splitContainerC1vsC2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilters)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttributes)).EndInit();
            this.flowLayoutPanel8.ResumeLayout(false);
            this.groupBoxEventLog.ResumeLayout(false);
            this.groupBoxEventLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerTopVsBottom;
        private System.Windows.Forms.GroupBox groupBoxEventLog;
        private System.Windows.Forms.TextBox textBoxEventLog;
        private System.Windows.Forms.SplitContainer splitContainerAvsBC;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainerBvsC;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.SplitContainer splitContainerC1vsC2;
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonLoadSample;
        private System.Windows.Forms.Button buttonSelectFiles;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonSaveConfig;
        private System.Windows.Forms.Button buttonLoadConfig;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button buttonAddExtractAttribute;
        private System.Windows.Forms.ComboBox comboBoxExtractAttributeAggregateType;
        private System.Windows.Forms.Button buttonExtractAttributeRemove;
        private System.Windows.Forms.Button buttonExtractAttributeUp;
        private System.Windows.Forms.Button buttonExtractAttributeDown;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button buttonFilterAdd;
        private System.Windows.Forms.Button buttonFilterRemove;
        private System.Windows.Forms.TextBox textBoxExtractAttributeLabel;
        private System.Windows.Forms.TextBox textBoxExtractAttributeDefault;
        private System.Windows.Forms.OpenFileDialog openFileDialogSample;
        private System.Windows.Forms.OpenFileDialog openFileDialogInputFiles;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBoxFilterPattern;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label labelSelectedCount;
        private System.Windows.Forms.Label labelProcessedCount;
        private System.Windows.Forms.Label labelFilteredCount;
        private System.Windows.Forms.Label labelExtractedCount;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.Button buttonSelectInputDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogInputDir;
        private System.ComponentModel.BackgroundWorker backgroundWorkerExtraction;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.TextBox textBoxS3Bucket;
        private System.Windows.Forms.TextBox textBoxS3AccessKey;
        private System.Windows.Forms.TextBox textBoxS3SecretKey;
        private System.Windows.Forms.Button buttonS3CacheDir;
        private System.Windows.Forms.Button buttonS3StartSync;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        private System.Windows.Forms.ProgressBar progressBarStatus;
        private System.Windows.Forms.CheckBox checkBoxFilterNegate;
    }
}

