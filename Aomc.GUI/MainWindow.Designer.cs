namespace Aomc.GUI
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.CompilerSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.ThreadCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CompileButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MapUserControl = new Aomc.GUI.Controls.MapUserControl();
            this.binWriterTaskGroupBox = new System.Windows.Forms.GroupBox();
            this.BinWriterTaskUserControl = new Aomc.GUI.Controls.BinWriterTaskUserControl();
            this.imagesGroupBox = new System.Windows.Forms.GroupBox();
            this.ImagesUserControl = new Aomc.GUI.Controls.ImagesUserControl();
            this.mapInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.MapVersionTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MapSubfolder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BinName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveConfigDialog = new System.Windows.Forms.SaveFileDialog();
            this.OpenConfigDialog = new System.Windows.Forms.OpenFileDialog();
            this.CompileWorker = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.CompilerSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThreadCount)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.binWriterTaskGroupBox.SuspendLayout();
            this.imagesGroupBox.SuspendLayout();
            this.mapInfoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(642, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.CompilerSettingsGroupBox);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.CompileButton);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.groupBox1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.binWriterTaskGroupBox);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.imagesGroupBox);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.mapInfoGroupBox);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(642, 625);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(642, 649);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // CompilerSettingsGroupBox
            // 
            this.CompilerSettingsGroupBox.Controls.Add(this.ThreadCount);
            this.CompilerSettingsGroupBox.Controls.Add(this.label1);
            this.CompilerSettingsGroupBox.Controls.Add(this.OutputTextBox);
            this.CompilerSettingsGroupBox.Controls.Add(this.label5);
            this.CompilerSettingsGroupBox.Location = new System.Drawing.Point(326, 3);
            this.CompilerSettingsGroupBox.Name = "CompilerSettingsGroupBox";
            this.CompilerSettingsGroupBox.Size = new System.Drawing.Size(308, 100);
            this.CompilerSettingsGroupBox.TabIndex = 5;
            this.CompilerSettingsGroupBox.TabStop = false;
            this.CompilerSettingsGroupBox.Text = "Compiler Settings";
            // 
            // ThreadCount
            // 
            this.ThreadCount.Location = new System.Drawing.Point(72, 39);
            this.ThreadCount.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.ThreadCount.Name = "ThreadCount";
            this.ThreadCount.Size = new System.Drawing.Size(47, 20);
            this.ThreadCount.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Threads";
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Location = new System.Drawing.Point(72, 13);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.Size = new System.Drawing.Size(226, 20);
            this.OutputTextBox.TabIndex = 11;
            this.OutputTextBox.Text = "d:\\tmp\\mapout";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Output";
            // 
            // CompileButton
            // 
            this.CompileButton.Location = new System.Drawing.Point(286, 590);
            this.CompileButton.Name = "CompileButton";
            this.CompileButton.Size = new System.Drawing.Size(75, 23);
            this.CompileButton.TabIndex = 4;
            this.CompileButton.Text = "Compile";
            this.CompileButton.UseVisualStyleBackColor = true;
            this.CompileButton.Click += new System.EventHandler(this.CompileButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.MapUserControl);
            this.groupBox1.Location = new System.Drawing.Point(5, 401);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(625, 179);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Map Definitions";
            // 
            // MapUserControl
            // 
            this.MapUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapUserControl.Location = new System.Drawing.Point(3, 16);
            this.MapUserControl.Name = "MapUserControl";
            this.MapUserControl.Size = new System.Drawing.Size(619, 160);
            this.MapUserControl.TabIndex = 0;
            // 
            // binWriterTaskGroupBox
            // 
            this.binWriterTaskGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.binWriterTaskGroupBox.Controls.Add(this.BinWriterTaskUserControl);
            this.binWriterTaskGroupBox.Location = new System.Drawing.Point(5, 246);
            this.binWriterTaskGroupBox.Name = "binWriterTaskGroupBox";
            this.binWriterTaskGroupBox.Size = new System.Drawing.Size(628, 149);
            this.binWriterTaskGroupBox.TabIndex = 2;
            this.binWriterTaskGroupBox.TabStop = false;
            this.binWriterTaskGroupBox.Text = "BinWriter Tasks";
            // 
            // BinWriterTaskUserControl
            // 
            this.BinWriterTaskUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BinWriterTaskUserControl.Location = new System.Drawing.Point(3, 16);
            this.BinWriterTaskUserControl.Name = "BinWriterTaskUserControl";
            this.BinWriterTaskUserControl.Size = new System.Drawing.Size(622, 130);
            this.BinWriterTaskUserControl.TabIndex = 0;
            // 
            // imagesGroupBox
            // 
            this.imagesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imagesGroupBox.Controls.Add(this.ImagesUserControl);
            this.imagesGroupBox.Location = new System.Drawing.Point(5, 107);
            this.imagesGroupBox.Name = "imagesGroupBox";
            this.imagesGroupBox.Size = new System.Drawing.Size(628, 130);
            this.imagesGroupBox.TabIndex = 1;
            this.imagesGroupBox.TabStop = false;
            this.imagesGroupBox.Text = "Images";
            // 
            // ImagesUserControl
            // 
            this.ImagesUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImagesUserControl.Location = new System.Drawing.Point(3, 16);
            this.ImagesUserControl.Name = "ImagesUserControl";
            this.ImagesUserControl.Size = new System.Drawing.Size(622, 111);
            this.ImagesUserControl.TabIndex = 0;
            // 
            // mapInfoGroupBox
            // 
            this.mapInfoGroupBox.Controls.Add(this.MapVersionTextBox);
            this.mapInfoGroupBox.Controls.Add(this.label3);
            this.mapInfoGroupBox.Controls.Add(this.MapSubfolder);
            this.mapInfoGroupBox.Controls.Add(this.label4);
            this.mapInfoGroupBox.Controls.Add(this.BinName);
            this.mapInfoGroupBox.Controls.Add(this.label2);
            this.mapInfoGroupBox.Location = new System.Drawing.Point(12, 3);
            this.mapInfoGroupBox.Name = "mapInfoGroupBox";
            this.mapInfoGroupBox.Size = new System.Drawing.Size(308, 99);
            this.mapInfoGroupBox.TabIndex = 0;
            this.mapInfoGroupBox.TabStop = false;
            this.mapInfoGroupBox.Text = "Map Information";
            // 
            // MapVersionTextBox
            // 
            this.MapVersionTextBox.Location = new System.Drawing.Point(72, 67);
            this.MapVersionTextBox.Name = "MapVersionTextBox";
            this.MapVersionTextBox.Size = new System.Drawing.Size(226, 20);
            this.MapVersionTextBox.TabIndex = 11;
            this.MapVersionTextBox.Text = "1.2.3.4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Version";
            // 
            // MapSubfolder
            // 
            this.MapSubfolder.Location = new System.Drawing.Point(72, 43);
            this.MapSubfolder.Name = "MapSubfolder";
            this.MapSubfolder.Size = new System.Drawing.Size(226, 20);
            this.MapSubfolder.TabIndex = 9;
            this.MapSubfolder.Text = "AoRK";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Subfolder";
            // 
            // BinName
            // 
            this.BinName.AcceptsReturn = true;
            this.BinName.Location = new System.Drawing.Point(72, 19);
            this.BinName.Name = "BinName";
            this.BinName.Size = new System.Drawing.Size(226, 20);
            this.BinName.TabIndex = 3;
            this.BinName.Text = "AoRK.bin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "BinName";
            // 
            // SaveConfigDialog
            // 
            this.SaveConfigDialog.Filter = "AOMC Config|*.aomc.xml";
            this.SaveConfigDialog.SupportMultiDottedExtensions = true;
            // 
            // OpenConfigDialog
            // 
            this.OpenConfigDialog.Filter = "AOMC Config|*.aomc.xml";
            this.OpenConfigDialog.ReadOnlyChecked = true;
            this.OpenConfigDialog.SupportMultiDottedExtensions = true;
            // 
            // CompileWorker
            // 
            this.CompileWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CompileWorker_DoWork);
            this.CompileWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.CompileWorker_RunWorkerCompleted);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 649);
            this.Controls.Add(this.toolStripContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(658, 687);
            this.MinimumSize = new System.Drawing.Size(658, 687);
            this.Name = "MainWindow";
            this.Text = "Anarchy Online Map Compiler";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.CompilerSettingsGroupBox.ResumeLayout(false);
            this.CompilerSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThreadCount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.binWriterTaskGroupBox.ResumeLayout(false);
            this.imagesGroupBox.ResumeLayout(false);
            this.mapInfoGroupBox.ResumeLayout(false);
            this.mapInfoGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.GroupBox mapInfoGroupBox;
        private System.Windows.Forms.TextBox BinName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MapSubfolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox imagesGroupBox;
        private System.Windows.Forms.GroupBox binWriterTaskGroupBox;
        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.Label label5;
        private Controls.BinWriterTaskUserControl BinWriterTaskUserControl;
        internal Controls.ImagesUserControl ImagesUserControl;
        private System.Windows.Forms.SaveFileDialog SaveConfigDialog;
        private System.Windows.Forms.OpenFileDialog OpenConfigDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.MapUserControl MapUserControl;
        private System.Windows.Forms.Button CompileButton;
        private System.ComponentModel.BackgroundWorker CompileWorker;
        private System.Windows.Forms.GroupBox CompilerSettingsGroupBox;
        private System.Windows.Forms.NumericUpDown ThreadCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MapVersionTextBox;
        private System.Windows.Forms.Label label3;
    }
}

