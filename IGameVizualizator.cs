using System;
using System.Collections.Generic;

namespace TetrisSharp
{
    public interface IGameVizualizator
    {
        void RedrawBoard(bool[,] board);

        void DrawScore(int score);
    }
}
