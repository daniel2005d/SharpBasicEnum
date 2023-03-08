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
        public static ArgOptions ArgParse(string[] args)
        {
            ArgOptions options = new ArgOptions();
            for(int i = 0; i < args.Length; i++)
            {

                switch (args[i])
                {
                    case "--path":
                        i++;
                        options.Path = args[i];
                        break;
                    case "--text":
                        i++;
                        options.Text = args[i];
                        break;
                    case "--pattern":
                        i++;
                        options.Pattern = args[i];
                        break;
                    case "--concat-with-user":
                        i++;
                        options.ConcatWithUser = true;
                        break;
                    case "--previous-length":
                    case "-p":
                        i++;
                        options.PreviousLength = int.Parse(args[i]);
                        break;
                    case "--next-length":
                    case "-n":
                        i++;
                        options.NextLength = int.Parse(args[i]);
                        break;
                    case "--exclude":
                        i++;
                        options.ExcludeExtensions = args[i].Split(new char[] { ',' }).ToList();
                        break;

                }
            }

            return options;
        }

    }
}
