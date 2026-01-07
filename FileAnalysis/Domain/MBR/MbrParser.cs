using FileAnalysis.Infrastructure.FileSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalysis.Domain.MBR
{
    internal class MbrParser
    {
        public static PartitionInfo GetPartition(IBlockDevice device, int index)
        {
            // 파티션 엔트리 offset 계산
            long entryOffset = MbrConstants.PartitionTableOffset + index * MbrConstants.PartitionEntrySize;

            // partitionTable 읽기
            byte[] entry = device.Read(entryOffset, MbrConstants.PartitionTableSize);

            byte partitionType = entry[4];
            uint startLba = BitConverter.ToUInt32(entry, 8);
            uint totalSector = BitConverter.ToUInt32(entry, 12);

            return new PartitionInfo(startLba, totalSector, partitionType);
        }
    }
}
