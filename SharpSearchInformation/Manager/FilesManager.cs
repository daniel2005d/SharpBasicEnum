using SharpSearchInformation.Manager;
using SharpSearchInformation.Model;
using SharpSearchInformation.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static SharpSearchInformation.Manager.CustomEvents;

namespace SharpSearchInformation
{
    internal class FilesManager : ManagerBase
    {
        private List<string> EXT_BLACK_LIST = new List<string>() { ".exe", ".dll", ".com", ".png", ".jpeg", ".bmp", ".jpg",".msi" };
        private readonly int _previous, _next;

        public FilesManager(int previous, int next, List<string> excludeextensions)
        {
            this._previous = previous;
            this._next = next;
            if (excludeextensions != null)
            {
                this.EXT_BLACK_LIST.AddRange(excludeextensions);
            }
        }

        private List<string> GetFiles(string path)
        {
            List<string> result = new List<string>();
            string[] allDirectories = Directory.GetDirectories(path);
            foreach (string dir in allDirectories)
            {
                try
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(dir);
                    FileInfo[] info = directoryInfo.GetFiles("*", SearchOption.AllDirectories);
                    foreach(var file in info)
                    {
                        result.Add(file.FullName);
                    }
                }
                catch { }

                
            }

            try
            {
                result.AddRange(Directory.GetFiles(path));
            }
            catch { }

            return result;
        }
      
        internal List<TextModel> SearchText(string path, string text2find, string pattern = "*.*")
        {
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException($"Directory {path} does not exists");
            }
            
            List<TextModel> findtext = new List<TextModel>();
            try
            {
                
                Regex regex = new Regex(text2find, RegexOptions.IgnoreCase);
                List<string> files = this.GetFiles(path);
                foreach (var file in files.Where(f => !EXT_BLACK_LIST.Contains(Path.GetExtension(f).ToLower())))
                {
                    string fileContent = File.ReadAllText(file);
                    string output = this.Find(fileContent, text2find);
                    if (!string.IsNullOrEmpty(output))
                    {
                        TextModel model = new TextModel()
                        {
                            Path = file,
                            Text = output,
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
                ConsoleHelp.PrintError(ex);
            }

            return findtext;
        }

        internal event OnFoundDelegate OnFound;

    }
}
