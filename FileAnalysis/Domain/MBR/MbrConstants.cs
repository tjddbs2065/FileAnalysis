using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalysis.Domain.MBR
{
    internal static class MbrConstants
    {
        public const int BootCodeSize = 446;

        public const int PartitionTableOffset = 446;
        public const int PartitionTableSize = 64;
        public const int PartitionEntrySize = 16;
        public const int Signature = 2;
    }
}
