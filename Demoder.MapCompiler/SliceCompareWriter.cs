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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demoder.MapCompiler
{
    public class SliceCompareWriter : IDisposable
    {
        private WorkTaskInfo[] WorkTaskInfo { get; set; }
        private FileStream BinFile { get; set; }
        private int NumSlices { get; set; }

        public SliceCompareWriter(FileStream binFile, WorkTaskInfo[] workTaskInfo)
        {
            this.BinFile = binFile;
            this.WorkTaskInfo = workTaskInfo;

            this.NumSlices=-1;
            for (int i = 0; i < workTaskInfo.Length; i++)
            {
                if (this.NumSlices == -1)
                {
                    this.NumSlices = workTaskInfo[i].Slices.Length;
                }
                else if (this.NumSlices != workTaskInfo[i].Slices.Length)
                {
                    throw new InvalidDataException();
                }
            }
        }

        public IEnumerable<Tuple<string,int[]>> Write()
        {
            int lastSliceNum = 0;
            for (int sliceNum = 0; sliceNum < this.NumSlices; sliceNum++)
            {
                for (int layerNum = 0; layerNum < this.WorkTaskInfo.Length; layerNum++)
                {
                    this.WriteSlice(layerNum, sliceNum);
                }
                lastSliceNum = sliceNum;
            }

            var retVal = from wt in this.WorkTaskInfo
                         let name = wt.Name
                         let pos = wt.FilePos
                         select Tuple.Create(name, pos);

            return retVal;
        }

        private void WriteSlice(int layerNum, int sliceNum)
        {
            MemoryStream slice = this.WorkTaskInfo[layerNum].Slices[sliceNum];
            MD5Checksum sliceHash = MD5Checksum.Generate(slice);
            var currentLayer = this.WorkTaskInfo[layerNum];
            // Check if we can reuse other layers position.
            for (int i=0; i<this.WorkTaskInfo.Length; i++)
            {
                if (i == layerNum)
                {
                    // Skip if it's current layer.
                    continue;
                }
                var otherLayer = this.WorkTaskInfo[i];
                if (otherLayer.SlicePosition == -1)
                {
                    // If this layer have no written slices yet, skip it
                    continue;
                }
                if (otherLayer.SlicePosition <= currentLayer.SlicePosition)
                {
                    // If layers last position is identical, or less, than my last: Skip.
                    // The Anarchy Online planet map viewer does not handle 'backtracking' the stream position too well.
                    continue;
                }
                if (otherLayer.SliceHash != sliceHash)
                {
                    // Not identical, skip.
                    continue;
                }

                // Found acceptable, pre-existing slice.
                // Use this and return.
                currentLayer.FilePos[sliceNum] = otherLayer.SlicePosition;
                return;
            }

            // We have to write new slice to binfile.
            int position = (int)this.BinFile.Position;
            currentLayer.FilePos[sliceNum] = position;
            currentLayer.SlicePosition = position;
            currentLayer.SliceHash = sliceHash;

            slice.WriteTo(this.BinFile);
        }

        public void Dispose()
        {
            this.BinFile = null;
            this.NumSlices = 0;
            this.WorkTaskInfo = null;
        }
    }
}
