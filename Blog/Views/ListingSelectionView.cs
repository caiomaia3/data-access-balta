using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Views
{
    public class ListingSelectionView
    {
        public static void Show()
        {
            const int INVALID_OPTION = -1;
            var colorSet = new ColorSet
            {
                Background = ConsoleColor.Green,
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
            Console.WriteLine("REALIZAR LISTAGENS");
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("Selecione o que listar");
            lineCursor += 2;
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("1 - usuários (Nome, Email, perfis)");
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("2 - categorias com qtd de posts");
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("3 - tags com qtd de posts");
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("4 - posts de uma categoria");
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("5 - todos posts e suas categorias");
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("6 - posts com suas tags");
            lineCursor += 2;
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.WriteLine("0 - Voltar");
            Console.SetCursorPosition(INITIAL_COLUMN, lineCursor++);
            Console.Write("Opção:");
        }
        private static void HandleMenuOption(short option)
        {
            const short USER = 1,
                        CATEGORY = 2,
                        TAGS = 3,
                        POSTS_ON_CAT = 4,
                        POSTS_AND_CATS = 5,
                        POSTS_AND_TAGS = 6,
                        EXIT = 0;

            switch (option)
            {
                case USER: ListingView.Users(); break;
                case CATEGORY: ListingView.Categories(); break;
                case TAGS: ListingView.TagsWithPostCount(); break;
                case POSTS_ON_CAT: ListingView.PostsByCategory(); break;
                case POSTS_AND_CATS: ListingView.AllPostsWithCategories(); break;
                case POSTS_AND_TAGS: ListingView.AllPostsWithTags(); break;
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