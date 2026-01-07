using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalysis.Domain.Fat32
{
    internal class Fat32Context
    {
        private string oemName { get; }
        private long bytesPerSector {  get; }
        private long sectorsPerCluster { get; }
        private long reservedSectorCount { get; }
        private long numOfFat {  get; }
        private long sectorsPerFat { get; }
        private long rootCluster {  get; }
        private long fsInfoSector { get; }
        private string fsType { get; }

        public Fat32Context(string oemName, long bytesPerSector, long sectorsPerCluster, long reservedSectorCount, long numOfFat, long sectorsPerFat, long rootCluster, long fsInfoSector, string fsType)
        {
            this.oemName = oemName;
            this.bytesPerSector = bytesPerSector;
            this.sectorsPerCluster = sectorsPerCluster;
            this.reservedSectorCount = reservedSectorCount;
            this.numOfFat = numOfFat;
            this.sectorsPerFat = sectorsPerFat;
            this.rootCluster = rootCluster;
            this.fsInfoSector = fsInfoSector;
            this.fsType = fsType;
        }
    }
}
