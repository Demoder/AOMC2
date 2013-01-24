/*
Anarchy Online Map Compiler
Copyright (c) 2013 Demoder <demoder@demoder.me>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Aomc.GUI.Forms;
using Demoder.MapCompiler.Data;

namespace Aomc.GUI.Controls
{
    public partial class ImagesUserControl : UserControl
    {
        public event ImageNameChangeEventHandler ImageNameChange;

        public ImagesUserControl()
        {
            InitializeComponent();
        }

        #region Drag & Drop
        private void ImageListDragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files == null || files.Length == 0) { return; }
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (!fi.Extension.Equals(".png", StringComparison.InvariantCultureIgnoreCase))
                {
                    continue;
                }

                this.AddImage(fi);
            }
        }

        private void ImageListDragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files == null || files.Length == 0)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            bool accept = false;
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.Extension.Equals(".png", StringComparison.InvariantCultureIgnoreCase))
                {
                    accept = true;
                }
            }

            if (accept)
            {
                e.Effect = DragDropEffects.Link;
                return;
            }
            e.Effect = DragDropEffects.None;

        }
        #endregion


        public void Save(CompileConfig config)
        {
            config.Images.Clear();
            foreach (ListViewItem img in this.ImageList.Items)
            {
                config.Images.Add(new ImageDefinition
                {
                    Name = img.SubItems[0].Text,
                    Path = img.SubItems[1].Text
                });
            }
        }

        private void AddImage(FileInfo image)
        {
            string name = image.Name.Substring(0, image.Name.Length - image.Extension.Length);
            string path = image.FullName;

            this.AddImage(name, path);
            
        }

        private void AddImage(string name, string path)
        {
            foreach (ListViewItem control in this.ImageList.Items)
            {
                if (control.Text.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    MessageBox.Show(string.Format("Name: {0}", name), "Duplicate image name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (control.SubItems[1].Text.Equals(path, StringComparison.InvariantCultureIgnoreCase))
                {
                    MessageBox.Show(string.Format("An image with the name \"{0}\" is already assigned to path {1}", control.Text, path), "Duplicate image path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            this.ImageList.Items.Add(new ListViewItem(new string[] { name, path }));
        }

        private void ImageListResize(object sender, EventArgs e)
        {
            this.ImageList.BeginUpdate();
            this.ImageList.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            if (this.ImageList.Columns[0].Width < 100)
            {
                this.ImageList.Columns[0].Width = 100;
            }
            this.ImageList.Columns[1].Width = this.ImageList.Width - this.ImageList.Columns[0].Width-30;
            this.ImageList.EndUpdate();
        }

        private void ImageListKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
            {
                return;
            }
            this.ImageListDeleteSelection();
        }

        private void ImageListDeleteSelection()
        {
            if (this.ImageList.SelectedItems.Count == 0)
            {
                return;
            }
            this.ImageList.BeginUpdate();
            foreach (ListViewItem item in this.ImageList.SelectedItems)
            {
                this.ImageList.Items.Remove(item);
            }
            this.ImageList.EndUpdate();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = this.ImageListOpenFileDialog.ShowDialog();
            if (res != DialogResult.OK) { return; }
            foreach (var file in this.ImageListOpenFileDialog.FileNames)
            {
                this.AddImage(new FileInfo(file));
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ImageListDeleteSelection();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ImageList.BeginUpdate();
            foreach (ListViewItem lvi in this.ImageList.SelectedItems)
            {
                var box = new Forms.ImageListEntryEditor();
                box.NameTextBox.Text = lvi.SubItems[0].Text;
                box.PathTextBox.Text = lvi.SubItems[1].Text;
                if (box.ShowDialog() != DialogResult.OK)
                {
                    continue;
                }
                if (!box.NameTextBox.Text.Equals(lvi.SubItems[0].Text))
                {
                    this.SendImageNameChangeEvent(
                        lvi.SubItems[0].Text,
                        box.NameTextBox.Text);
                    lvi.SubItems[0].Text = box.NameTextBox.Text;
                }
                if (!box.PathTextBox.Text.Equals(lvi.SubItems[1].Text))
                {
                    lvi.SubItems[1].Text = box.PathTextBox.Text;
                }
            }
            this.ImageList.Sort();
            this.ImageList.EndUpdate();
        }

        private void SendImageNameChangeEvent(string oldName, string newName)
        {
            var e = this.ImageNameChange;
            if (e == null) { return; }
            e(oldName, newName);
        }

        internal void ApplyConfig(CompileConfig config)
        {
            this.ImageList.BeginUpdate();
            this.ImageList.Items.Clear();
            foreach (var img in config.Images)
            {
                this.AddImage(img.Name, img.Path);
            }
            this.ImageList.EndUpdate();
        }

        internal string[] AvailableImages
        {
            get
            {
                List<string> images = new List<string>();
                foreach (ListViewItem lvi in this.ImageList.Items)
                {
                    images.Add(lvi.Text);
                }
                return images.ToArray();
            }
        }
    }

    public delegate void ImageNameChangeEventHandler(string oldName, string newName);
}
