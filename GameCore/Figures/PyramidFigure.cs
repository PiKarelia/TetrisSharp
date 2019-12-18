using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TetrisSharp.GameCore.Figures
{
    public class PyramidFigure : IFigure
    {
        public PyramidFigure()
        {
            GenerateFigure();
        }

        public Point[] PointsOfFigure { get; set; }

        public void Rotate()
        {
            if (!PointsOfFigure.Skip(1).Any(x => x.X == PointsOfFigure[0].X
                && x.Y == PointsOfFigure[0].Y + 1))
            {
                for (int i = 1; i < 4; i++)
                {
                    if (PointsOfFigure[i].X == PointsOfFigure[0].X - 1
                    && PointsOfFigure[i].Y == PointsOfFigure[0].Y)
                    {
                        PointsOfFigure[i].X += 1;
                        PointsOfFigure[i].Y += 1;
                    }
                }
            }
            else if (!PointsOfFigure.Skip(1).Any(x => x.X == PointsOfFigure[0].X - 1
              && x.Y == PointsOfFigure[0].Y))
            {
                for (int i = 1; i < 4; i++)
                {
                    if (PointsOfFigure[i].X == PointsOfFigure[0].X
                    && PointsOfFigure[i].Y == PointsOfFigure[0].Y - 1)
                    {
                        PointsOfFigure[i].X -= 1;
                        PointsOfFigure[i].Y += 1;
                    }
                }
            }
            else if (!PointsOfFigure.Skip(1).Any(x => x.X == PointsOfFigure[0].X
              && x.Y == PointsOfFigure[0].Y - 1))
            {
                for (int i = 1; i < 4; i++)
                {
                    if (PointsOfFigure[i].X == PointsOfFigure[0].X+1
                    && PointsOfFigure[i].Y == PointsOfFigure[0].Y )
                    {
                        PointsOfFigure[i].X -= 1;
                        PointsOfFigure[i].Y -= 1;
                    }
                }
            }
            else if(!PointsOfFigure.Skip(1).Any(x => x.X == PointsOfFigure[0].X+1
              && x.Y == PointsOfFigure[0].Y ))
            {
                for (int i = 1; i < 4; i++)
                {
                    if (PointsOfFigure[i].X == PointsOfFigure[0].X 
                    && PointsOfFigure[i].Y == PointsOfFigure[0].Y+1)
                    {
                        PointsOfFigure[i].X += 1;
                        PointsOfFigure[i].Y -= 1;
                    }
                }
            }
        }

        private void GenerateFigure()
        {
            PointsOfFigure = new Point[]
            {
                new Point(0,1),//center point
                new Point(0,0),
                new Point(-1,1),
                new Point(1,1)
            };
        }
    }
}
