using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalysis.Infrastructure.FileSystem
{
    internal interface IBlockDevice
    {
        byte[] Read(long offset, int size);
    }
}
