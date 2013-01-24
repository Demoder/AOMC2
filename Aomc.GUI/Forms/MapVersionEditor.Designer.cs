namespace Aomc.GUI.Forms
{
    partial class MapVersionEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FileTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CoordsFileTextBox = new System.Windows.Forms.TextBox();
            this.TypeRadioRubika = new System.Windows.Forms.RadioButton();
            this.TypeRadioShadowlands = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AvailableImages = new System.Windows.Forms.ListBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.SelectedImages = new System.Windows.Forms.ListBox();
            this.SelectImageButton = new System.Windows.Forms.Button();
            this.DeselectImageButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(74, 6);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(245, 20);
            this.NameTextBox.TabIndex = 1;
            this.NameTextBox.Text = "My map, RK2! {version}";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "File";
            // 
            // FileTextBox
            // 
            this.FileTextBox.Location = new System.Drawing.Point(74, 37);
            this.FileTextBox.Name = "FileTextBox";
            this.FileTextBox.Size = new System.Drawing.Size(245, 20);
            this.FileTextBox.TabIndex = 3;
            this.FileTextBox.Text = "MyMap.txt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "CoordsFile";
            // 
            // CoordsFileTextBox
            // 
            this.CoordsFileTextBox.Location = new System.Drawing.Point(74, 66);
            this.CoordsFileTextBox.Name = "CoordsFileTextBox";
            this.CoordsFileTextBox.Size = new System.Drawing.Size(245, 20);
            this.CoordsFileTextBox.TabIndex = 5;
            this.CoordsFileTextBox.Text = "MapCoordinates.xml";
            // 
            // TypeRadioRubika
            // 
            this.TypeRadioRubika.AutoSize = true;
            this.TypeRadioRubika.Checked = true;
            this.TypeRadioRubika.Location = new System.Drawing.Point(74, 92);
            this.TypeRadioRubika.Name = "TypeRadioRubika";
            this.TypeRadioRubika.Size = new System.Drawing.Size(59, 17);
            this.TypeRadioRubika.TabIndex = 6;
            this.TypeRadioRubika.TabStop = true;
            this.TypeRadioRubika.Text = "Rubika";
            this.TypeRadioRubika.UseVisualStyleBackColor = true;
            // 
            // TypeRadioShadowlands
            // 
            this.TypeRadioShadowlands.AutoSize = true;
            this.TypeRadioShadowlands.Location = new System.Drawing.Point(139, 92);
            this.TypeRadioShadowlands.Name = "TypeRadioShadowlands";
            this.TypeRadioShadowlands.Size = new System.Drawing.Size(89, 17);
            this.TypeRadioShadowlands.TabIndex = 7;
            this.TypeRadioShadowlands.Text = "Shadowlands";
            this.TypeRadioShadowlands.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Type";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.DeselectImageButton);
            this.groupBox1.Controls.Add(this.SelectImageButton);
            this.groupBox1.Controls.Add(this.SelectedImages);
            this.groupBox1.Controls.Add(this.AvailableImages);
            this.groupBox1.Location = new System.Drawing.Point(12, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 136);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Images";
            // 
            // AvailableImages
            // 
            this.AvailableImages.FormattingEnabled = true;
            this.AvailableImages.Location = new System.Drawing.Point(3, 29);
            this.AvailableImages.MultiColumn = true;
            this.AvailableImages.Name = "AvailableImages";
            this.AvailableImages.Size = new System.Drawing.Size(118, 95);
            this.AvailableImages.Sorted = true;
            this.AvailableImages.TabIndex = 0;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(154, 256);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 11;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(63, 256);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 10;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // SelectedImages
            // 
            this.SelectedImages.FormattingEnabled = true;
            this.SelectedImages.Location = new System.Drawing.Point(181, 29);
            this.SelectedImages.Name = "SelectedImages";
            this.SelectedImages.Size = new System.Drawing.Size(120, 95);
            this.SelectedImages.TabIndex = 1;
            // 
            // SelectImageButton
            // 
            this.SelectImageButton.Location = new System.Drawing.Point(127, 45);
            this.SelectImageButton.Name = "SelectImageButton";
            this.SelectImageButton.Size = new System.Drawing.Size(48, 23);
            this.SelectImageButton.TabIndex = 2;
            this.SelectImageButton.Text = ">>";
            this.SelectImageButton.UseVisualStyleBackColor = true;
            this.SelectImageButton.Click += new System.EventHandler(this.SelectImageButton_Click);
            // 
            // DeselectImageButton
            // 
            this.DeselectImageButton.Location = new System.Drawing.Point(127, 85);
            this.DeselectImageButton.Name = "DeselectImageButton";
            this.DeselectImageButton.Size = new System.Drawing.Size(48, 23);
            this.DeselectImageButton.TabIndex = 3;
            this.DeselectImageButton.Text = "<<";
            this.DeselectImageButton.UseVisualStyleBackColor = true;
            this.DeselectImageButton.Click += new System.EventHandler(this.DeselectImageButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Available";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(217, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Selected";
            // 
            // MapVersionEditor
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton;
            this.ClientSize = new System.Drawing.Size(331, 284);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TypeRadioShadowlands);
            this.Controls.Add(this.TypeRadioRubika);
            this.Controls.Add(this.CoordsFileTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FileTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MapVersionEditor";
            this.Text = "Map Version Editor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.ListBox AvailableImages;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OkButton;
        internal System.Windows.Forms.TextBox NameTextBox;
        internal System.Windows.Forms.TextBox FileTextBox;
        internal System.Windows.Forms.TextBox CoordsFileTextBox;
        internal System.Windows.Forms.RadioButton TypeRadioRubika;
        internal System.Windows.Forms.RadioButton TypeRadioShadowlands;
        private System.Windows.Forms.ListBox SelectedImages;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button DeselectImageButton;
        private System.Windows.Forms.Button SelectImageButton;
    }
}