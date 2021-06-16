using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake
{
    internal class Snake : Figure
    {
        private int _snakeSpeed;
        private Direction _direction;
        public Snake(Point tail, int length, Direction direction, int snakeSpeed)
        {
            _direction = direction;
            _snakeSpeed = snakeSpeed;
            PList = new List<Point>();
            for (var i = 0; i < length; i++)
            {
                var p = new Point(tail);
                p.Move(i, _direction);
                PList.Add(p);
            }
        }
        internal void Move()
        {
            var tail = PList.First();
            PList.Remove(tail);
            var head = GetNextPoint();
            PList.Add(head);
            tail.Clear();
            head.Draw();
        }
        internal bool IsHitTail()
        {
            var head = PList.Last();
            for (var i = 0; i < PList.Count - 2; i++)
            {
                if (head.IsHit(PList[i])) return true;
            }
            return false;
        }
        private Point GetNextPoint()
        {
            var head = PList.Last();
            var nextPoint = new Point(head);
            nextPoint.Move(1, _direction);
            return nextPoint;
        }
        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow && _direction != Direction.Right) _direction = Direction.Left;
            else if (key == ConsoleKey.RightArrow && _direction != Direction.Left) _direction = Direction.Right;
            else if (key == ConsoleKey.UpArrow && _direction != Direction.Down) _direction = Direction.Up;
            else if (key == ConsoleKey.DownArrow && _direction != Direction.Up) _direction = Direction.Down;
        }
        internal bool Eat(Point food)
        {
            var head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.Sym = head.Sym;
                food.Draw();
                PList.Add(food);
                _snakeSpeed = Math.Max(_snakeSpeed--, 10);
                return true;
            }
            else return false;
        }
    }
}
