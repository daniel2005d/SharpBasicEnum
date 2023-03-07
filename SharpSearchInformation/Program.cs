using SharpSearchInformation.Model;
using System;
using System.Collections.Generic;
using SharpSearchInformation.Utils;
using System.Drawing;

namespace SharpSearchInformation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelp.PrintBanner();
            var arguments = CommandLineArguments.ArgParse(args);
            if (!string.IsNullOrEmpty(arguments.Text))
            {
                FilesManager filesManager = new FilesManager(arguments.PreviousLength, arguments.NextLength);
                filesManager.OnFound += FilesManager_OnFound;
                List<string> texttofind = new List<string>() { arguments.Text};
                if (arguments.ConcatWithUser)
                {
                    UsersManager usersManager = new UsersManager();
                    List<UserModel> users = usersManager.GetAllUsers();
                    foreach (var user in users)
                    {
                        texttofind.Add($"{user.Name} {arguments.Text}");
                        texttofind.Add($"{arguments.Text} {user.Name}");
                        Console.WriteLine($"{user.SID}:{user.Name.Pastel(Color.FromArgb(140, 237, 36))} Enabled:{user.IsEnabled}");
                    }
                }
                
                foreach(string seed in texttofind)
                {
                    Console.WriteLine($"[+] Looking for a  Text {seed.Pastel(Color.FromArgb(19, 232, 186))}");
                    List<TextModel> foundtext = filesManager.SearchText(arguments.Path, seed, arguments.Pattern);
                    ConsoleHelp.PrintInfo($"Found Files {foundtext.Count.ToString()}",203, 7, 237);
                }
            }
            else
            {
                Console.WriteLine("The text to search is required".Pastel(ConsoleColor.Red));
                ConsoleHelp.PrintHelp();
            }
        }

        private static void FilesManager_OnFound(TextModel text)
        {
            //Console.WriteLine($" {"[+]".Pastel(86, 245, 0)}\t{text.Path.Pastel(7, 237, 22)}");
            ConsoleHelp.PrintInfo(text.Path, 7, 237, 22);
            
            Console.WriteLine($"\t{text.PreviousText}{text.Text.Pastel(7, 160, 237)}{text.NextText}");
        }
    }
}
