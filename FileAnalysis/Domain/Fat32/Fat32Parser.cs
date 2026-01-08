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
        public static Fat32Context getFat32Context(IBlockDevice device, Fat32BootSector fat32BootSector)
        {
            long bytesPerCluster = fat32BootSector.SectorsPerCluster * fat32BootSector.BytesPerSector;
            
            long reservedAreaOffset = fat32BootSector.PartitionStartOffset;
            long fatAreaOffset = reservedAreaOffset + (fat32BootSector.ReservedSectorCount * fat32BootSector.BytesPerSector);
            long dataAreaOffset = fatAreaOffset + (fat32BootSector.NumOfFATs * fat32BootSector.SectorsPerFAT * fat32BootSector.BytesPerSector);

            uint rootDirectoryCluster = fat32BootSector.RootCluster;

            return new Fat32Context(bytesPerCluster, reservedAreaOffset, fatAreaOffset, dataAreaOffset, rootDirectoryCluster);
        }
    }
}
