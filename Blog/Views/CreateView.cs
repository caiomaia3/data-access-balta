using System;
using System.Collections.Generic;
using Blog.Interfaces;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Views
{
    public class CreateView
    {
        internal static void User()
        {
            User user;
            do
            {
                List<ConsoleCursor> cursors = ShowScreen(WriteOptions);
                user = GetForm(cursors);
                System.Console.WriteLine(user.Name);
            } while (ConfirmationScreen(WriteConfirmationScreen));
            SendToRepository(user);
            Input.Show();

            static void WriteConfirmationScreen()
            {
                const int INITIAL_LINE = 1, INITIAL_COLUMN = 3;
                int lineCursor = INITIAL_LINE;
                var cursor = new ConsoleCursor();

                lineCursor += 7;
                cursor.Set(INITIAL_COLUMN, lineCursor++);
                WriteFormField("ENTER - confirmar", cursor);
                cursor.Set(INITIAL_COLUMN, lineCursor++);
                WriteFormField(" ESC  - cancelar", cursor);
            }

            static List<ConsoleCursor> WriteOptions()
            {
                const int INITIAL_LINE = 1, INITIAL_COLUMN = 3;
                int lineCursor = INITIAL_LINE;
                var cursor = new ConsoleCursor(1, lineCursor++);
                var cursors = new List<ConsoleCursor>();

                cursor = WriteFormField("CADASTRO DE USUÁRIO", cursor);

                lineCursor += 2;
                cursor.Set(INITIAL_COLUMN, lineCursor++);
                cursor = WriteFormField("Nome:", cursor);
                cursors.Add(cursor);

                cursor.Set(INITIAL_COLUMN, lineCursor++);
                cursor = WriteFormField("Email:", cursor);
                cursors.Add(cursor);

                //TODO Implementar senha oculta
                // https://stackoverflow.com/questions/23433980/c-sharp-console-hide-the-input-from-console-window-while-typing
                cursor.Set(INITIAL_COLUMN, lineCursor++);
                cursor = WriteFormField("Senha:", cursor);
                cursors.Add(cursor);

                cursor.Set(INITIAL_COLUMN, lineCursor++);
                cursor = WriteFormField("Bio:", cursor);
                cursors.Add(cursor);

                cursor.Set(INITIAL_COLUMN, lineCursor++);
                cursor = WriteFormField("Imagem:", cursor);
                cursors.Add(cursor);

                cursor.Set(INITIAL_COLUMN, lineCursor++);
                cursor = WriteFormField("Slug:", cursor);
                cursors.Add(cursor);
                return cursors;
            }

            static User GetForm(List<ConsoleCursor> cursors)
            {
                const int FIRST_ELEMENT = 0;
                string name, email, password, bio, image, slug;

                Console.SetCursorPosition(cursors[FIRST_ELEMENT].Left, cursors[FIRST_ELEMENT].Top);
                name = Console.ReadLine();
                cursors.RemoveAt(FIRST_ELEMENT);

                Console.SetCursorPosition(cursors[FIRST_ELEMENT].Left, cursors[FIRST_ELEMENT].Top);
                email = Console.ReadLine();
                cursors.RemoveAt(FIRST_ELEMENT);

                Console.SetCursorPosition(cursors[FIRST_ELEMENT].Left, cursors[FIRST_ELEMENT].Top);
                password = Console.ReadLine();
                cursors.RemoveAt(FIRST_ELEMENT);

                Console.SetCursorPosition(cursors[FIRST_ELEMENT].Left, cursors[FIRST_ELEMENT].Top);
                bio = Console.ReadLine();
                cursors.RemoveAt(FIRST_ELEMENT);

                Console.SetCursorPosition(cursors[FIRST_ELEMENT].Left, cursors[FIRST_ELEMENT].Top);
                image = Console.ReadLine();
                cursors.RemoveAt(FIRST_ELEMENT);

                Console.SetCursorPosition(cursors[FIRST_ELEMENT].Left, cursors[FIRST_ELEMENT].Top);
                slug = Console.ReadLine();
                cursors.RemoveAt(FIRST_ELEMENT);

                return new User
                {
                    Name = name,
                    Email = email,
                    PasswordHash = password,
                    Bio = bio,
                    Image = image,
                    Slug = slug
                };
            }
        }

        private static void SendToRepository<T>(T entity) where T : class, IHasId
        {
            var repository = new Repository<T>();
            repository.Create(entity);
        }

        internal static void Role()
        {
            throw new NotImplementedException();
        }

        internal static void Category()
        {
            throw new NotImplementedException();
        }

        internal static void Tag()
        {
            throw new NotImplementedException();
        }

        internal static void Post()
        {
            throw new NotImplementedException();
        }

        private static bool ConfirmationScreen(Action writeOnScreen)
        {

            ShowScreen(writeOnScreen);
            ConsoleKey pressedKey;
            do
            {
                pressedKey = Console.ReadKey().Key;
            }
            while (pressedKey != ConsoleKey.Escape && pressedKey != ConsoleKey.Enter);
            return pressedKey == ConsoleKey.Escape;
        }

        private static void ShowScreen(Action textToWrite, Screen scr, ConsoleCursor cursor)
        {
            Console.Clear();
            scr.DrawScreen();
            Console.SetCursorPosition(cursor.Left, cursor.Top);
            scr.WriteText(textToWrite);
        }

        private static void ShowScreen(Action textToWrite, Screen scr)
        {
            Console.Clear();
            scr.DrawScreen();
            scr.WriteText(textToWrite);
        }
        private static void ShowScreen(Action textToWrite)
        {
            var colorSet = new ColorSet
            {
                Background = ConsoleColor.Red,
                Foreground = ConsoleColor.Black
            };
            var scr = new Screen(colorSet);
            ShowScreen(textToWrite, scr);
        }
        private static List<T> ShowScreen<T>(Func<List<T>> textToWrite)
        {
            var colorSet = new ColorSet
            {
                Background = ConsoleColor.Red,
                Foreground = ConsoleColor.Black
            };
            var scr = new Screen(colorSet);

            Console.Clear();
            scr.DrawScreen();
            return scr.WriteText(textToWrite);
        }
        public static ConsoleCursor WriteFormField(string fieldText, ConsoleCursor initialCursor)
        {
            var finalCursor = initialCursor;
            Console.SetCursorPosition(initialCursor.Left, initialCursor.Top);
            finalCursor.Left += fieldText.Length;
            System.Console.WriteLine(fieldText);
            return finalCursor;
        }
    }
    public struct ConsoleCursor
    {
        public int Left;
        public int Top;

        public ConsoleCursor(int left, int top)
        {
            Left = left;
            Top = top;
        }

        public ConsoleCursor Set(int left, int top)
        {
            Left = left;
            Top = top;
            return this;
        }
    }
}