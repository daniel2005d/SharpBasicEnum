﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        public static void PrintBanner()
        {
            Console.WriteLine();
            Console.WriteLine($"\t{"Author".Pastel(230, 196, 9)}: Cyb3rb0b");
            Console.WriteLine($"\t{"Version".Pastel(230, 196, 9)}: 1.0");
            Console.WriteLine();
        }
    }
}
