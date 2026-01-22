using FileAnalysis.Domain.FileSystem;
using FileAnalysis.Infrastructure.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalysis.Domain.Fat32
{
    internal class DirectoryEntryParser
    {
        private static string getAttributeString(byte attribute)
        {
            StringBuilder sb = new StringBuilder();

            if ((attribute & 0x01) != 0) sb.Append("읽기전용 ");
            if ((attribute & 0x02) != 0) sb.Append("숨김파일 ");
            if ((attribute & 0x04) != 0) sb.Append("시스템파일 ");
            if ((attribute & 0x08) != 0) sb.Append("볼륨이름 ");
            if ((attribute & 0x0F) != 0) sb.Append("LFN ");
            if ((attribute & 0x10) != 0) sb.Append("디렉터리 ");
            if ((attribute & 0x20) != 0) sb.Append("일반파일 ");

            return sb.ToString();
        }

        private static string parseLFN(byte[] buffer)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Encoding.Unicode.GetString(buffer, 0x01, 10).TrimEnd('\0', '\uFFFF'));
            sb.Append(Encoding.Unicode.GetString(buffer, 0x0E, 12).TrimEnd('\0', '\uFFFF'));
            sb.Append(Encoding.Unicode.GetString(buffer, 0x1C, 4).TrimEnd('\0', '\uFFFF'));

            return sb.ToString();
        }

        public static List<DirectoryEntry> getDirectoryEntryList(IBlockDevice device, Fat32Context context, uint clusterNumber)
        {
            List<DirectoryEntry> list = new List<DirectoryEntry>();

            StringBuilder lfnBuffer = new StringBuilder();

            if (clusterNumber < 2) clusterNumber = 2;

            long offset = context.DataAreaOffset + ((clusterNumber-2)*context.BytesPerCluster);

            while (true)
            {
                byte[] buffer = device.Read(offset, 32);

                if (buffer[0] == 0x00) break; // 파일 목록 마지막


                if ((buffer[0x0B] & 0x0F) == 0x0F) // LNF
                {
                    lfnBuffer.Insert(0, parseLFN(buffer));
                }
                else // SNF
                {
                    string name;
                    if (lfnBuffer.Length > 0)
                    {
                        name = lfnBuffer.ToString();
                        lfnBuffer.Clear();
                    }
                    else
                    {
                        string baseName = Encoding.ASCII.GetString(buffer, 0, 8).TrimEnd('\0', ' ');
                        string extension = Encoding.ASCII.GetString(buffer, 8, 3).TrimEnd('\0', ' ');

                        name = extension.Length > 0 ? $"{baseName}.{extension}" : baseName;
                    }

                    uint fileSize = BitConverter.ToUInt32(buffer, 0x1C);
                    uint fileClusterNumber = ((uint)(BitConverter.ToUInt16(buffer, 0x14)) << 16) | BitConverter.ToUInt16(buffer, 0x1A);

                    list.Add(new DirectoryEntry(name, fileSize, fileClusterNumber));
                }

                    
                offset += 32;
            }
            
            return list;
        }
    }
}
