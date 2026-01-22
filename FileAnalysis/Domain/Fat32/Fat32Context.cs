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

            RootDirectoryCluster = rootDirectoryCluster; // 인덱스 번호가 2부터 시작(0, 1은 예약 번호)
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("BytesPerCluster: " + BytesPerCluster.ToString() + "\n");
            sb.Append("ReservedAreaOffset: " + ReservedAreaOffset.ToString() + "\n");
            sb.Append("FatAreaOffset: " + FatAreaOffset.ToString() + "\n");
            sb.Append("DataAreaOffset: " + DataAreaOffset.ToString() + "\n");
            sb.Append("RootDirectoryCluster: " + RootDirectoryCluster.ToString() + "\n");
            return sb.ToString();
        }
    }
}
