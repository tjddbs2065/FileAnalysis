using FileAnalysis.Domain;
using FileAnalysis.Domain.Fat32;
using FileAnalysis.Domain.FileSystem;
using FileAnalysis.Domain.MBR;
using FileAnalysis.Infrastructure.FileSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Study Projects\fat32.vhd";

            FileStream fs = File.OpenRead(path);

            IBlockDevice blockDevice = new StreamDevice(fs);

            PartitionInfo partitionZero = MbrParser.GetPartition(blockDevice, 0);

            Fat32BootSector bootSector = BootSectorParser.getFat32Context(blockDevice, partitionZero.startSector);

            Fat32Context fat32Context = Fat32Parser.getFat32Context(bootSector);

            //DirectoryEntryParser.getDirectoryEntryList(blockDevice, fat32Context, fat32Context.RootDirectoryCluster);

            Fat32Node rootNode = Fat32Node.getRoot();

            List<DirectoryEntry> entries =  DirectoryEntryParser.getDirectoryEntryList(blockDevice, fat32Context, rootNode.StartCluster);
            foreach (var item in entries)
            {
                rootNode.children.Add(item.Name, new Fat32Node(item.Name, item.FileClusterNumber, rootNode));
            }
            Fat32Node childNode = rootNode.children["FOLDER"];
            entries = DirectoryEntryParser.getDirectoryEntryList(blockDevice, fat32Context, childNode.StartCluster);
            foreach (var item in entries)
            {
                childNode.children.Add(item.Name, new Fat32Node(item.Name, item.FileClusterNumber, childNode));
            }
            Console.WriteLine(rootNode.ToString());
            //Fat32Node currentNode = rootNode;
            //while (true)
            //{
            //    //Console.Clear();
            //    Console.WriteLine(currentNode);
            //    string fileName = Console.ReadLine();
            //    if (fileName.Equals("exit")) break;
            //}
        }
    }
}
