﻿
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
            this.buttonLoadSample = new System.Windows.Forms.Button();
            this.buttonSelectFiles = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonSaveConfig = new System.Windows.Forms.Button();
            this.buttonLoadConfig = new System.Windows.Forms.Button();
            this.splitContainerBvsC = new System.Windows.Forms.SplitContainer();
            this.splitContainerTreeVsOpts = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.treeViewJSON = new System.Windows.Forms.TreeView();
            this.splitContainerFilterVsAttrControls = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBoxFilterType = new System.Windows.Forms.ComboBox();
            this.buttonFilterAdd = new System.Windows.Forms.Button();
            this.buttonFilterRemove = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxAttrLabel = new System.Windows.Forms.TextBox();
            this.comboBoxAttrArrayRollup = new System.Windows.Forms.ComboBox();
            this.buttonAttrAdd = new System.Windows.Forms.Button();
            this.buttonAttrRemove = new System.Windows.Forms.Button();
            this.buttonAttrUp = new System.Windows.Forms.Button();
            this.buttonAttrDown = new System.Windows.Forms.Button();
            this.splitContainerC1vsC2 = new System.Windows.Forms.SplitContainer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataGridViewFilters = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dataGridViewAttributes = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxEventLog = new System.Windows.Forms.TextBox();
            this.textBoxDefault = new System.Windows.Forms.TextBox();
            this.openFileDialogSample = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogInputFiles = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
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
            this.groupBox1.SuspendLayout();
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
            this.splitContainerTopVsBottom.Panel2.Controls.Add(this.groupBox1);
            this.splitContainerTopVsBottom.Size = new System.Drawing.Size(913, 527);
            this.splitContainerTopVsBottom.SplitterDistance = 450;
            this.splitContainerTopVsBottom.SplitterWidth = 2;
            this.splitContainerTopVsBottom.TabIndex = 0;
            // 
            // splitContainerAvsBC
            // 
            this.splitContainerAvsBC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerAvsBC.Location = new System.Drawing.Point(0, 0);
            this.splitContainerAvsBC.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.splitContainerAvsBC.Name = "splitContainerAvsBC";
            // 
            // splitContainerAvsBC.Panel1
            // 
            this.splitContainerAvsBC.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainerAvsBC.Panel2
            // 
            this.splitContainerAvsBC.Panel2.Controls.Add(this.splitContainerBvsC);
            this.splitContainerAvsBC.Size = new System.Drawing.Size(913, 450);
            this.splitContainerAvsBC.SplitterDistance = 111;
            this.splitContainerAvsBC.SplitterWidth = 2;
            this.splitContainerAvsBC.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox2.Size = new System.Drawing.Size(111, 450);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonLoadSample);
            this.flowLayoutPanel1.Controls.Add(this.buttonSelectFiles);
            this.flowLayoutPanel1.Controls.Add(this.buttonStart);
            this.flowLayoutPanel1.Controls.Add(this.buttonSaveConfig);
            this.flowLayoutPanel1.Controls.Add(this.buttonLoadConfig);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 17);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(107, 432);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // buttonLoadSample
            // 
            this.buttonLoadSample.Location = new System.Drawing.Point(2, 1);
            this.buttonLoadSample.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonLoadSample.Name = "buttonLoadSample";
            this.buttonLoadSample.Size = new System.Drawing.Size(93, 22);
            this.buttonLoadSample.TabIndex = 0;
            this.buttonLoadSample.Text = "Load Sample";
            this.buttonLoadSample.UseVisualStyleBackColor = true;
            this.buttonLoadSample.Click += new System.EventHandler(this.buttonLoadSample_Click);
            // 
            // buttonSelectFiles
            // 
            this.buttonSelectFiles.Location = new System.Drawing.Point(2, 25);
            this.buttonSelectFiles.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonSelectFiles.Name = "buttonSelectFiles";
            this.buttonSelectFiles.Size = new System.Drawing.Size(93, 22);
            this.buttonSelectFiles.TabIndex = 1;
            this.buttonSelectFiles.Text = "Select Files";
            this.buttonSelectFiles.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(2, 49);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(93, 22);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            // 
            // buttonSaveConfig
            // 
            this.buttonSaveConfig.Location = new System.Drawing.Point(2, 73);
            this.buttonSaveConfig.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonSaveConfig.Name = "buttonSaveConfig";
            this.buttonSaveConfig.Size = new System.Drawing.Size(93, 22);
            this.buttonSaveConfig.TabIndex = 3;
            this.buttonSaveConfig.Text = "Save Config";
            this.buttonSaveConfig.UseVisualStyleBackColor = true;
            // 
            // buttonLoadConfig
            // 
            this.buttonLoadConfig.Location = new System.Drawing.Point(2, 97);
            this.buttonLoadConfig.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonLoadConfig.Name = "buttonLoadConfig";
            this.buttonLoadConfig.Size = new System.Drawing.Size(93, 22);
            this.buttonLoadConfig.TabIndex = 4;
            this.buttonLoadConfig.Text = "Load Config";
            this.buttonLoadConfig.UseVisualStyleBackColor = true;
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
            this.splitContainerBvsC.Panel2.Controls.Add(this.splitContainerC1vsC2);
            this.splitContainerBvsC.Size = new System.Drawing.Size(800, 450);
            this.splitContainerBvsC.SplitterDistance = 358;
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
            this.splitContainerTreeVsOpts.Size = new System.Drawing.Size(358, 450);
            this.splitContainerTreeVsOpts.SplitterDistance = 238;
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
            this.groupBox3.Size = new System.Drawing.Size(238, 450);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "JSON Attribute Structure";
            // 
            // treeViewJSON
            // 
            this.treeViewJSON.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewJSON.Location = new System.Drawing.Point(2, 17);
            this.treeViewJSON.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.treeViewJSON.Name = "treeViewJSON";
            this.treeViewJSON.Size = new System.Drawing.Size(234, 432);
            this.treeViewJSON.TabIndex = 0;
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
            this.splitContainerFilterVsAttrControls.Size = new System.Drawing.Size(118, 450);
            this.splitContainerFilterVsAttrControls.SplitterDistance = 225;
            this.splitContainerFilterVsAttrControls.SplitterWidth = 2;
            this.splitContainerFilterVsAttrControls.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.flowLayoutPanel3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox4.Size = new System.Drawing.Size(118, 225);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filter";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.comboBoxFilterType);
            this.flowLayoutPanel3.Controls.Add(this.buttonFilterAdd);
            this.flowLayoutPanel3.Controls.Add(this.buttonFilterRemove);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(2, 17);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(114, 207);
            this.flowLayoutPanel3.TabIndex = 3;
            // 
            // comboBoxFilterType
            // 
            this.comboBoxFilterType.FormattingEnabled = true;
            this.comboBoxFilterType.Items.AddRange(new object[] {
            "Equals",
            "Contains",
            "StartsWith",
            "LessThanEqualTo",
            "GreaterThanEqualTo",
            "Empty",
            "NonEmpty"});
            this.comboBoxFilterType.Location = new System.Drawing.Point(2, 1);
            this.comboBoxFilterType.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.comboBoxFilterType.Name = "comboBoxFilterType";
            this.comboBoxFilterType.Size = new System.Drawing.Size(108, 23);
            this.comboBoxFilterType.TabIndex = 0;
            // 
            // buttonFilterAdd
            // 
            this.buttonFilterAdd.Location = new System.Drawing.Point(2, 26);
            this.buttonFilterAdd.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonFilterAdd.Name = "buttonFilterAdd";
            this.buttonFilterAdd.Size = new System.Drawing.Size(81, 22);
            this.buttonFilterAdd.TabIndex = 1;
            this.buttonFilterAdd.Text = "Add";
            this.buttonFilterAdd.UseVisualStyleBackColor = true;
            // 
            // buttonFilterRemove
            // 
            this.buttonFilterRemove.Location = new System.Drawing.Point(2, 50);
            this.buttonFilterRemove.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonFilterRemove.Name = "buttonFilterRemove";
            this.buttonFilterRemove.Size = new System.Drawing.Size(81, 22);
            this.buttonFilterRemove.TabIndex = 2;
            this.buttonFilterRemove.Text = "Remove";
            this.buttonFilterRemove.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.flowLayoutPanel2);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox7.Size = new System.Drawing.Size(118, 223);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Attribute";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.textBoxAttrLabel);
            this.flowLayoutPanel2.Controls.Add(this.comboBoxAttrArrayRollup);
            this.flowLayoutPanel2.Controls.Add(this.buttonAttrAdd);
            this.flowLayoutPanel2.Controls.Add(this.buttonAttrRemove);
            this.flowLayoutPanel2.Controls.Add(this.buttonAttrUp);
            this.flowLayoutPanel2.Controls.Add(this.buttonAttrDown);
            this.flowLayoutPanel2.Controls.Add(this.textBoxDefault);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(2, 17);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(114, 205);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // textBoxAttrLabel
            // 
            this.textBoxAttrLabel.Location = new System.Drawing.Point(2, 1);
            this.textBoxAttrLabel.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBoxAttrLabel.Name = "textBoxAttrLabel";
            this.textBoxAttrLabel.Size = new System.Drawing.Size(110, 23);
            this.textBoxAttrLabel.TabIndex = 6;
            this.textBoxAttrLabel.Text = "label";
            // 
            // comboBoxAttrArrayRollup
            // 
            this.comboBoxAttrArrayRollup.FormattingEnabled = true;
            this.comboBoxAttrArrayRollup.Items.AddRange(new object[] {
            "Count",
            "Sum",
            "Mean",
            "StdDev",
            "Min",
            "Max",
            "TableRows",
            "TableCols"});
            this.comboBoxAttrArrayRollup.Location = new System.Drawing.Point(2, 26);
            this.comboBoxAttrArrayRollup.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.comboBoxAttrArrayRollup.Name = "comboBoxAttrArrayRollup";
            this.comboBoxAttrArrayRollup.Size = new System.Drawing.Size(108, 23);
            this.comboBoxAttrArrayRollup.TabIndex = 2;
            // 
            // buttonAttrAdd
            // 
            this.buttonAttrAdd.Location = new System.Drawing.Point(2, 51);
            this.buttonAttrAdd.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonAttrAdd.Name = "buttonAttrAdd";
            this.buttonAttrAdd.Size = new System.Drawing.Size(81, 22);
            this.buttonAttrAdd.TabIndex = 1;
            this.buttonAttrAdd.Text = "Add";
            this.buttonAttrAdd.UseVisualStyleBackColor = true;
            // 
            // buttonAttrRemove
            // 
            this.buttonAttrRemove.Location = new System.Drawing.Point(2, 75);
            this.buttonAttrRemove.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonAttrRemove.Name = "buttonAttrRemove";
            this.buttonAttrRemove.Size = new System.Drawing.Size(81, 22);
            this.buttonAttrRemove.TabIndex = 3;
            this.buttonAttrRemove.Text = "Remove";
            this.buttonAttrRemove.UseVisualStyleBackColor = true;
            // 
            // buttonAttrUp
            // 
            this.buttonAttrUp.Location = new System.Drawing.Point(2, 99);
            this.buttonAttrUp.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonAttrUp.Name = "buttonAttrUp";
            this.buttonAttrUp.Size = new System.Drawing.Size(81, 22);
            this.buttonAttrUp.TabIndex = 4;
            this.buttonAttrUp.Text = "Up";
            this.buttonAttrUp.UseVisualStyleBackColor = true;
            // 
            // buttonAttrDown
            // 
            this.buttonAttrDown.Location = new System.Drawing.Point(2, 123);
            this.buttonAttrDown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonAttrDown.Name = "buttonAttrDown";
            this.buttonAttrDown.Size = new System.Drawing.Size(81, 22);
            this.buttonAttrDown.TabIndex = 5;
            this.buttonAttrDown.Text = "Down";
            this.buttonAttrDown.UseVisualStyleBackColor = true;
            // 
            // splitContainerC1vsC2
            // 
            this.splitContainerC1vsC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerC1vsC2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerC1vsC2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.splitContainerC1vsC2.Size = new System.Drawing.Size(440, 450);
            this.splitContainerC1vsC2.SplitterDistance = 196;
            this.splitContainerC1vsC2.SplitterWidth = 2;
            this.splitContainerC1vsC2.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataGridViewFilters);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox5.Size = new System.Drawing.Size(440, 196);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Filters on Selected JSON Files";
            // 
            // dataGridViewFilters
            // 
            this.dataGridViewFilters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFilters.Location = new System.Drawing.Point(2, 17);
            this.dataGridViewFilters.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dataGridViewFilters.Name = "dataGridViewFilters";
            this.dataGridViewFilters.RowHeadersWidth = 82;
            this.dataGridViewFilters.RowTemplate.Height = 41;
            this.dataGridViewFilters.Size = new System.Drawing.Size(436, 178);
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
            this.groupBox6.Size = new System.Drawing.Size(440, 252);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Attributes to Extract";
            // 
            // dataGridViewAttributes
            // 
            this.dataGridViewAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAttributes.Location = new System.Drawing.Point(2, 17);
            this.dataGridViewAttributes.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dataGridViewAttributes.Name = "dataGridViewAttributes";
            this.dataGridViewAttributes.RowHeadersWidth = 82;
            this.dataGridViewAttributes.RowTemplate.Height = 41;
            this.dataGridViewAttributes.Size = new System.Drawing.Size(436, 234);
            this.dataGridViewAttributes.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxEventLog);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox1.Size = new System.Drawing.Size(913, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Event Log";
            // 
            // textBoxEventLog
            // 
            this.textBoxEventLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxEventLog.Location = new System.Drawing.Point(2, 17);
            this.textBoxEventLog.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBoxEventLog.Multiline = true;
            this.textBoxEventLog.Name = "textBoxEventLog";
            this.textBoxEventLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxEventLog.Size = new System.Drawing.Size(909, 57);
            this.textBoxEventLog.TabIndex = 0;
            // 
            // textBoxDefault
            // 
            this.textBoxDefault.Location = new System.Drawing.Point(3, 149);
            this.textBoxDefault.Name = "textBoxDefault";
            this.textBoxDefault.Size = new System.Drawing.Size(100, 23);
            this.textBoxDefault.TabIndex = 7;
            this.textBoxDefault.Text = "default";
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
            this.openFileDialogInputFiles.Filter = "JSON files|*.json";
            this.openFileDialogInputFiles.Multiselect = true;
            this.openFileDialogInputFiles.ShowReadOnly = true;
            this.openFileDialogInputFiles.SupportMultiDottedExtensions = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 527);
            this.Controls.Add(this.splitContainerTopVsBottom);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerTopVsBottom;
        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.Button buttonAttrAdd;
        private System.Windows.Forms.ComboBox comboBoxAttrArrayRollup;
        private System.Windows.Forms.Button buttonAttrRemove;
        private System.Windows.Forms.Button buttonAttrUp;
        private System.Windows.Forms.Button buttonAttrDown;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button buttonFilterAdd;
        private System.Windows.Forms.Button buttonFilterRemove;
        private System.Windows.Forms.TextBox textBoxAttrLabel;
        private System.Windows.Forms.TextBox textBoxDefault;
        private System.Windows.Forms.OpenFileDialog openFileDialogSample;
        private System.Windows.Forms.OpenFileDialog openFileDialogInputFiles;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
