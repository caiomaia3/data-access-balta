using System;

namespace Blog.Views
{
    public static class LinkSelectionView
    {
        public static void Show()
        {
            const int INVALID_OPTION = -1;
            var colorSet = new ColorSet
            {
                Background = ConsoleColor.Gray,
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
            Console.WriteLine("CRIAR RELAÇÃO ENTRE TABELAS");
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("Selecione uma opção abaixo");
            lineCursor += 2;
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("1 - usuário -> perfil");
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("2 - post -> tag");
            lineCursor += 2;
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("0 - Voltar");
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.Write("Opção:");
        }
        private static void HandleMenuOption(short option)
        {
            const short USER_ROLE = 1,
                        POST_TAG = 2,
                        EXIT = 0;

            switch (option)
            {
                case USER_ROLE: LinkingView.UserRole(); break;
                case POST_TAG: LinkingView.PostTag(); break;
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