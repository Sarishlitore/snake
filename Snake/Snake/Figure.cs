using System.Collections.Generic;
using System.Linq;

namespace Snake
{
    internal class Figure
    {
        protected List<Point> PList;
        public void Draw()
        {
            foreach (var p in PList)
            {
                p.Draw();
            }
        }
        internal bool IsHit(Figure figure)
        {
            return PList.Any(figure.IsHit);
        }
        private bool IsHit(Point p)
        {
            return PList.Any(i => p.X == i.X && p.Y == i.Y);
        }
    }
}
