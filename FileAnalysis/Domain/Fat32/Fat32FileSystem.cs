using FileAnalysis.Infrastructure.FileSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalysis.Domain.Fat32
{
    internal class Fat32FileSystem
    {
        public IEnumerable<DirectoryEntry> ReadRootDirectory()
        {
            return new LinkedList<DirectoryEntry>();
        }

        Fat32FileSystem(string path)
        {
        }
    }
}
