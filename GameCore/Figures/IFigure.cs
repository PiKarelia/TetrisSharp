using System;
using System.Collections.Generic;
using System.Drawing;

namespace TetrisSharp.GameCore.Figures
{
    public interface IFigure
    {
        Point[] PointsOfFigure { get; set; }

        void Rotate();
    }
}
