using System;

namespace Blog.Views
{
    public class ColorSet
    {
        public ConsoleColor Background { get; set; }
        public ConsoleColor Foreground { get; set; }

        public ColorSet()
        {
            GetConsoleColors();
        }

        public void GetDefault()
        {
            ConsoleColor background = Console.BackgroundColor;
            ConsoleColor foreground = Console.ForegroundColor;
            Console.ResetColor();
            GetConsoleColors();
            PutConsoleColors(foreground, background);
        }

        private void GetConsoleColors()
        {
            Background = Console.BackgroundColor;
            Foreground = Console.ForegroundColor;
        }
        private void PutConsoleColors(ConsoleColor foreground, ConsoleColor background)
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
        }
        public void PutConsoleColors()
        {
            Console.BackgroundColor = Background;
            Console.ForegroundColor = Foreground;
        }
    }
}