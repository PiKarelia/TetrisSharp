using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using TetrisSharp.GameCore.Figures;

namespace TetrisSharp
{
    public class Game : IDisposable
    {
        private readonly IGameVizualizator _gameVizualizator;

        private int _boadrWidth = 10;
        private int _boardHeight = 24;
        private int _fallingSpeed = 600;

        private IFigure _currentFigure;

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

        public void RedrawBoard()
        {
            _gameVizualizator.RedrawBoard(_board);
        }

        private void Start()
        {
            _currentFigure = GenerateAFigure();
            _timer.Start();

            SetFigureOnTheBoard();

            RedrawBoard();

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

        private void SetFigureOnTheBoard()
        {
            for (int i = 0; i < _currentFigure.PointsOfFigure.Length; i++)
            {
                _currentFigure.PointsOfFigure[i].X += _boadrWidth / 2;
                _currentFigure.PointsOfFigure[i].Y += 2;

            }
            for (int i = 0; i < _currentFigure.PointsOfFigure.Length; i++)
            {
                _board[_currentFigure.PointsOfFigure[i].Y, _currentFigure.PointsOfFigure[i].X] = true;
            }
        }

        private bool CanGoOneStepDown()
        {
            try
            {
                for (int i = 0; i < _currentFigure.PointsOfFigure.Length; i++)
                {
                    if (// board has true 
                        _board[_currentFigure.PointsOfFigure[i].Y + 1, _currentFigure.PointsOfFigure[i].X]
                        &&
                        //and it's not the piece itself
                        !_currentFigure.PointsOfFigure
                        .Any(x => x.Y == _currentFigure.PointsOfFigure[i].Y + 1 && x.X == _currentFigure.PointsOfFigure[i].X)
                        )
                    {
                        return false;
                    }
                }
            }
            catch (Exception) { return false; }

            return true;
        }

        private void OneStepDown()
        {
            if (!CanGoOneStepDown())
            {
                NextFigure();
            }

            for (int i = 0; i < _currentFigure.PointsOfFigure.Length; i++)
            {
                _board[_currentFigure.PointsOfFigure[i].Y, _currentFigure.PointsOfFigure[i].X] = false;
            }
            for (int i = 0; i < _currentFigure.PointsOfFigure.Length; i++)
            {
                _currentFigure.PointsOfFigure[i].Y += 1;
            }

            for (int i = 0; i < _currentFigure.PointsOfFigure.Length; i++)
            {
                _board[_currentFigure.PointsOfFigure[i].Y, _currentFigure.PointsOfFigure[i].X] = true;
            }
            RedrawBoard();
        }

        private void AllStepsDown()
        {
            while (CanGoOneStepDown())
            {
                for (int i = 0; i < _currentFigure.PointsOfFigure.Length; i++)
                {
                    _board[_currentFigure.PointsOfFigure[i].Y, _currentFigure.PointsOfFigure[i].X] = false;
                }
                for (int i = 0; i < _currentFigure.PointsOfFigure.Length; i++)
                {
                    _currentFigure.PointsOfFigure[i].Y += 1;
                }

                for (int i = 0; i < _currentFigure.PointsOfFigure.Length; i++)
                {
                    _board[_currentFigure.PointsOfFigure[i].Y, _currentFigure.PointsOfFigure[i].X] = true;
                }
            }
            RedrawBoard();

        }

        private void OneStepLeft()
        {
            if (!CanGoOneStepLeft()) return;

            for (int i = 0; i < _currentFigure.PointsOfFigure.Length; i++)
            {
                _board[_currentFigure.PointsOfFigure[i].Y, _currentFigure.PointsOfFigure[i].X] = false;
            }

            for (int i = 0; i < _currentFigure.PointsOfFigure.Length; i++)
            {
                _currentFigure.PointsOfFigure[i].X -= 1;
            }

            for (int i = 0; i < _currentFigure.PointsOfFigure.Length; i++)
            {
                _board[_currentFigure.PointsOfFigure[i].Y, _currentFigure.PointsOfFigure[i].X] = true;
            }
            RedrawBoard();
        }

        private void OneStepRight()
        {
            if (!CanGoOneStepRight()) return;

            for (int i = 0; i < _currentFigure.PointsOfFigure.Length; i++)
            {
                _board[_currentFigure.PointsOfFigure[i].Y, _currentFigure.PointsOfFigure[i].X] = false;
            }

            for (int i = 0; i < _currentFigure.PointsOfFigure.Length; i++)
            {
                _currentFigure.PointsOfFigure[i].X += 1;
            }

            for (int i = 0; i < _currentFigure.PointsOfFigure.Length; i++)
            {
                _board[_currentFigure.PointsOfFigure[i].Y, _currentFigure.PointsOfFigure[i].X] = true;
            }
            RedrawBoard();
        }

        private bool CanGoOneStepLeft()
        {
            try
            {
                for (int i = 0; i < _currentFigure.PointsOfFigure.Length; i++)
                {
                    if (// board has true 
                        _board[_currentFigure.PointsOfFigure[i].Y, _currentFigure.PointsOfFigure[i].X - 1]
                        &&
                        //and it's not the piece itself
                        !_currentFigure.PointsOfFigure.Any(x => x.X == _currentFigure.PointsOfFigure[i].X - 1)
                        )
                    {
                        return false;
                    }
                }
            }
            catch (Exception) { return false; }

            return true;
        }

        private bool CanGoOneStepRight()
        {
            try
            {
                for (int i = 0; i < _currentFigure.PointsOfFigure.Length; i++)
                {
                    if (// board has true 
                        _board[_currentFigure.PointsOfFigure[i].Y, _currentFigure.PointsOfFigure[i].X + 1]
                        &&
                        //and it's not the piece itself
                        !_currentFigure.PointsOfFigure.Any(x => x.X == _currentFigure.PointsOfFigure[i].X + 1)
                        )
                    {
                        return false;
                    }
                }
            }
            catch (Exception) { return false; }

            return true;
        }

        private void RotateFigure()
        {
            for (int i = 0; i < _currentFigure.PointsOfFigure.Length; i++)
            {
                _board[_currentFigure.PointsOfFigure[i].Y, _currentFigure.PointsOfFigure[i].X] = false;
            }

            _currentFigure.Rotate();

            for (int i = 0; i < _currentFigure.PointsOfFigure.Length; i++)
            {
                _board[_currentFigure.PointsOfFigure[i].Y, _currentFigure.PointsOfFigure[i].X] = true;
            }

            RedrawBoard();
        }

        private void NextFigure()
        {
            _currentFigure = GenerateAFigure();

            RemoveFullLines();

            SetFigureOnTheBoard();

            if (IsGameOver())
            {
                _timer.Stop();
                Console.SetCursorPosition(10, 10);
                Console.WriteLine("GameOver");
            }
        }

        private void RemoveFullLines()
        {
            var numberOfLines = 0;

            for (var i = _board.GetLength(0) - 1; i > 0; i--)
            {
                var isFilled = true;
                for (var j = 0; j < _board.GetLength(1); j++)
                {
                    if (_board[i, j] == false)
                    {
                        isFilled = false;
                    }
                }
                if (isFilled)
                {
                    numberOfLines++;
                    SpliceBoardRow(i);
                }
            }
            _score += numberOfLines * numberOfLines;

            _gameVizualizator.DrawScore(_score);
        }

        private void SpliceBoardRow(int row)
        {
            for (var i = row; i > 0; i--)
            {
                for (var j = 0; j < _board.GetLength(1); j++)
                    _board[i, j] = _board[i - 1, j];
            }
        }

        private void KeyPressed(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow: OneStepLeft(); break;
                case ConsoleKey.RightArrow: OneStepRight(); break;
                case ConsoleKey.DownArrow: OneStepDown(); break;
                case ConsoleKey.UpArrow: RotateFigure(); break;
                case ConsoleKey.Spacebar: AllStepsDown(); break;
            }
        }

        private bool IsGameOver()
        {
            for (var i = 0; i <= 4; i++)
            {
                for (var j = 0; j < _board.GetLength(1); j++)
                {
                    if (_board[i, j]) return true;
                }
            }

            return false;
        }

        private void Init()
        {
            _board = new bool[_boardHeight, _boadrWidth];

            _score = 0;

            RedrawBoard();


            _timer = new Timer(_fallingSpeed);

            _timer.Elapsed += (sender, e) => OneStepDown();
        }

        private IFigure GenerateAFigure()
        {
            return new PyramidFigure();
        }

        public void Dispose()
        {
            _timer.Dispose();
        }

        public void PrintBoard()
        {
            for (int i = 0; i < _boardHeight; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < _boadrWidth; j++)
                {
                    Console.Write(_board[i, j] + "\t");
                }
            }
        }
    }
}
