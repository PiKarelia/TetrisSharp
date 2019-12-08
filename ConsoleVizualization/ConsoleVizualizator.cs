using System;
using System.Collections.Generic;

namespace TetrisSharp.ConsoleVizualization
{
    public class ConsoleVizualizator : IGameVizualizator
    {
        private readonly int _numberOfIgnoredRows = 4;
        public void RedrawBoard(bool[,] board)
        {

            for (int i = 0; i < board.GetLength(1) + 2; i++)
            {
                Console.SetCursorPosition(2 + i * 2, 2 - 1);
                Console.Write("══");
            }

            for (int i = _numberOfIgnoredRows; i < board.GetLength(0); i++)
            {
                Console.SetCursorPosition(2, 2 + i - _numberOfIgnoredRows);
                Console.Write("││");



                Console.SetCursorPosition(2 + 2, 2 + i - _numberOfIgnoredRows);
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.WriteLine(board[i, j] ? "▓▓" : "  ");
                }

                Console.SetCursorPosition(2 + board.GetLength(1) * 2 + 2, 2 + i - _numberOfIgnoredRows);
                Console.Write("││");
            }

            var boardheight = board.GetLength(0) - _numberOfIgnoredRows;
            for (int i = 0; i < board.GetLength(1) + 2; i++)
            {
                Console.SetCursorPosition(2 + i * 2, 2 + boardheight);
                Console.Write("══");
            }
        }
    }
}
