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
    public partial class MapVersionEditor : Form
    {
        public MapVersionEditor()
        {
            InitializeComponent();
        }

        public MapVersionEditor(MapVersion mapVersion, string[] availableImages)
            : this()
        {
            this.NameTextBox.Text = mapVersion.Name;
            this.CoordsFileTextBox.Text = mapVersion.CoordsFile;
            this.AvailableImages.Items.Clear();
            switch (mapVersion.Type)
            {
                case MapType.Rubika: 
                    this.TypeRadioRubika.Checked = true;
                    break;
                case MapType.Shadowlands: 
                    this.TypeRadioShadowlands.Checked = true;
                    break;
            }

            for (int i = 0; i < availableImages.Length; i++)
            {
                if (!mapVersion.Images.Contains(availableImages[i]))
                {
                    this.AvailableImages.Items.Add(availableImages[i]);
                }
                else
                {
                    this.SelectedImages.Items.Add(availableImages[i]);
                }
            }
        }

        internal void StoreConfig(MapVersion mv)
        {
            mv.CoordsFile = this.CoordsFileTextBox.Text;
            mv.File = this.FileTextBox.Text;
            mv.Name = this.NameTextBox.Text;
            if (this.TypeRadioRubika.Checked)
            {
                mv.Type = MapType.Rubika;
            }
            else
            {
                mv.Type = MapType.Shadowlands;
            }

            List<string> selectedImages = new List<string>();
            foreach (var item in this.SelectedImages.Items)
            {
                selectedImages.Add((string)item);
            }
            mv.Images = selectedImages.ToArray();
        }

        private void SelectImageButton_Click(object sender, EventArgs e)
        {
            this.SelectedImages.BeginUpdate();
            this.AvailableImages.BeginUpdate();
            foreach (int index in this.AvailableImages.SelectedIndices)
            {
                string image = (string)this.AvailableImages.Items[index];
                this.AvailableImages.Items.RemoveAt(index);
                this.SelectedImages.Items.Add(image);
            }
            this.SelectedImages.EndUpdate();
            this.AvailableImages.EndUpdate();
        }

        private void DeselectImageButton_Click(object sender, EventArgs e)
        {
            this.SelectedImages.BeginUpdate();
            this.AvailableImages.BeginUpdate();
            foreach (int index in this.SelectedImages.SelectedIndices)
            {
                string image = (string)this.SelectedImages.Items[index];
                this.SelectedImages.Items.RemoveAt(index);
                this.AvailableImages.Items.Add(image);
            }
            this.SelectedImages.EndUpdate();
            this.AvailableImages.EndUpdate();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
