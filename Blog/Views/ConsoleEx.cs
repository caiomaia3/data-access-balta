using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Views
{
    public static class ConsoleEx
    {
        public static void WriteLine(string s)
        {
            System.Console.WriteLine(s);
        }

        public static void WriteLine(string s, ColorSet c)
        {
            System.Console.BackgroundColor = c.Background;
            System.Console.ForegroundColor = c.Foreground;
            System.Console.WriteLine(s);
            System.Console.ResetColor();
        }
    }
}