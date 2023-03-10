using SharpSearchInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSearchInformation
{
    internal static class CommandLineArguments
    {
        public static void ArgParse(string[] args)
        {
            
            for(int i = 0; i < args.Length; i++)
            {

                switch (args[i])
                {
                    case "--path":
                        i++;
                        ArgOptions.Path = args[i];
                        break;
                    case "--text":
                        i++;
                        ArgOptions.Text = args[i];
                        break;
                    case "--pattern":
                        i++;
                        ArgOptions.Pattern = args[i];
                        break;
                    case "--concat-with-user":
                        i++;
                        ArgOptions.ConcatWithUser = true;
                        break;
                    case "--previous-length":
                    case "-p":
                        i++;
                        ArgOptions.PreviousLength = int.Parse(args[i]);
                        break;
                    case "--next-length":
                    case "-n":
                        i++;
                        ArgOptions.Subsequent = int.Parse(args[i]);
                        break;
                    case "--exclude":
                        i++;
                        ArgOptions.ExcludeExtensions = args[i].Split(new char[] { ',' }).ToList();
                        break;

                }
            }
        }

    }
}
