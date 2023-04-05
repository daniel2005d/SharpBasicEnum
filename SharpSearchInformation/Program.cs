using SharpSearchInformation.Model;
using System;
using System.Collections.Generic;
using SharpSearchInformation.Utils;
using System.Drawing;
using SharpSearchInformation.Manager;
using System.IO;

namespace SharpSearchInformation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                ConsoleHelp.PrintBanner();
                
                CommandLineArguments.ArgParse(args);
                if (!string.IsNullOrEmpty(ArgOptions.Text))
                {
                    EventLogManager logManager = new EventLogManager();
                    logManager.OnFound += LogManager_OnFound;
                    logManager.OnProgress += LogManager_OnProgress;
                    FilesManager filesManager = new FilesManager(ArgOptions.PreviousLength, ArgOptions.Subsequent, ArgOptions.ExcludeExtensions);
                    filesManager.OnFound += FilesManager_OnFound;
                    List<string> texttofind = new List<string>() { ArgOptions.Text };
                    if (ArgOptions.ConcatWithUser)
                    {
                        UsersManager usersManager = new UsersManager();
                        List<UserModel> users = usersManager.GetAllUsers();
                        foreach (var user in users)
                        {
                            texttofind.Add($"{user.Name} {ArgOptions.Text}");
                            texttofind.Add($"{ArgOptions.Text} {user.Name}");
                            $"[green][+][end]{user.SID}:{user.Name} Enabled:{user.IsEnabled}".WriteLine();
                        }
                    }

                    foreach (string seed in texttofind)
                    {
                        $"[green][+][end] Looking for a  Text [orange]{seed}[end]".WriteLine();
                        List<TextModel> foundtext = filesManager.SearchText(ArgOptions.Path, seed, ArgOptions.Pattern);
                        $"Found Files {foundtext.Count.ToString()}".WriteLine(203, 7, 237);
                    }

                    ConsoleHelp.PrintInfo("================ Find into EventLog =======================");
                    logManager.SearchText(ArgOptions.Text);
                }
                else if (ArgOptions.DirectoryList)
                {
                    FilesManager filesManager = new FilesManager(0,0,null);
                    List<string> files = filesManager.GetFiles(ArgOptions.Path, ArgOptions.Pattern);
                    List<string> directories = new List<string>();
                    $"Total Found [cyan]{files.Count}[end]".WriteLine();
                    foreach (string f in files)
                    {
                        FileInfo fn = new FileInfo(f);
                        
                        if (!directories.Contains(fn.DirectoryName))
                        {
                            $"[green][+][end]{fn.DirectoryName}".WriteLine();
                            directories.Add(fn.DirectoryName);
                        }
                        
                        
                        $"\t[green][+][end] {fn.FormatFileByExtension()}[blue] Length[end]: {fn.Length.ToHuman()} - [blue]Creation Time[end]:{fn.CreationTime} - [blue]Last Write[end]: {fn.LastWriteTime}".WriteLine();
                    }
                }
               
                else
                {
                    "[*] [red]The text to search is required[end]".WriteLine();
                    ConsoleHelp.PrintHelp();
                }
            }
            catch(Exception ex)
            {
                ConsoleHelp.PrintError(ex);
            }
           
            if (System.Diagnostics.Debugger.IsAttached)
            {
                Console.ReadLine();
            }
        }

        private static void LogManager_OnProgress(string message)
        {
            message.WriteLine(57, 15, 209);
        }

        private static void LogManager_OnFound(EventLogModel entry)
        {
            string header = $"[green][+][end][orange] {entry.Index}[end] {entry.EventLogName} by {entry.UserName?.ToString()} type [green]{entry.EventLogName}[end] Written Date {entry.Created.ToLongDateString()}";
            string detail = $"\t{entry.Message}";
            header.WriteLine();
            detail.WriteLine();

        }

        private static void FilesManager_OnFound(TextModel text)
        {
            text.Path.WriteLine();
            text.Text.WriteLine();
        }
    }
}
