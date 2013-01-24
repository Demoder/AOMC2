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
using Demoder.MapCompiler.Data;
using Aomc.GUI.Forms;

namespace Aomc.GUI.Controls
{
    public partial class MapUserControl : UserControl
    {
        internal MainWindow MainWindow { get; set; }

        public MapUserControl()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapVersion mv = new MapVersion();
            var box = new MapVersionEditor(mv, this.MainWindow.ImagesUserControl.AvailableImages);
            var dr = box.ShowDialog();
            if (dr != DialogResult.OK) { return; }
            box.StoreConfig(mv);
            this.MapVersionList.Items.Add(this.CreateLvi(mv));
        }

        

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in this.MapVersionList.SelectedItems)
            {
                MapVersion mapVersion = (MapVersion)lvi.Tag;
                var box = new MapVersionEditor(mapVersion, this.MainWindow.ImagesUserControl.AvailableImages);

                var dr = box.ShowDialog();
                if (dr != DialogResult.OK) { return; }
                box.StoreConfig(mapVersion);
                lvi.SubItems[0].Text = mapVersion.Name;
                lvi.SubItems[1].Text = mapVersion.Type.ToString();
                lvi.SubItems[2].Text = mapVersion.File;
                lvi.SubItems[3].Text = mapVersion.CoordsFile;
                lvi.SubItems[4].Text = String.Join(", ",mapVersion.Name);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MapVersionList.BeginUpdate();
            foreach (ListViewItem lvi in this.MapVersionList.SelectedItems)
            {
                this.MapVersionList.Items.Remove(lvi);
            }
            this.MapVersionList.EndUpdate();
        }


        private ListViewItem CreateLvi(MapVersion mv)
        {
            ListViewItem lvi = new ListViewItem(new string[]
            {
                mv.Name,
                mv.Type.ToString(),
                mv.File,
                mv.CoordsFile,
                String.Join(", ", mv.Images)
            });
            lvi.Tag = mv;
            return lvi;
        }

        internal void RenameImage(string oldName, string newName)
        {
            foreach (ListViewItem lvi in this.MapVersionList.Items)
            {
                MapVersion mapVersion = (MapVersion)lvi.Tag;
                bool change = false;
                for (int i = 0; i < mapVersion.Images.Length; i++)
                {
                    if (mapVersion.Images[i] == oldName)
                    {
                        mapVersion.Images[i] = newName;
                        change = true;
                    }
                }
                if (change)
                {
                    lvi.SubItems[2].Text = String.Join(", ", mapVersion.Images);
                }
            }
        }

        internal void ApplyConfig(CompileConfig config)
        {
            foreach (MapVersion mapVersion in config.Maps)
            {
                this.MapVersionList.Items.Add(this.CreateLvi(mapVersion));
            }
        }

        internal void Save(CompileConfig config)
        {
            config.Maps = new List<MapVersion>();
            foreach (ListViewItem lvi in this.MapVersionList.Items)
            {
                config.Maps.Add((MapVersion)lvi.Tag);
            }
        }
    }
}
