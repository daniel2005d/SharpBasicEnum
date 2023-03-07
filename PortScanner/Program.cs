
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PortScanner
{
    internal class Program
    {

        private static void PrintBanner()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Port Basic Scan");
            Console.WriteLine("Author: cyberbob");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Version: 1.5");
            Console.ResetColor();
            Console.WriteLine();
        }
        static void Main(string[] args)
        {

            PrintBanner();
            try
            {

               
                CommandLineArguments arguments = new CommandLineArguments(args);

                if (string.IsNullOrEmpty(arguments.Host))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The Host IP is required");
                    Console.ResetColor();
                    return;
                }

                Console.WriteLine($"Scanning {arguments.Host} ...");
                
                if (CheckIsOnline(arguments.Host))
                {
                    string hostname = GetHostName(arguments.Host);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"Hostname: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(hostname);

                    Console.ResetColor();
                    Console.WriteLine();
                    foreach (int port in arguments.ScanPorts)
                    {
                        try
                        {
                            Console.Write($"\rDiscovering {port}      ");
                            TcpClient client = new TcpClient(arguments.Host, port);
                            Console.WriteLine("\rPort {0} is open              ", port);
                            client.Close();
                        }
                        catch (Exception ex)
                        {
                            //   Console.WriteLine("Port {0} is closed", port);
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Scan complete!");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("");
                }
               
                
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }

            Console.WriteLine("Success");

        }

        static string GetHostName(string ip)
        {
            try
            {
                IPHostEntry host = Dns.GetHostEntry(ip);
                return host.HostName;
            }
            catch (Exception)
            {
                return "UNDEFINED";
            }
            
        }

        static bool CheckIsOnline(string ip)
        {
            Ping ping = new Ping();
            PingReply reply = ping.Send(ip);
            if (reply.Status == IPStatus.Success)
            {
                return true;
            }

            return false;
        }
    }
}
