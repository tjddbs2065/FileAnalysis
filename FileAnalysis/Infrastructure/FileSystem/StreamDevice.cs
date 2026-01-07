using FileAnalysis.Infrastructure.FileSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalysis.Domain
{
    internal class StreamDevice: IBlockDevice
    {
        private readonly Stream _stream;

        public StreamDevice(FileStream stream)
        {
            _stream = stream;
        }

        public byte[] Read(long offset, int size)
        {
            _stream.Seek(offset, SeekOrigin.Begin);
            var buffer = new byte[size];
            _stream.Read(buffer, 0, size);
            return buffer;
        }
    }
}
