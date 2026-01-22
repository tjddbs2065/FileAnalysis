using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalysis.Domain.Fat32
{
    internal class DirectoryEntry
    {
        public string Name { get; }
        public string FullName { get; }
        public string Extension { get; }
        public string Attribute { get; }
        public string CreateDate { get; }
        public string CreateTime { get; }
        public string LastAccessedDate { get; }
        public string LastModifiedDate { get; }
        public string LastModifiedTime { get; }
        public uint FileSize { get; }

        public uint FileClusterNumber { get; }

        public DirectoryEntry(string Name, uint FileSize, uint FileClusterNumber)
        {
            this.Name = Name;
            this.FileSize = FileSize;
            this.FileClusterNumber = FileClusterNumber;
        }
        public DirectoryEntry(string Name, string FullName, string Extension, string Attribute, string CreateDate, string CreateTime, string LastAccessedDate, string LastModifiedDate, string LastModifiedTime, uint FileSize, uint FileClusterNumber)
        {
            this.Name = Name;
            this.FullName = FullName;
            this.Extension = Extension;
            this.Attribute = Attribute;
            this.CreateDate = CreateDate;
            this.CreateTime = CreateTime;
            this.LastAccessedDate = LastAccessedDate;
            this.LastModifiedDate = LastModifiedDate;
            this.LastModifiedTime = LastModifiedTime;
            this.FileSize = FileSize;

            this.FileClusterNumber = FileClusterNumber;
        }
        public override string ToString()
        {
            return this.Name + " : " + FileSize + " : " + FileClusterNumber;
        }
    }
}
