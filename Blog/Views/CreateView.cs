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
            //[x] Cadastrar um usuário
            User user;
            do
            {
                List<ConsoleCursor> cursors = ShowScreen(WriteOptions);
                user = GetForm(cursors);
            } while (ConfirmationScreen(WriteConfirmationScreen));
            SendToRepository(user);
            Input.Show();

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

        internal static void Role()
        {
            //[x] Cadastrar um perfil

            Role role;
            do
            {
                List<ConsoleCursor> cursors = ShowScreen(WriteRoleOptions);
                role = GetRoleForm(cursors);
            } while (ConfirmationScreen(WriteConfirmationScreen));
            SendToRepository(role);
            Input.Show();

            static List<ConsoleCursor> WriteRoleOptions()
            {
                const int INITIAL_LINE = 1, INITIAL_COLUMN = 3;
                int lineCursor = INITIAL_LINE;
                var cursor = new ConsoleCursor(1, lineCursor++);
                var cursors = new List<ConsoleCursor>();

                cursor = WriteFormField("CADASTRO DE PERFIL", cursor);

                lineCursor += 2;
                cursor.Set(INITIAL_COLUMN, lineCursor++);
                cursor = WriteFormField("Nome:", cursor);
                cursors.Add(cursor);
                cursor.Set(INITIAL_COLUMN, lineCursor++);
                cursor = WriteFormField("Slug:", cursor);
                cursors.Add(cursor);
                return cursors;
            }

            static Role GetRoleForm(List<ConsoleCursor> cursors)
            {
                const int FIRST_ELEMENT = 0;
                string name, slug;

                Console.SetCursorPosition(cursors[FIRST_ELEMENT].Left, cursors[FIRST_ELEMENT].Top);
                name = Console.ReadLine();
                cursors.RemoveAt(FIRST_ELEMENT);
                Console.SetCursorPosition(cursors[FIRST_ELEMENT].Left, cursors[FIRST_ELEMENT].Top);
                slug = Console.ReadLine();
                cursors.RemoveAt(FIRST_ELEMENT);

                return new Role
                {
                    Name = name,
                    Slug = slug
                };
            }
        }

        internal static void Category()
        {
            //[x] Cadastrar uma categoria
            Category category;
            do
            {
                List<ConsoleCursor> cursors = ShowScreen(WriteCategoryOptions);
                category = GetCategoryForm(cursors);
            } while (ConfirmationScreen(WriteConfirmationScreen));
            SendToRepository(category);
            Input.Show();

            static List<ConsoleCursor> WriteCategoryOptions()
            {
                const int INITIAL_LINE = 1, INITIAL_COLUMN = 3;
                int lineCursor = INITIAL_LINE;
                var cursor = new ConsoleCursor(1, lineCursor++);
                var cursors = new List<ConsoleCursor>();

                cursor = WriteFormField("CADASTRO DE CATEGORIA", cursor);
                lineCursor += 2;
                cursor.Set(INITIAL_COLUMN, lineCursor++);
                cursor = WriteFormField("Nome:", cursor);
                cursors.Add(cursor);
                cursor.Set(INITIAL_COLUMN, lineCursor++);
                cursor = WriteFormField("Slug:", cursor);
                cursors.Add(cursor);
                return cursors;
            }

            static Category GetCategoryForm(List<ConsoleCursor> cursors)
            {
                const int FIRST_ELEMENT = 0;
                string name, slug;

                Console.SetCursorPosition(cursors[FIRST_ELEMENT].Left, cursors[FIRST_ELEMENT].Top);
                name = Console.ReadLine();
                cursors.RemoveAt(FIRST_ELEMENT);
                Console.SetCursorPosition(cursors[FIRST_ELEMENT].Left, cursors[FIRST_ELEMENT].Top);
                slug = Console.ReadLine();
                cursors.RemoveAt(FIRST_ELEMENT);

                return new Category
                {
                    Name = name,
                    Slug = slug
                };
            }
        }

        internal static void Tag()
        {
            //[x] Cadastrar uma tag
            Tag tag;
            do
            {
                List<ConsoleCursor> cursors = ShowScreen(WriteTagOptions);
                tag = GetTagForm(cursors);
            } while (ConfirmationScreen(WriteConfirmationScreen));
            SendToRepository(tag);
            Input.Show();

            static List<ConsoleCursor> WriteTagOptions()
            {
                const int INITIAL_LINE = 1, INITIAL_COLUMN = 3;
                int lineCursor = INITIAL_LINE;
                var cursor = new ConsoleCursor(1, lineCursor++);
                var cursors = new List<ConsoleCursor>();

                cursor = WriteFormField("CADASTRO DE TAG", cursor);
                lineCursor += 2;
                cursor.Set(INITIAL_COLUMN, lineCursor++);
                cursor = WriteFormField("Nome:", cursor);
                cursors.Add(cursor);
                cursor.Set(INITIAL_COLUMN, lineCursor++);
                cursor = WriteFormField("Slug:", cursor);
                cursors.Add(cursor);
                return cursors;
            }

            static Tag GetTagForm(List<ConsoleCursor> cursors)
            {
                const int FIRST_ELEMENT = 0;
                string name, slug;

                Console.SetCursorPosition(cursors[FIRST_ELEMENT].Left, cursors[FIRST_ELEMENT].Top);
                name = Console.ReadLine();
                cursors.RemoveAt(FIRST_ELEMENT);
                Console.SetCursorPosition(cursors[FIRST_ELEMENT].Left, cursors[FIRST_ELEMENT].Top);
                slug = Console.ReadLine();
                cursors.RemoveAt(FIRST_ELEMENT);

                return new Tag
                {
                    Name = name,
                    Slug = slug
                };
            }
        }

        internal static void Post()
        {
            //[ ] Cadastrar um post
            throw new NotImplementedException();
        }

        private static void WriteConfirmationScreen()
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
        private static void SendToRepository<T>(T entity) where T : class, IHasId
        {
            var repository = new Repository<T>();
            repository.Create(entity);
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