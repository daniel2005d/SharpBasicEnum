using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRunAsUser
{
    internal static class CommandLineArguments
    {
        private static Dictionary<string, string> _arguments = new Dictionary<string, string>();
        public static Dictionary<string, string> ArgParse(string[] args)
        {
            
            for(int i = 0; i < args.Length; i++)
            {

                switch (args[i])
                {
                    case "--username":
                        i++;
                        _arguments.Add("username", args[i]);
                        break;
                    case "--password":
                        i++;
                        _arguments.Add("password", args[i]);
                        break;
                    case "--domain":
                        i++;
                        _arguments.Add("domain", args[i]);
                        break;
                    case "--lhost":
                        i++;
                        _arguments.Add("lhost", args[i]);
                        break;
                    case "--lport":
                        i++;
                        _arguments.Add("lport", args[i]);
                        break;
                    case "--command":
                    case "-c":
                        i++;
                        _arguments.Add("command", args[i]);
                        break;
                    case "--executable":
                        i++;
                        _arguments.Add("executable", args[i]);
                        break;
                }
            }

            return _arguments;
        }

    }
}
