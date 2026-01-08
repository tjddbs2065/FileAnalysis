using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalysis.Domain.Fat32
{
    internal class Fat32BootSector
    {
        public long PartitionStartOffset { get; }

        public string OemName { get; }
        public ushort BytesPerSector { get; } // 한 섹터 당 바이트
        public byte SectorsPerCluster { get; } // 한 클러스터 당 섹터
        public ushort ReservedSectorCount { get; } // Reserved Area의 섹터 수
        public byte NumOfFATs { get; } // FAT의 개수
        public uint SectorsPerFAT { get; } // 한 FAT 영역 당 섹터
        public uint RootCluster { get; } // 
        public ushort FsInfoSector { get; }
        public string FileSystemType { get; }


        public Fat32BootSector(long partitionStartOffset, string oemName, ushort bytesPerSector, byte sectorsPerCluster, ushort reservedSectorCount, byte numOfFATs, uint sectorsPerFAT, uint rootCluster, ushort fsInfoSector, string fileSystemType)
        {
            PartitionStartOffset = partitionStartOffset;
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
