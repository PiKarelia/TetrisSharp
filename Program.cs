using System;
using TetrisSharp.ConsoleVizualization;

namespace TetrisSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(60,40);

            //TODO: Add injection of these instead
            IGameVizualizator vizualizator = new ConsoleVizualizator();

            new Game(vizualizator);

            Console.ReadLine();
        }
    }
}
