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

using Demoder.MapCompiler.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aomc.GUI.Forms
{
    public partial class BinWriterTaskEditor : Form
    {
        public BinWriterTaskEditor()
        {
            InitializeComponent();
        }

        public BinWriterTaskEditor(BinWriterTask task, string[] availableImages)
            : this()
        {
            this.ImageListBox.Items.AddRange(availableImages);
            this.NameTextBox.Text = task.DisplayName;
            this.MapRectTextBox.Text = task.MapRect;
            for (int i = 0; i < this.ImageListBox.Items.Count; i++)
            {
                if (!task.Images.Contains(this.ImageListBox.Items[i])) { continue; }
                this.ImageListBox.SetSelected(i, true);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        internal void StoreConfig(BinWriterTask task)
        {
            List<string> selectedImages = new List<string>();
            foreach (var item in this.ImageListBox.SelectedItems)
            {
                selectedImages.Add((string)item);
            }

            task.DisplayName = this.NameTextBox.Text;
            task.MapRect = this.MapRectTextBox.Text;
            task.Images = selectedImages.ToArray();
        }
    }
}
