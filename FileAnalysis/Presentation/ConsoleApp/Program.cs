using FileAnalysis.Domain;
using FileAnalysis.Domain.Fat32;
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

            Console.WriteLine(bootSector.ToString());

        }
    }
}
