using FileAnalysis.Domain.Fat32;
using FileAnalysis.Infrastructure.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalysis.Domain.FileSystem
{
    internal class Fat32Node: IFileNode
    {
        public Fat32Node parent;
        public Dictionary<string, Fat32Node> children;

        public string Name { get; }
        public uint StartCluster { get; }
        //public bool IsDirectory { get; }

        public Fat32Node(string name, uint startCluster, Fat32Node parentNode)
        {
            Name = name;
            StartCluster = startCluster;
            //IsDirectory = isDirectory;

            parent = parentNode;
            children = new Dictionary<string, Fat32Node>();
        }

        public static Fat32Node getRoot()
        {
            return new Fat32Node("/", 2, null);
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (children.Count > 0)
            {
                sb.AppendLine(Name+" [");
                foreach (var item in children)
                {
                    sb.AppendLine("-" + item.Value);
                }
                sb.Append("]");
            }
            else
            {
                sb.Append(Name);
            }

            return sb.ToString();
        }
    }
}
