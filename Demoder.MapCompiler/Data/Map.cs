using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demoder.MapCompiler.Data
{
    public class Map
    {
        public Map()
        {
            this.Layers = new List<MapLayer>();
        }
        public string Name { get; set; }
        public MapType Type { get; set; }
        public string CoordsFile { get; set; }

        public List<MapLayer> Layers { get; set; }

        public void WriteTextFile(FileInfo file)
        {
            using (var textWriter = file.CreateText())
            {
                this.WriteTextFile(textWriter);
            }
        }

        public void WriteTextFile(TextWriter file)
        {
            file.WriteLine("Name \"{0}\"", this.Name);
            file.WriteLine("Type {0}", this.Type);
            file.WriteLine("CoordsFile {0}", this.CoordsFile);
            
            foreach (var layer in this.Layers)
            {
                file.WriteLine();
                layer.WriteTextFile(file);
            }
        }
    }

    public enum MapType
    {
        Shadowlands,
        Rubika,
    }
}
