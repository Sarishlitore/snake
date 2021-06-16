using System.Collections.Generic;

namespace Snake
{
    internal class HorizontalLine : Figure
    {
        public HorizontalLine(int xLeft, int xRight, int y, char sym)
        {
            PList = new List<Point>();
            for (var x = xLeft; x <= xRight; x++)
            {
                var p = new Point(x, y, sym);
                PList.Add(p);
            }
        }
    }
}
