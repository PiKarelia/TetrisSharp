using System;
using TetrisSharp.ConsoleVizualization;

namespace TetrisSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize( 60,50);

            //TODO: Add injection of IGameVizualizator instead
            IGameVizualizator vizualizator = new ConsoleVizualizator();

            new Game(vizualizator);

            Console.ReadLine();
        }
    }
}
