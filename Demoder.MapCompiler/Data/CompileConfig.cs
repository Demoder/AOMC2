using Demoder.Common.Hash;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Demoder.MapCompiler.Data
{
    [Serializable]
    [XmlRoot("AomcCompileConfig")]
    public class CompileConfig
    {
        [XmlAttribute("outputDirectory")]
        public string OutputDirectory { get; set; }

        /// <summary>
        /// Directory which the files will reside in when installed to Anarchy Online
        /// </summary>
        [XmlAttribute("mapDir")]
        public string MapDirectory { get; set; }
        [XmlAttribute("binFile")]
        public string BinFile { get; set; }

        [XmlAttribute("mapVersion")]
        public string MapVersion { get; set; }

        [XmlAttribute("threads")]
        public int Threads { get; set; }

        [XmlArray("Images")]
        [XmlArrayItem("Image")]
        public List<ImageDefinition> Images { get; set; }
        [XmlArray("BinWriterTasks")]
        [XmlArrayItem("BinWriterTask")]
        public List<BinWriterTask> BinWriterTasks { get; set; }
        [XmlArray("Maps")]
        [XmlArrayItem("Map")]
        public List<MapVersion> Maps { get; set; }

        public CompileConfig()
        {
            this.Images = new List<ImageDefinition>();
            this.BinWriterTasks = new List<BinWriterTask>();
            this.Maps = new List<MapVersion>();
        }
    }

    [Serializable]
    public class BinWriterTask
    {
        public BinWriterTask()
        {
            this.Images = new string[0];
        }

        [XmlAttribute("name")]
        public string DisplayName { get; set; }

        [XmlArray("Images")]
        [XmlArrayItem("Image")]
        public string[] Images { get; set; }
        
        /// <summary>
        /// In which order shall the task be completed?
        /// </summary>
        [XmlAttribute("order")]
        public int Order { get; set; }

        [XmlAttribute("mapRect")]
        public string MapRect { get; set; }

        public override string ToString()
        {
            return this.DisplayName;
        }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(obj, null)) { return false; }
            BinWriterTask other = (BinWriterTask)obj;
            if (other.DisplayName != this.DisplayName) { return false; }
            if (other.Order != this.Order) { return false; }
            if (other.MapRect != this.MapRect) { return false; }
            if (!other.Images.SequenceEqual(this.Images)) { return false; }
            return true;
        }
    }

    public class ImageDefinition
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("path")]
        public string Path { get; set; }

        public override string ToString()
        {
            return this.Name + ": " + this.Path;
        }
    }

    public class MapVersion
    {
        public MapVersion()
        {
            this.Images = new string[0];
        }
        /// <summary>
        /// Name of map version
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }
        /// <summary>
        /// Map version file name (without path)
        /// </summary>
        [XmlAttribute("file")]
        public string File { get; set; }
        /// <summary>
        /// Coordinates file
        /// </summary>
        [XmlAttribute("coordsFile")]
        public string CoordsFile { get; set; }
        /// <summary>
        /// Map type (Rubika or Shadowlands)
        /// </summary>
        [XmlAttribute("type")]
        public MapType Type { get; set; }
        /// <summary>
        /// Which images are referenced by this map version.
        /// </summary>
        [XmlArray("Images")]
        [XmlArrayItem("Image")]
        public string[] Images { get; set; }

        public override string ToString()
        {
            return String.Format("{0} (F: {1} T:{2} L:{3})",
                this.Name,
                this.File,
                this.Type,
                this.Images.Length);
        }
    }

















    public class ImageInfo
    {
        public string Name { get; set; }
        public Size Size { get; set; }
        public Size Tiles { get; set; }
    }

    public class WorkTaskInfo
    {
        public int SlicePosition = -1;
        public MD5Checksum SliceHash { get; set; }
        public MemoryStream[] Slices { get; set; }
        public int[] FilePos { get; set; }
        public string Name { get; set; }
    }

    public class SlicerWorkInfo : IDisposable
    {
        public string Name { get; set; }
        public Image Image { get; set; }

        public void Dispose()
        {
            this.Image.Dispose();
            this.Image = null;
        }
    }

    public class SlicedImage : IDisposable
    {
        public string Name { get; set; }
        public MemoryStream[] Slices { get; set; }

        public void Dispose()
        {
            this.Slices = null;
        }
    }
}
