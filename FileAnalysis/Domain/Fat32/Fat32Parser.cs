using FileAnalysis.Infrastructure.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalysis.Domain.Fat32
{
    internal class Fat32Parser
    {
        public static Fat32Context getFat32Context(Fat32BootSector fat32BootSector)
        {
            long bytesPerCluster = fat32BootSector.SectorsPerCluster * fat32BootSector.BytesPerSector;
            
            long reservedAreaOffset = fat32BootSector.PartitionStartOffset; // 파티션 시작 offset
            long fatAreaOffset = reservedAreaOffset + (fat32BootSector.ReservedSectorCount * fat32BootSector.BytesPerSector); // 예약영역 offset에서 예약영역 크기만큼 더한 offset = fat 영역 offset
            long dataAreaOffset = fatAreaOffset + (fat32BootSector.NumOfFATs * fat32BootSector.SectorsPerFAT * fat32BootSector.BytesPerSector); // fat 영역 offset에서 fat영역 크기만큼 더한 offset = data 영역 offset

            uint rootDirectoryCluster = fat32BootSector.RootCluster;

            return new Fat32Context(bytesPerCluster, reservedAreaOffset, fatAreaOffset, dataAreaOffset, rootDirectoryCluster);
        }
    }
}
