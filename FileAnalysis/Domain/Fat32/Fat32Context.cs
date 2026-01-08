using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalysis.Domain.Fat32
{
    internal class Fat32Context
    {
        public long BytesPerCluster { get; }

        public long ReservedAreaOffset { get; }
        public long FatAreaOffset { get; }
        public long DataAreaOffset { get; }

        public uint RootDirectoryCluster { get; }

        public Fat32Context(long bytesPerCluster, long reservedAreaOffset, long fatAreaOffset, long dataAreaOffset, uint rootDirectoryCluster)
        {
            BytesPerCluster = bytesPerCluster;

            ReservedAreaOffset = reservedAreaOffset;
            FatAreaOffset = fatAreaOffset;
            DataAreaOffset = dataAreaOffset;

            RootDirectoryCluster = rootDirectoryCluster;
        }

        public override string ToString()
        {
            return BytesPerCluster + "\n" + ReservedAreaOffset + "\n" + FatAreaOffset + "\n" + DataAreaOffset + "\n" + RootDirectoryCluster;
        }
    }
}
