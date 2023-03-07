using System;

namespace SharpSearchInformation.Model
{
    internal class ArgOptions
    {
        internal ArgOptions(){
            this.Pattern = "*.*";
            this.Path = Environment.CurrentDirectory;
            this.PreviousLength = this.NextLength = 40 ;
            this.ConcatWithUser = false;
        }

        public string Path { get; set; }
        public string Pattern { get; set; }
        public string Text { get; set; }
        public bool ConcatWithUser { get; set; }

        public int PreviousLength { get; set; }
        public int NextLength { get; set; }

    }
}
