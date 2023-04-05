using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSearchInformation.Utils
{
    public static class Extensions
    {
        public static string ToHuman(this long length)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            int order = 0;
            while (length >= 1024 && order < sizes.Length - 1)
            {
                order++;
                length = length / 1024;
            }

            // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
            // show a single decimal place, and no space.
            string result = String.Format("{0:0.##} {1}", length, sizes[order]);
            return result;
        }

        public static string FormatFileByExtension(this FileInfo file)
        {
            string filename = string.Empty;
            if (file.Extension.Equals(".config") || file.Extension.Equals(".ps1") || file.Extension.Equals(".conf") || file.Extension.Equals(".txt"))
            {
                filename = $"[yellow]{file.Name}[end]";
            }
            else
            {
                filename = $"[lightgreen] {file.Name}[end]";
            }

            return filename;
        }
    }
}
