using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalysis.Domain.MBR
{
    internal class PartitionInfo
    {
        // 파티션이 시작되는 섹터 주소
        public long startSector { get; }

        // 파티션의 크기(섹터로)
        public long totalSectors { get; }

        // 파티션 타입
        public byte partitionType { get; }

        public PartitionInfo(long startSector, long totalSectors, byte partitionType)
        {
            this.startSector = startSector;
            this.totalSectors = totalSectors;
            this.partitionType = partitionType;
        }

        public override string ToString()
        {
            return startSector + ":" + totalSectors + ":" + partitionType;
        }
    }
}
