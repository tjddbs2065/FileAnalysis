using FileAnalysis.Infrastructure.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalysis.Domain.Fat32
{
    internal class BootSectorParser
    {
        public static Fat32BootSector getFat32Context(IBlockDevice device, long startSector)
        {
            byte[] buffer = device.Read(startSector * 512, 90);

            string oemName = Encoding.ASCII.GetString(buffer, 0x3, 8).TrimEnd('\0', ' ');
            ushort bytesPerSector = BitConverter.ToUInt16(buffer, 0xB);
            byte sectorsPerCluster = buffer[0xD];
            ushort reservedSectorCount = BitConverter.ToUInt16(buffer, 0xE);
            byte numOfFATs = buffer[0x10];
            uint sectorsPerFAT = BitConverter.ToUInt32(buffer, 0x24);
            uint rootCluster = BitConverter.ToUInt32(buffer, 0x2C);
            ushort fsInfoSector = BitConverter.ToUInt16(buffer, 0x30);
            string fileSystemType = Encoding.ASCII.GetString(buffer, 0x52, 8).TrimEnd('\0', ' ');

            long partitionStartOffset = startSector * bytesPerSector;

            return new Fat32BootSector(
                partitionStartOffset,
                oemName,
                bytesPerSector, 
                sectorsPerCluster,
                reservedSectorCount, 
                numOfFATs, 
                sectorsPerFAT, 
                rootCluster, 
                fsInfoSector, 
                fileSystemType
            );
        }
    }
}
