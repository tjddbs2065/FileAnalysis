using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalysis.Domain.Fat32
{
    internal class DirectoryEntry
    {
        public string fileName {  get; set; }
        public string path { get; set; }
    }
}
