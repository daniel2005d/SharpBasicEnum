using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharpSearchInformation.Utils
{
    internal static class ConsoleHelp
    {
        public static void PrintHelp()
        {
         
            "Usage SharpSearchInformation.exe --text <Text 2 Find> [options]".WriteLine(16, 228, 232);
            "\tOptions:".WriteLine(16, 228, 232);
            Console.WriteLine("\t--tree: List all files from directory.");
            Console.WriteLine("\t--Path: Search path");
            Console.WriteLine("\t--text: Text to search for");
            Console.WriteLine("\t--pattern: Defines the pattern to use in the files, by default is *.*.Extensions.exe, .com, .png, .jpg are omitted.");
            Console.WriteLine("\t--concat-with-user: Adds at the beginning and at the end of the text, the names of the system users.");
            Console.WriteLine("\t--previous-length|-p: Sets the text size to display before matching the searched text.");
            Console.WriteLine("\t--next-length|-n: Sets the text size to display after matching the searched text.");
            Console.WriteLine("\t--exclude: List of exclude extensions, separated by coma.");
        }

        public static void PrintBanner()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            
            string strversion = $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
            Console.WriteLine();
            $"\t[orange]{"Author"}[end]: Cyb3rb0b".WriteLine();
            $"\t[orange]{"Version"}[end]: {strversion}".WriteLine();
            Console.WriteLine();
        }

        public static void PrintError(Exception ex)
        {

            $"[white][-][end][red]{ex.Message}[end]".WriteLine();
            Console.WriteLine();
        }

        public static void PrintInfo(string text)
        {
            text.WriteLine(7, 237, 22);
        }

    }
}
