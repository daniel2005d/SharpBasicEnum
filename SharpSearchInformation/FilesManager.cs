using SharpSearchInformation.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SharpSearchInformation
{
    internal class FilesManager
    {
        private List<string> EXT_BLACK_LIST = new List<string>() { ".exe", ".dll", ".com", ".png", ".jpeg", ".bmp", ".jpg" };
        private readonly int _previous, _next;

        public FilesManager(int previous, int next)
        {
            this._previous = previous;
            this._next = next;
        }
      
        internal List<TextModel> SearchText(string path, string text2find, string pattern = "*.*")
        {
            List<TextModel> findtext = new List<TextModel>();
            try
            {
                Regex regex = new Regex(text2find, RegexOptions.IgnoreCase);
                string[] files = Directory.GetFiles(path, pattern, SearchOption.AllDirectories);
                foreach (var file in files.Where(f => !EXT_BLACK_LIST.Contains(Path.GetExtension(f))))
                {
                    string fileContent = File.ReadAllText(file);
                    if (regex.IsMatch(fileContent))
                    {
                        Match match = regex.Match(fileContent);
                        int startIndex = match.Index;
                        int endIndex = match.Index + match.Length;

                        TextModel model = new TextModel()
                        {
                            Path = file,
                            Text = fileContent.Substring(startIndex, (endIndex - startIndex)),
                            PreviousText = fileContent.Substring(startIndex - this._previous, this._previous),
                            NextText = fileContent.Substring(startIndex + text2find.Length, this._next),
                        };

                        findtext.Add(model);

                        if (this.OnFound != null)
                        {
                            this.OnFound(model);
                        }
                    }


                }
            }
            catch (Exception ex)
            {

            }

            return findtext;
        }

        internal delegate void OnFoundDelegate(TextModel text);
        internal event OnFoundDelegate OnFound;
    }
}
