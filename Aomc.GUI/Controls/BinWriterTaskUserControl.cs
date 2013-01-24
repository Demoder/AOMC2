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
using Aomc.GUI.Forms;
using Demoder.MapCompiler.Data;

namespace Aomc.GUI.Controls
{
    public partial class BinWriterTaskUserControl : UserControl
    {
        internal MainWindow MainWindow { get; set; }
        public BinWriterTaskUserControl()
        {
            InitializeComponent();

            /*
            BinWriterTask[] tasks = new BinWriterTask[4];
            tasks[0] = new BinWriterTask
            {
                DisplayName = "One",
                Images = new string[] { "1.png" },
                MapRect = "1 2 3 4",
            };

            tasks[1] = new BinWriterTask
            {
                DisplayName = "Two",
                Images = new string[] { "2.png" },
                MapRect = "1 2 3 4",
            };

            tasks[2] = new BinWriterTask
            {
                DisplayName = "Three",
                Images = new string[] { "3.png" },
                MapRect = "1 2 3 4",
            };

            tasks[3] = new BinWriterTask
            {
                DisplayName = "Four",
                Images = new string[] { "4.png", "4a.png" },
                MapRect = "1 2 3 4",
            };


            this.BinWriterTaskList.BeginUpdate();
            foreach (var task in tasks)
            {

                ListViewItem lvi = new ListViewItem(new string[]
                {
                    task.DisplayName,
                    task.MapRect,
                    String.Join(", ", task.Images),
                });
                lvi.Tag = task;
                this.BinWriterTaskList.Items.Add(lvi);
            }
            this.AssignOrder();
            this.BinWriterTaskList.EndUpdate();
            */
        }

        #region ContextMenuStrip
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var box = new BinWriterTaskEditor();
            box.ImageListBox.Items.AddRange(this.MainWindow.ImagesUserControl.AvailableImages);
            var dr = box.ShowDialog();
            if (dr != DialogResult.OK) { return; }

            BinWriterTask task = new BinWriterTask();
            box.StoreConfig(task);
            ListViewItem lvi = this.CreateLvi(task);

            this.BinWriterTaskList.BeginUpdate();
            this.BinWriterTaskList.Items.Add(lvi);
            this.AssignOrder();
            this.BinWriterTaskList.EndUpdate();
        }

        private ListViewItem CreateLvi(BinWriterTask task)
        {
            ListViewItem lvi = new ListViewItem(new string[]
                {
                    task.DisplayName,
                    task.MapRect,
                    String.Join(", ", task.Images),
                });
            lvi.Tag = task;
            return lvi;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BinWriterTaskList.BeginUpdate();
            foreach (ListViewItem lvi in this.BinWriterTaskList.SelectedItems)
            {
                this.BinWriterTaskList.Items.Remove(lvi);
            }

            this.AssignOrder();
            this.BinWriterTaskList.EndUpdate();
        }
        
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in this.BinWriterTaskList.SelectedItems)
            {
                BinWriterTask task = (BinWriterTask)lvi.Tag;
                var box = new BinWriterTaskEditor(task, this.MainWindow.ImagesUserControl.AvailableImages);

                var dr = box.ShowDialog();
                if (dr != DialogResult.OK) { return; }
                box.StoreConfig(task);
                lvi.SubItems[0].Text = task.DisplayName;
                lvi.SubItems[1].Text = task.MapRect;
                lvi.SubItems[2].Text = String.Join(", ", task.Images);
            }
        }
        #endregion

        private void AssignOrder()
        {
            for (int i = 0; i < this.BinWriterTaskList.Items.Count; i++)
            {
                ((BinWriterTask)this.BinWriterTaskList.Items[i].Tag).Order = i;
            }
        }

        #region Drag & Drop
        private void BinWriterTaskList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ListViewItem lvi = (ListViewItem)e.Item;
            this.BinWriterTaskList.DoDragDrop("MoveItem", DragDropEffects.Move);
        }

        private void BinWriterTaskList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.AllowedEffect != DragDropEffects.Move) { return; }
            if (!e.Data.GetDataPresent(DataFormats.StringFormat)) { return; }
            string str = (string)e.Data.GetData(DataFormats.StringFormat);
            if (str != "MoveItem") { return; }
            e.Effect = DragDropEffects.Move;
        }

        private void BinWriterTaskList_DragDrop(object sender, DragEventArgs e)
        {
            if (e.AllowedEffect != DragDropEffects.Move) { return; }
            if (!e.Data.GetDataPresent(DataFormats.StringFormat)) { return; }
            string str = (string)e.Data.GetData(DataFormats.StringFormat);
            if (str != "MoveItem") { return; }
            e.Effect = DragDropEffects.Move;
                                  
            // Find LVI which is dragged to.
            Point relPos = this.BinWriterTaskList.PointToClient(new Point(e.X, e.Y));
            // Find the LVI we're dropped onto, and move to before it.
            ListViewItem dropAt = this.BinWriterTaskList.GetItemAt(relPos.X, relPos.Y);
            ListViewItem movedItem = this.BinWriterTaskList.SelectedItems[0];
            ListViewItem insertItem = (ListViewItem)movedItem.Clone();

            if (dropAt == null)
            {
                // Move to end of list.
                this.BinWriterTaskList.Items.Add(insertItem);
            }
            else
            {
                int dropIndex = dropAt.Index;
                if (dropIndex > movedItem.Index) { dropIndex++; }
                this.BinWriterTaskList.Items.Insert(dropIndex, insertItem);
            }

            this.BinWriterTaskList.Items.Remove(movedItem);

            this.AssignOrder();
        }
        #endregion


        internal void Save(CompileConfig config)
        {
            config.BinWriterTasks.Clear();
            foreach (ListViewItem lvi in this.BinWriterTaskList.Items)
            {
                config.BinWriterTasks.Add((BinWriterTask)lvi.Tag);
            }
        }

        internal void ApplyConfig(CompileConfig config)
        {
            this.BinWriterTaskList.BeginUpdate();
            this.BinWriterTaskList.Items.Clear();
            foreach (var task in config.BinWriterTasks.OrderBy(t => t.Order))
            {
                this.BinWriterTaskList.Items.Add(this.CreateLvi(task));
            }
            this.AssignOrder();
            this.BinWriterTaskList.EndUpdate();
        }

        internal void RenameImage(string oldName, string newName)
        {
            foreach (ListViewItem lvi in this.BinWriterTaskList.Items)
            {
                BinWriterTask task = (BinWriterTask)lvi.Tag;
                bool change = false;
                for (int i = 0; i < task.Images.Length; i++)
                {
                    if (task.Images[i] == oldName)
                    {
                        task.Images[i] = newName;
                        change = true;
                    }
                }
                if (change)
                {
                    lvi.SubItems[2].Text = String.Join(", ", task.Images);
                }
            }
        }
    }
}
