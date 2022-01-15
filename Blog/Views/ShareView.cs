using System;
using System.Collections.Generic;
using Blog.Interfaces;
using Blog.Repositories;
using Blog.Services;

namespace Blog.Views
{
    public static class ShareView
    {
        internal static void WriteConfirmationScreen()
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
        internal static bool ConfirmationScreen(Action writeOnScreen)
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

        internal static void ShowScreen(Action textToWrite, Screen scr, ConsoleCursor cursor)
        {
            Console.Clear();
            scr.DrawScreen();
            Console.SetCursorPosition(cursor.Left, cursor.Top);
            scr.WriteText(textToWrite);
        }

        internal static void ShowScreen(Action textToWrite, Screen scr)
        {
            Console.Clear();
            scr.DrawScreen();
            scr.WriteText(textToWrite);
        }
        internal static void ShowScreen(Action textToWrite)
        {
            var colorSet = new ColorSet
            {
                Background = ConsoleColor.Red,
                Foreground = ConsoleColor.Black
            };
            var scr = new Screen(colorSet);
            ShowScreen(textToWrite, scr);
        }
        public static List<T> ShowScreen<T>(Func<List<T>> textToWrite)
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
        internal static ConsoleCursor WriteFormField(string fieldText, ConsoleCursor initialCursor)
        {
            var finalCursor = initialCursor;
            Console.SetCursorPosition(initialCursor.Left, initialCursor.Top);
            finalCursor.Left += fieldText.Length;
            System.Console.WriteLine(fieldText);
            return finalCursor;
        }
        internal static void SendToRepository<T>(T entity) where T : class, IHasId
        {

            ConnectionService.GetInstance().Connection.Open();
            var repository = new Repository<T>();
            repository.Create(entity);
            ConnectionService.GetInstance().Connection.Close();
        }
    }
}