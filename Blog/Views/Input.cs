using System;

namespace Blog.Views
{
    public static class Input
    {
        public static void Show()
        {
            const int INVALID_OPTION = -1;
            var colorSet = new ColorSet
            {
                Background = ConsoleColor.Red,
                Foreground = ConsoleColor.Black
            };
            var scr = new Screen(colorSet);

            Console.Clear();
            scr.DrawScreen();
            scr.WriteText(WriteOptions);

            bool isValid = short.TryParse(Console.ReadLine(), out short option);
            if (isValid)
            {
                HandleMenuOption(option);
            }
            else
            {
                HandleMenuOption(INVALID_OPTION);
            }
        }
        private static void WriteOptions()
        {
            const int INITIAL_LINE = 1, INITIAL_COLUMN = 3;
            int lineCursor = INITIAL_LINE;

            Console.SetCursorPosition(1, lineCursor++);
            Console.WriteLine("CADASTRO");
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("Selecione uma opção abaixo");
            lineCursor += 2;
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("1 - Cadastrar usuário");
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("2 - Cadastrar perfil");
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("3 - Cadastrar categoria");
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("4 - Cadastrar tag");
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("5 - Cadastrar post");
            lineCursor += 2;
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("0 - Voltar");
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.Write("Opção:");
        }

        private static void HandleMenuOption(short option)
        {
            const short USER = 1,
                        ROLE = 2,
                        CATEGORY = 3,
                        TAG = 4,
                        POST = 5,
                        EXIT = 0;

            switch (option)
            {
                case USER: CreateView.User(); break;
                case ROLE: CreateView.Role(); break;
                case CATEGORY: CreateView.Category(); break;
                case TAG: CreateView.Tag(); break;
                case POST: CreateView.Post(); break;
                case EXIT:
                    {
                        Console.Clear();
                        Menu.Show();
                        break;
                    }
                default: Show(); break;
            }
        }
    }
}