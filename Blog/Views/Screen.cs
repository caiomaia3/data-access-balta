using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Views
{
    //TODO Inserir caracteres utf8 no console: For char, the default value is '\x0000'
    public class Screen
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public ColorSet Colors { get; set; }

        public Screen()
        {
            Width = 30;
            Height = 15;
            Colors = new ColorSet();
        }
        public Screen(ColorSet color)
        {
            Width = 30;
            Height = 20;
            Colors = color;
        }

        public void WriteText(Action writer)
        {
            var actualColorSet = new ColorSet();
            Colors.PutConsoleColors();
            writer();
            actualColorSet.PutConsoleColors();
        }

        public List<T> WriteText<T>(Func<List<T>> writer)
        {
            var actualColorSet = new ColorSet();
            Colors.PutConsoleColors();
            var cursors = writer();
            actualColorSet.PutConsoleColors();
            return cursors;
        }

        public void DrawScreen()
        {
            var actualColorSet = new ColorSet();
            Colors.PutConsoleColors();
            DrawScreen(Height, Width);
            actualColorSet.PutConsoleColors();
        }
        public void DrawScreen(ColorSet color)
        {
            var actualColorSet = new ColorSet();
            color.PutConsoleColors();
            DrawScreen(Height, Width);
            actualColorSet.PutConsoleColors();
        }
        private void DrawScreen(int totalLines, int nColumns)
        {
            const int nInitialFinalLines = 2;
            int nLines = totalLines - nInitialFinalLines;

            PrintInitialFinalLine(nColumns);
            PrintBlankLines(nLines, nColumns);
            PrintInitialFinalLine(nColumns);

            void PrintBlankLines(int nLines, int nColumns)
            {
                const string BLANK_CHAR = " ", COLUMNS_CHAR = "|";
                for (int line = 0; line < nLines; line++)
                    PrintLine(nColumns, BLANK_CHAR, COLUMNS_CHAR);
            }

            void PrintInitialFinalLine(int nColumns)
            {
                const string LINE_CHAR = "-", CORNER_CHAR = "+";
                PrintLine(nColumns, LINE_CHAR, CORNER_CHAR);
            }

            void PrintLine(int nColumns, string lineChar, string cornerChar)
            {
                Console.Write(cornerChar);
                for (int column = 0; column - 2 < nColumns; column++)
                    Console.Write(lineChar);
                Console.Write(cornerChar);
                Console.Write(Environment.NewLine);
            }
        }
    }
}