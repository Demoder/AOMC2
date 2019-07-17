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

using Demoder.Common.Hash;
using Demoder.MapCompiler.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demoder.MapCompiler
{
    public class Compiler
    {
        private CompileConfig Config { get; set; }
        private BlockingCollection<SlicerWorkInfo> SliceQueue = new BlockingCollection<SlicerWorkInfo>();
        private ConcurrentDictionary<string, SlicedImage> SlicedImages = new ConcurrentDictionary<string, SlicedImage>();

        private Dictionary<string, int[]> WrittenLayers = new Dictionary<string, int[]>();
        private Dictionary<string, ImageInfo> ImageInfo = new Dictionary<string, ImageInfo>();

        public Compiler(CompileConfig config)
        {
            this.Config = config;
        }

        public void Compile()
        {
            List<Task> tasks = new List<Task>();

            // Spawn image loader
            tasks.Add(Task.Factory.StartNew(this.ImageLoader));

            int threads = this.Config.Threads;
            if (threads == 0)
            {
                threads = Settings.DefaultThreadCount;
            }
            
            // Spawn image slicers.
            for (int i = 0; i < threads; i++)
            {
                tasks.Add(Task.Factory.StartNew(this.SliceImages));
            }

            Task.WaitAll(tasks.ToArray());
            tasks.Clear();

            this.WriteBinFile();

            this.WriteMapVersions();
        }

        private void ImageLoader()
        {
            foreach (var image in this.Config.Images)
            {
                Image img = Image.FromFile(image.Path);
                SlicerWorkInfo workInfo = new SlicerWorkInfo
                {
                    Image = img,
                    Name = image.Name
                };

                // Round up the number of tiles in case the image doesn't include a whole number of tiles.
                // The Anarchy Online client works either way, but Demoder's Planet Map Viewer relies on this value being correct.
                var tilesWidth = (int)Math.Ceiling(img.Width / (double)Settings.TextureSize);
                var tilesHeight = (int)Math.Ceiling(img.Height/ (double)Settings.TextureSize);

                this.ImageInfo.Add(image.Name, new ImageInfo
                {
                    Name = image.Name,
                    Size = img.Size,
                    Tiles = new Size(tilesWidth, tilesHeight)
                });
                this.SliceQueue.Add(workInfo);
            }
            this.SliceQueue.CompleteAdding();
        }

        private void SliceImages()
        {
            foreach (var task in this.SliceQueue.GetConsumingEnumerable())
            {
                using (task)
                {
                    using (ImageSlicer slicer = new ImageSlicer(task.Image))
                    {
                        slicer.Slice();
                        SlicedImage slicedImage = new SlicedImage
                        {
                            Name = task.Name,
                            Slices = slicer.Slices
                        };
                        this.SlicedImages.TryAdd(slicedImage.Name, slicedImage);
                    }
                }    
            }
        }

        private void WriteBinFile()
        {
            var dir = new DirectoryInfo(this.Config.OutputDirectory);
            if (!dir.Exists) { dir.Create(); }
            using (FileStream binFile = new FileStream(Path.Combine(dir.FullName, this.Config.BinFile), FileMode.Create))
            {
                foreach (var wt in this.Config.BinWriterTasks.OrderBy(wt => wt.Order))
                {
                    if (wt.Images.Length == 0)
                    {
                        continue;
                    }
                    else if (wt.Images.Length == 1)
                    {
                        // Single image; Therefore, we can do the whole operation in one go.
                        SlicedImage slicedImage = this.SlicedImages[wt.Images[0]];
                        int[] positions = new int[slicedImage.Slices.Length];

                        for (int i = 0; i < slicedImage.Slices.Length; i++)
                        {
                            MemoryStream slice = slicedImage.Slices[i];
                            positions[i] = (int)binFile.Position;
                            slice.WriteTo(binFile);
                        }
                        this.WrittenLayers[slicedImage.Name] = positions;
                    }
                    else
                    {
                        // Multiple images, which means we need to compare.
                        WorkTaskInfo[] info = new WorkTaskInfo[wt.Images.Length];

                        // Setup work info
                        for (int i = 0; i < wt.Images.Length; i++)
                        {
                            var task = new WorkTaskInfo();
                            task.Slices = this.SlicedImages[wt.Images[i]].Slices;
                            task.FilePos = new int[task.Slices.Length];
                            task.Name = wt.Images[i];
                            info[i] = task;
                        }

                        // Run the CompareWriter.
                        using (SliceCompareWriter sliceComparer = new SliceCompareWriter(binFile, info))
                        {
                            IEnumerable<Tuple<string, int[]>> tuples = sliceComparer.Write();
                            foreach (Tuple<string, int[]> tuple in tuples)
                            {
                                this.WrittenLayers[tuple.Item1] = tuple.Item2;
                            }
                        }
                    }
                }
            }
        }        

        private void WriteMapVersions()
        {
            var dir = new DirectoryInfo(this.Config.OutputDirectory);
            if (!dir.Exists) { dir.Create(); }
            foreach (var mapVersion in this.Config.Maps)
            {
                Map map = new Map
                {
                    CoordsFile = mapVersion.CoordsFile,
                    Name = String.Format(mapVersion.Name, this.Config.MapVersion),
                    Type = mapVersion.Type
                };

                foreach (var image in mapVersion.Images)
                {
                    var imgInfo = this.ImageInfo[image];
                    BinWriterTask workTask = this.Config.BinWriterTasks.FirstOrDefault(wt=>wt.Images.Contains(image));
                    if (workTask == null)
                    {
                        throw new InvalidDataException();
                    }

                    MapLayer mapLayer = new MapLayer
                    {
                        File = this.Config.MapDirectory + "/" + this.Config.BinFile,
                        FilePos = this.WrittenLayers[image],
                        Size = imgInfo.Size,
                        Tiles = imgInfo.Tiles,
                        MapRect = workTask.MapRect,
                        TextureSize = Settings.TextureSize,
                    };
                    map.Layers.Add(mapLayer);
                }

                map.WriteTextFile(new FileInfo(Path.Combine(dir.FullName, mapVersion.File)));
            }
        }
    }
}
