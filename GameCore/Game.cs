using System;
using System.Collections.Generic;
using System.Timers;

namespace TetrisSharp
{
    public class Game
    {
        private readonly IGameVizualizator _gameVizualizator;

        //[height, width]
        private bool[,] _board;
        private int _score;

        private Timer _timer;

        public Game(IGameVizualizator gameVizualizator)
        {
            _gameVizualizator = gameVizualizator;

            Init();

            Start();

        }

        private void Start()
        {

            var key = Console.ReadKey();
            while (key.Key != ConsoleKey.Escape)
            {
                KeyPressed(key.Key);
                key = Console.ReadKey();
            }

            //while (IsNotGameOver())
            //{

            //}
        }

        private void KeyPressed(ConsoleKey key)
        {
            Console.Write(key.ToString());
        }

        private bool IsNotGameOver()
        {
            // TODO: implement
            return true;
        }

        private void Init()
        {
            var boadrWidth = 10; var boadrHeight = 24;

            _board = new bool[boadrHeight, boadrWidth];

            _score = 0;

            _gameVizualizator.RedrawBoard(_board);


            _timer = new Timer(5000);

            _timer.Elapsed += (sender, e) => StepExpired();
        }

        private void StepExpired()
        {
            Console.WriteLine("next step please");
        }
    }
}
