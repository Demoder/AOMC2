namespace Aomc.GUI.Controls
{
    partial class BinWriterTaskUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BinWriterTaskList = new System.Windows.Forms.ListView();
            this.NameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MapRectHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ImagesHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BinWriterTaskContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BinWriterTaskContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // BinWriterTaskList
            // 
            this.BinWriterTaskList.AllowDrop = true;
            this.BinWriterTaskList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHeader,
            this.MapRectHeader,
            this.ImagesHeader});
            this.BinWriterTaskList.ContextMenuStrip = this.BinWriterTaskContextMenuStrip;
            this.BinWriterTaskList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BinWriterTaskList.FullRowSelect = true;
            this.BinWriterTaskList.GridLines = true;
            this.BinWriterTaskList.Location = new System.Drawing.Point(0, 0);
            this.BinWriterTaskList.Name = "BinWriterTaskList";
            this.BinWriterTaskList.Size = new System.Drawing.Size(430, 247);
            this.BinWriterTaskList.TabIndex = 0;
            this.BinWriterTaskList.UseCompatibleStateImageBehavior = false;
            this.BinWriterTaskList.View = System.Windows.Forms.View.Details;
            this.BinWriterTaskList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.BinWriterTaskList_ItemDrag);
            this.BinWriterTaskList.DragDrop += new System.Windows.Forms.DragEventHandler(this.BinWriterTaskList_DragDrop);
            this.BinWriterTaskList.DragEnter += new System.Windows.Forms.DragEventHandler(this.BinWriterTaskList_DragEnter);
            // 
            // NameHeader
            // 
            this.NameHeader.Text = "Name";
            this.NameHeader.Width = 104;
            // 
            // MapRectHeader
            // 
            this.MapRectHeader.Text = "MapRect";
            this.MapRectHeader.Width = 88;
            // 
            // ImagesHeader
            // 
            this.ImagesHeader.Text = "Images";
            this.ImagesHeader.Width = 137;
            // 
            // BinWriterTaskContextMenuStrip
            // 
            this.BinWriterTaskContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.BinWriterTaskContextMenuStrip.Name = "BinWriterTaskContextMenuStrip";
            this.BinWriterTaskContextMenuStrip.Size = new System.Drawing.Size(108, 70);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // BinWriterTaskUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BinWriterTaskList);
            this.Name = "BinWriterTaskUserControl";
            this.Size = new System.Drawing.Size(430, 247);
            this.BinWriterTaskContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView BinWriterTaskList;
        private System.Windows.Forms.ColumnHeader NameHeader;
        private System.Windows.Forms.ColumnHeader MapRectHeader;
        private System.Windows.Forms.ColumnHeader ImagesHeader;
        private System.Windows.Forms.ContextMenuStrip BinWriterTaskContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}
