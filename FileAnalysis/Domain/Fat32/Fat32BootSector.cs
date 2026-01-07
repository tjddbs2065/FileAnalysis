using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalysis.Domain.Fat32
{
    internal class Fat32BootSector
    {
        private string OemName { get; }
        private ushort BytesPerSector { get; }
        private byte SectorsPerCluster { get; }
        private ushort ReservedSectorCount { get; }
        private byte NumOfFATs { get; }
        private uint SectorsPerFAT { get; }
        private uint RootCluster { get; }
        private ushort FsInfoSector { get; }
        private string FileSystemType { get; }


        public Fat32BootSector(string oemName, ushort bytesPerSector, byte sectorsPerCluster, ushort reservedSectorCount, byte numOfFATs, uint sectorsPerFAT, uint rootCluster, ushort fsInfoSector, string fileSystemType)
        {
            OemName = oemName;
            BytesPerSector = bytesPerSector;
            SectorsPerCluster = sectorsPerCluster;
            ReservedSectorCount = reservedSectorCount;
            NumOfFATs = numOfFATs;
            SectorsPerFAT = sectorsPerFAT;
            RootCluster = rootCluster;
            FsInfoSector = fsInfoSector;
            FileSystemType = fileSystemType;
        }

        public override string ToString()
        {
            return OemName + "\n" + BytesPerSector + "\n" + SectorsPerCluster + "\n" + ReservedSectorCount + "\n" + NumOfFATs + "\n" + SectorsPerFAT + "\n" + RootCluster + "\n" + FsInfoSector + "\n" + FileSystemType;
        }
    }
}
