namespace Aomc.GUI.Controls
{
    partial class ImagesUserControl
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
            this.ImageList = new System.Windows.Forms.ListView();
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PathColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ImageListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageListOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ImageListContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.AllowDrop = true;
            this.ImageList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn,
            this.PathColumn});
            this.ImageList.ContextMenuStrip = this.ImageListContextMenu;
            this.ImageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageList.FullRowSelect = true;
            this.ImageList.GridLines = true;
            this.ImageList.Location = new System.Drawing.Point(0, 0);
            this.ImageList.Name = "ImageList";
            this.ImageList.Size = new System.Drawing.Size(336, 136);
            this.ImageList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ImageList.TabIndex = 0;
            this.ImageList.UseCompatibleStateImageBehavior = false;
            this.ImageList.View = System.Windows.Forms.View.Details;
            this.ImageList.DragDrop += new System.Windows.Forms.DragEventHandler(this.ImageListDragDrop);
            this.ImageList.DragEnter += new System.Windows.Forms.DragEventHandler(this.ImageListDragEnter);
            this.ImageList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ImageListKeyDown);
            this.ImageList.Resize += new System.EventHandler(this.ImageListResize);
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            this.NameColumn.Width = 94;
            // 
            // PathColumn
            // 
            this.PathColumn.Text = "Path";
            this.PathColumn.Width = 366;
            // 
            // ImageListContextMenu
            // 
            this.ImageListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.ImageListContextMenu.Name = "ImageListContextMenu";
            this.ImageListContextMenu.Size = new System.Drawing.Size(108, 70);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
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
            // ImageListOpenFileDialog
            // 
            this.ImageListOpenFileDialog.Filter = "PNG Image|*.png";
            this.ImageListOpenFileDialog.Multiselect = true;
            // 
            // ImagesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ImageList);
            this.Name = "ImagesUserControl";
            this.Size = new System.Drawing.Size(336, 136);
            this.ImageListContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ImageList;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader PathColumn;
        private System.Windows.Forms.ContextMenuStrip ImageListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ImageListOpenFileDialog;
    }
}
