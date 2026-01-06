using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalysis.Domain.MBR
{
    internal class PartitionInfo
    {
        public long startOffset { get; }
        public long sectorCount { get; }
        public byte partitionType { get; }

        public PartitionInfo(long startOffset, long sectorCount, byte partitionType)
        {
            this.startOffset = startOffset;
            this.sectorCount = sectorCount;
            this.partitionType = partitionType;
        }

        public override string ToString()
        {
            return startOffset + ":" + sectorCount + ":" + partitionType;
        }
    }
}
