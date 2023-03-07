using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSearchInformation.Model
{
    internal class TextModel
    {
        public string Path { get; set; }
        public string Text { get; set; }

        public string PreviousText { get; set; }
        public string NextText { get; set; }
    }
}
