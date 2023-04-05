using System;
using System.Collections.Generic;

namespace SharpSearchInformation.Model
{
    internal static class ArgOptions
    {
        static ArgOptions(){
            Pattern = "*.*";
            Path = Environment.CurrentDirectory;
            PreviousLength = Subsequent = 40 ;
            ConcatWithUser = false;
        }

        public static string Path { get; set; }
        public static string Pattern { get; set; }
        public static string Text { get; set; }
        
        public static bool ConcatWithUser { get; set; }
        public static bool DirectoryList { get; set; }

        public static int PreviousLength { get; set; }
        public static int Subsequent { get; set; }

        public static List<string> ExcludeExtensions { get; set; }

    }
}
