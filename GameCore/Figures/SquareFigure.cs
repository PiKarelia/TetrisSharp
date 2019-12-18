using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TetrisSharp.GameCore.Figures
{
    public class SquareFigure : IFigure
    {
        public SquareFigure()
        {
            GenerateFigure();
        }

        public Point[] PointsOfFigure { get; set; }

        public void Rotate() { }

        private void GenerateFigure()
        {
            PointsOfFigure = new Point[]
            {
                new Point(0,0),
                new Point(1,0),
                new Point(1,1),
                new Point(0,1)
            };
        }
    }
}
