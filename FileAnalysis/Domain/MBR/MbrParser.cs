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


            // 엔트리 읽기
            byte[] entry = device.Read(entryOffset, MbrConstants.PartitionTableSize);

            Console.WriteLine(entry[0]);

            byte partitionType = entry[4];
            uint startLba = BitConverter.ToUInt32(entry, 8);
            uint sectorCount = BitConverter.ToUInt32(entry, 12);

            return new PartitionInfo(startLba, sectorCount, partitionType);
        }
    }
}
