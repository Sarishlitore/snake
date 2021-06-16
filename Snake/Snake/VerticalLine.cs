using System.Collections.Generic;

namespace Snake
{
    internal class VerticalLine : Figure
    {
        public VerticalLine(int yUp, int yDown, int x, char sym)
        {
            PList = new List<Point>();
            for (var y = yUp; y <= yDown; y++)
            {
                var p = new Point(x, y, sym);
                PList.Add(p);
            }
        }
    }
}
