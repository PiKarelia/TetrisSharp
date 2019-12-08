using System;
using System.Collections.Generic;

namespace TetrisSharp
{
    public class Game
    {
        private readonly IGameVizualizator _gameVizualizator;

        //[height, width]
        private bool[,] _board;
        private int _score;

        public Game(IGameVizualizator gameVizualizator)
        {
            _gameVizualizator = gameVizualizator;

            Init();
        }

        private void Init()
        {
            var boadrWidth = 10; var boadrHeight = 24;

            _board = new bool[boadrHeight, boadrWidth];

            _score = 0;

            _gameVizualizator.RedrawBoard(_board);
        }


    }
}
