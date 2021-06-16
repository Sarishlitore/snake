using System.Collections.Generic;
using System.Linq;

namespace Snake
{
    internal class Wall
    {
        private readonly List<Figure> _wallList = new List<Figure>();
        public Wall(int mapWidth, int mapHeight, char symWall)
        {
            var upLine = new HorizontalLine(0, mapWidth - 2, 0, symWall);
            var downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '+');
            var leftLine = new VerticalLine(0, mapHeight - 1, 0, symWall);
            var rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '+');
            _wallList.Add(upLine);
            _wallList.Add(downLine);
            _wallList.Add(leftLine);
            _wallList.Add(rightLine);
        }
        internal bool IsHit(Figure figure)
        {
            return _wallList.Any(wall => wall.IsHit(figure));
        }
        public void Draw()
        {
            foreach (var f in _wallList)
            {
                f.Draw();
            }
        }
    }
}
