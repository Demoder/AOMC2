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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using Demoder.MapCompiler;
using System.IO;
using System.Diagnostics;
using Demoder.MapCompiler.Data;

namespace AomcConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            CompileConfig config = new CompileConfig
            {
                OutputDirectory = @"d:\tmp\mapout",
                BinFile = "AoRK.bin",
                MapDirectory = "AoRK"
            };

            config.Images.Add(new ImageDefinition { Name = "Layer1", Path = @"D:\Anarchy Online\Maps\AoRK\output\AoRK_map1.png" });
            config.Images.Add(new ImageDefinition { Name = "Layer2", Path = @"D:\Anarchy Online\Maps\AoRK\output\AoRK_map2.png" });
            config.Images.Add(new ImageDefinition { Name = "Layer3", Path = @"D:\Anarchy Online\Maps\AoRK\output\AoRK_map3.png" });
            config.Images.Add(new ImageDefinition { Name = "Layer3_atlantean", Path = @"D:\Anarchy Online\Maps\AoRK\output\AoRK_map3_rimor.png" });
            config.Images.Add(new ImageDefinition { Name = "Layer3_rimor", Path = @"D:\Anarchy Online\Maps\AoRK\output\AoRK_map3_atlantean.png" });

            config.BinWriterTasks.Add(new BinWriterTask
            {
                MapRect = "7 0 360 457",
                Order = 0,
                Images = new string[] { "Layer1" }
            });


            config.BinWriterTasks.Add(new BinWriterTask
            {
                MapRect = "55 0 944 1144",
                Order = 1,
                Images = new string[] { "Layer2" }
            });


            config.BinWriterTasks.Add(new BinWriterTask
             {
                 MapRect = "5 -7 3573 4583",
                 Order = 2,
                 Images = new string[] { "Layer3", "Layer3_atlantean", "Layer3_rimor" },
             });
            

            config.Maps.Add(new MapVersion
            {
                File = "AoRK.txt",
                CoordsFile = "AoRK/AoRK.xml",
                Name = "Atlas of Rubi-Ka",
                Type = MapType.Rubika,
                Images = new string[] { "Layer1", "Layer2", "Layer3" }
            });

            config.Maps.Add(new MapVersion
            {
                File = "AoRK-Atlantean.txt",
                CoordsFile = "AoRK/AoRK.xml",
                Name = "Atlas of Rubi-Ka (Atlantean)",
                Type = MapType.Rubika,
                Images = new string[] { "Layer1", "Layer2", "Layer3_atlantean" }
            });

            config.Maps.Add(new MapVersion
            {
                File = "AoRK-Rimor.txt",
                CoordsFile = "AoRK/AoRK.xml",
                Name = "Atlas of Rubi-Ka (Rimor)",
                Type = MapType.Rubika,
                Images = new string[] { "Layer1", "Layer2", "Layer3_rimor" }
            });


            Compiler compiler = new Compiler(config);
            Console.WriteLine("Compiler set up. Starting slicing...");
            Stopwatch sw = Stopwatch.StartNew();
            compiler.Compile();
            Console.WriteLine("Compiler done. Took {0} seconds.", sw.Elapsed.TotalSeconds);
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
