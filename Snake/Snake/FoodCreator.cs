using System;

namespace Snake
{
    internal class FoodCreator
    {
        private readonly int _mapWidth;
        private readonly int _mapHeight;
        private readonly char _sym;
        private readonly Random _random = new Random();

        public FoodCreator(int mapWidth, int mapHeight, char sym)
        {
            this._mapWidth = mapWidth;
            this._mapHeight = mapHeight;
            this._sym = sym;
        }

        public Point CreateFood()
        {
            var x = _random.Next(2, _mapWidth - 2);
            var y = _random.Next(2, _mapHeight - 2);
            return new Point(x, y, _sym);
        }
    }
}
