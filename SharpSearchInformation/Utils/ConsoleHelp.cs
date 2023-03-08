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
         
            Console.WriteLine("Usage SharpSearchInformation.exe --text <Text 2 Find> [options]".Pastel(16, 228, 232));
            Console.WriteLine("\tOptions:".Pastel(16, 228, 232));
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
            Console.WriteLine($"\t{"Author".Pastel(230, 196, 9)}: Cyb3rb0b");
            Console.WriteLine($"\t{"Version".Pastel(230, 196, 9)}: {strversion}");
            Console.WriteLine();
        }

        public static void PrintError(Exception ex)
        {

            Console.WriteLine($" {"[-]".Pastel(232, 7, 7)} {ex.Message.Pastel(Color.Red)}");
            Console.WriteLine();
        }

        public static void PrintIcon()
        {
            Console.Write($" {"[+]".Pastel(86, 245, 0)}");
        }

        public static void PrintInfo(string text, int r, int g, int b)
        {
            Console.WriteLine($" {"[+]".Pastel(86, 245, 0)} {text.Pastel(r,g,b)}");
        }
    }
}
