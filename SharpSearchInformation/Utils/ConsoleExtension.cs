using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SharpSearchInformation.Utils
{
    public static class ConsoleExtension
    {
        #region Constants
        private const int STD_OUTPUT_HANDLE = -11;
        private const uint ENABLE_PROCESSED_OUTPUT = 0x0001;
        private const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;
        #endregion
        #region WINAPI
        [DllImport("kernel32")]
        private static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        [DllImport("kernel32")]
        private static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

        [DllImport("kernel32", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int nStdHandle);
        #endregion

        //Console.WriteLine("\u001b[38;2;38;163;146mDaniel\u001b[0m")
        // https://gist.github.com/fnky/458719343aabd01cfb17a3a4f7296797

        private const string _TRUE_COLOR = "2";
        private const string _FOREGROUND = "38";
        private const string _FORMAT_STRING_COLOR = "\u001b[{0};{1};{2};{3};{4}m";
        private const string _RESET_COLOR = "\u001b[0m";

        private static readonly ReadOnlyDictionary<string, Color> _Colors = new ReadOnlyDictionary<string, Color>(new Dictionary<string, Color>
        {
            ["[red]"] = Color.FromArgb(224,27,36),
            ["[blue]"] = Color.FromArgb(0,134,255),
            ["[yellow]"] = Color.FromArgb(255,243,0),
            ["[green]"] = Color.FromArgb(159,239,0),
            ["[orange]"] = Color.FromArgb(227, 117, 20),
            ["[white]"] = Color.FromArgb(255, 255, 255),
            ["[cyan]"] = Color.FromArgb(15, 197, 217),
            ["[lightgreen]"] = Color.FromArgb(174, 230, 7),
            ["[darkgreen]"] = Color.FromArgb(28, 82, 3)

        });
        //private const string _COLOR_FORMAT = "\u001b[{0};{1};{2};{3};{4}m{5}\u001b[0m";

        static ConsoleExtension()
        {
            var iStdOut = GetStdHandle(STD_OUTPUT_HANDLE);

            var _ = GetConsoleMode(iStdOut, out var outConsoleMode)
                        && SetConsoleMode(iStdOut, outConsoleMode | ENABLE_PROCESSED_OUTPUT | ENABLE_VIRTUAL_TERMINAL_PROCESSING);
        }

        private static string Format(int r,int g, int b)
        {
            return string.Concat(string.Format(_FORMAT_STRING_COLOR, _FOREGROUND, _TRUE_COLOR, r, g, b), "{0}", _RESET_COLOR);
        }

        private static string ReplaceTagbyColor(Color color)
        {
            return string.Format(_FORMAT_STRING_COLOR, _FOREGROUND, _TRUE_COLOR, color.R, color.G, color.B);
        }

        private static string ColorFormat(Color color)
        {
            string textowithcolor = ReplaceTagbyColor(color);
            return $"{textowithcolor}{_RESET_COLOR}";
        }

        private static string ColorFormat(string input)
        {
            Regex regcolor = new Regex(@"\[(\w+)\]");
            if (regcolor.IsMatch(input))
            {
                foreach (Match match in regcolor.Matches(input))
                {
                    string color = match.Value;
                    if (_Colors.ContainsKey(color))
                    {
                        Color textcolor = _Colors[color];
                        input = input.Replace(color, ReplaceTagbyColor(textcolor));
                    }
                    else if (color.Equals("[end]"))
                    {
                        input = input.Replace(color, _RESET_COLOR);
                    }
                }

                //return $"\u001b[38;2;{input}";
            }

            return input;
        }

        public static void WriteLine(this string input, Color color)
        {
            input = ColorFormat(input);
            Console.WriteLine(input);
        }

        public static void WriteLine(this string input)
        {
            
            input = ColorFormat(input);
            Console.WriteLine(input);
        }
        public static void WriteLine(this string input, int r, int g, int b)
        {
            string toprint = string.Format(Format(r, g, b), input);
            Console.WriteLine(toprint);
        }
    }
}
