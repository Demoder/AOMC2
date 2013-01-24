using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demoder.MapCompiler.Data
{
    public class MapLayer
    {
        public string File { get; set; }
        public int TextureSize { get; set; }
        public Size Size { get; set; }
        public Size Tiles { get; set; }
        public string MapRect { get; set; }

        public int[] FilePos { get; set; }

        public void WriteTextFile(TextWriter file)
        {
            file.WriteLine("File {0}", this.File);
            file.WriteLine("TextureSize {0}", this.TextureSize);
            
            file.WriteLine();
            
            file.WriteLine("Size {0} {1}", this.Size.Width, this.Size.Height);
            file.WriteLine("Tiles {0} {1}", this.Tiles.Width, this.Tiles.Height);
            file.WriteLine("MapRect {0}", this.MapRect);
            
            foreach (var pos in this.FilePos)
            {
                file.WriteLine("FilePos {0}", pos);
            }
        }
    }
}
