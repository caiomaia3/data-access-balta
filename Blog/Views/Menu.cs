using System;

namespace Blog.Views
{
    public static class Menu
    {
        private static void ShowScreen()
        {
            var colorSet = new ColorSet
            {
                Background = ConsoleColor.Blue,
                Foreground = ConsoleColor.Black
            };
            var scr = new Screen(colorSet) { Height = 15 };

            Console.Clear();
            scr.DrawScreen();
            scr.WriteText(WriteOptions);
        }
        public static void Show()
        {
            const int INVALID_OPTION = -1;
            ShowScreen();
            bool isValid = short.TryParse(Console.ReadLine(), out short option);

            if (isValid) HandleMenuOption(option);
            else HandleMenuOption(INVALID_OPTION);
        }

        private static void HandleMenuOption(short option)
        {
            const short INPUT = 1,
                        LIST = 2,
                        LINK = 3,
                        EXIT = 0;

            switch (option)
            {
                case INPUT: Input.Show(); break;
                case LIST: Console.WriteLine("List"); break;
                case LINK: LinkSelectionView.Show(); break;
                case EXIT:
                    {
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    }
                default: Show(); break;
            }
        }

        private static void WriteOptions()
        {
            const int INITIAL_LINE = 2, INITIAL_COLUMN = 3;
            int lineCursor = INITIAL_LINE;

            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("Sistema Database");
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("==================");
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("Selecione uma opção abaixo");
            lineCursor += 2;
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("1 - Cadastrar");
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("2 - Listar");
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("3 - Vincular Tabelas");
            lineCursor += 2;
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("0 - Sair");
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.Write("Opção:");
        }
    }
}