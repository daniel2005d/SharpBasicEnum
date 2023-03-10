using SharpSearchInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SharpSearchInformation.Manager
{
    internal abstract class ManagerBase
    {
        private readonly int _previous, _subsequent;

        public ManagerBase()
        {
            this._previous = ArgOptions.PreviousLength;
            this._subsequent = ArgOptions.Subsequent;
        }

        protected string Find(string input, string text2find)
        {
            string result = string.Empty;

            Regex regex = new Regex(text2find, RegexOptions.IgnoreCase);
            if (regex.IsMatch(input))
            {
                foreach (Match match in regex.Matches(input))
                {
                    int previusLength = Math.Min(this._previous, match.Index); 
                    int nextLength = Math.Min(this._subsequent, input.Length - match.Index - 1); 
                    string word = match.Value;
                    
                    int index = match.Index;
                    int start= Math.Max(index - previusLength, 0);
                        int end = Math.Min(index + word.Length + nextLength, input.Length);

                        string previustext = input.Substring(start, index - start);
                        string beforetext = input.Substring(index + word.Length, end - (index + word.Length));
                    
                    if (start > 0)
                    {
                        previustext = $"...{previustext}";
                    }

                    if (end != input.Length)
                    {
                        beforetext += "\n";
                    }

                    result += $"{previustext}[blue]{word}[end]{beforetext}";
                }
            }

            return result;

        }
    }
}
