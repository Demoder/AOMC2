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
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demoder.MapCompiler
{
    public class ImageSlicer : IDisposable
    {
        public bool Finished { get; private set; }
        public MemoryStream[] Slices { get; private set; }
        private Image Image { get; set; }

        public ImageSlicer(FileInfo image)
        {
            this.Image = Bitmap.FromFile(image.FullName); 
        }

        public ImageSlicer(Image image)
        {
            this.Image = image;
        }

        public void Slice()
        {
            int srcX = this.Image.Width;
            int srcY = this.Image.Height;
            int textureSize = Settings.TextureSize;

            int posX = 0;
            int posY = 0;

            List<MemoryStream> slices = new List<MemoryStream>();

            do
            {
                // Draw slice to the temporary image.
                using (Bitmap slice = new Bitmap(textureSize, textureSize, PixelFormat.Format24bppRgb))
                {
                    slice.SetResolution(this.Image.HorizontalResolution, this.Image.VerticalResolution);
                    using (Graphics g = Graphics.FromImage(slice))
                    {
                        Rectangle sliceRectangle = new Rectangle(posX, posY, textureSize, textureSize);
                        g.DrawImage(this.Image, 0, 0, sliceRectangle, GraphicsUnit.Pixel);
                    }

                    MemoryStream sliceStream = new MemoryStream();
                    slice.Save(sliceStream, ImageFormat.Png);
                    slices.Add(sliceStream);
                }

                posY += textureSize;

                if (posY >= srcY)
                {
                    posY = 0;
                    posX += textureSize;
                }
            }
            while (posX < srcX);

            this.Slices = slices.ToArray();
            slices.Clear();
            this.Finished = true;
        }

        public void Dispose()
        {
            this.Slices = null;
            this.Image = null;
        }
    }
}
