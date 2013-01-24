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

using Demoder.Common.Serialization;
using Demoder.MapCompiler;
using Demoder.MapCompiler.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aomc.GUI
{
    public partial class MainWindow : Form
    {
        private FileInfo configFile { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            this.BinWriterTaskUserControl.MainWindow = this;
            this.MapUserControl.MainWindow = this;
            this.ImagesUserControl.ImageNameChange += ImagesUserControl_ImageNameChange;

        }

        void ImagesUserControl_ImageNameChange(string oldName, string newName)
        {
            this.BinWriterTaskUserControl.RenameImage(oldName, newName);
            this.MapUserControl.RenameImage(oldName, newName);
        }

        private void GenerateConfig(out CompileConfig config)
        {
            config = new CompileConfig();
            // Store information which resides in the main window
            config.BinFile = this.BinName.Text;
            config.MapDirectory = this.MapSubfolder.Text;
            config.OutputDirectory= this.OutputTextBox.Text;
            config.MapVersion = this.MapVersionTextBox.Text;
            config.Threads = (int)this.ThreadCount.Value;

            // Store usercontrol settings
            this.ImagesUserControl.Save(config);
            this.BinWriterTaskUserControl.Save(config);
            this.MapUserControl.Save(config);
        }

        private void ApplyConfig(CompileConfig config)
        {
            this.BinName.Text = config.BinFile;
            this.MapSubfolder.Text = config.MapDirectory;
            this.OutputTextBox.Text = config.OutputDirectory;
            this.MapVersionTextBox.Text = config.MapVersion;
            this.ThreadCount.Value = config.Threads;

            this.ImagesUserControl.ApplyConfig(config);
            this.BinWriterTaskUserControl.ApplyConfig(config);
            this.MapUserControl.ApplyConfig(config);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.configFile = null;
            this.ApplyConfig(new CompileConfig());
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.configFile == null)
            {
                this.saveAsToolStripMenuItem_Click(sender, e);
                return;
            }
            this.SaveConfig();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dr = this.SaveConfigDialog.ShowDialog();
            if (dr != DialogResult.OK) { return; }
            this.configFile = new FileInfo(this.SaveConfigDialog.FileName);
            this.SaveConfig();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dr = this.OpenConfigDialog.ShowDialog();
            if (dr != DialogResult.OK) { return; }
            this.configFile = new FileInfo(this.OpenConfigDialog.FileName);
            CompileConfig config = Xml.Deserialize<CompileConfig>(this.configFile, false);
            this.ApplyConfig(config);
        }

        

        private void SaveConfig()
        {
            CompileConfig config;
            this.GenerateConfig(out config);
            Xml.Serialize(this.configFile, config, false);
        }

        private void CompileButton_Click(object sender, EventArgs e)
        {
            this.CompileButton.Enabled = false;
            CompileConfig config;
            this.GenerateConfig(out config);
            this.CompileWorker.RunWorkerAsync(config);
        }

        private void CompileWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CompileConfig config = (CompileConfig)e.Argument;
            var compiler = new Compiler(config);
            Stopwatch sw = Stopwatch.StartNew();
            compiler.Compile();
            sw.Stop();
            e.Result = sw.Elapsed;
        }

        private void CompileWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TimeSpan ts = (TimeSpan)e.Result;
            MessageBox.Show("Compile done. Took " + ts.TotalSeconds.ToString() + " seconds.");
            this.CompileButton.Enabled = true;
        }
    }
}
