
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortScanner
{
    public class CommandLineArguments
    {
        private readonly Dictionary<string, string> arguments;
        private int[] CommonPorts = { 21, 22, 25, 53, 80, 110, 123, 143, 443, 465, 431, 993, 995, 445, 8080, 8000, 139, 589 };
        private string[] _args;
        public List<int> ScanPorts { get; set; }
        public string Host;
        public CommandLineArguments(string[] args)
        {
            this.ScanPorts = new List<int>();
            this._args = args;

            arguments = new Dictionary<string, string>();
            this.BindArguments();

            if (this.arguments.Count == 0)
            {
                throw new Exception("The Host argument is required");
            }

            this.Host = this.GetValue("Host");
            this.BindPorts2Scan();
        }

        private void BindPorts2Scan()
        {
            string ports = this.GetValue("Ports");
            if (!string.IsNullOrEmpty(ports))
            {
                string[] split = ports.Split(new char[] { '-'}, StringSplitOptions.RemoveEmptyEntries);
                int start = int.Parse(split[0]);
                int end = int.Parse(split[1]);

                for(var i= start; i <= end; i++)
                {
                    this.ScanPorts.Add(i);
                }

            }
            else
            {
                this.ScanPorts = this.CommonPorts.ToList();
            }
        }

        private void BindArguments()
        {
            for (int i = 0; i < this._args.Length; i++)
            {
                if (this._args[i].StartsWith("-"))
                {
                    string key = this._args[i].Substring(1);
                    string value = "";

                    if (i + 1 < this._args.Length && !this._args[i + 1].StartsWith("-"))
                    {
                        value = this._args[i + 1];
                        i++;
                    }

                    arguments[key.ToLower()] = value;
                }
            }
        }

        private string GetValue(string key)
        {
            if (arguments.ContainsKey(key.ToLower()))
            {
                return arguments[key.ToLower()];
            }
            else
            {
                return "";
            }
        }
    }
}
