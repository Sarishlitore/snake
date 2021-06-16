using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake
{
    internal class Snake : Figure
    {
        private Direction _direction;

        public Snake(Point tail, int length, Direction direction)
        {
            _direction = direction;
            pList = new List<Point>();
            for (var i = 0; i < length; i++)
            {
                var p = new Point(tail);
                p.Move(i, _direction);
                pList.Add(p);
            }
        }

        internal void Move()
        {
            var tail = pList.First();
            pList.Remove(tail);
            var head = GetNextPoint();
            pList.Add(head);
            tail.Clear();
            head.Draw();
        }

        internal bool IsHitTail()
        {
            var head = pList.Last();
            for (var i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i])) return true;
            }
            return false;
        }

        private Point GetNextPoint()
        {
            var head = pList.Last();
            var nextPoint = new Point(head);
            nextPoint.Move(1, _direction);
            return nextPoint;
        }

        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow && _direction != Direction.RIGHT) _direction = Direction.LEFT;
            else if (key == ConsoleKey.RightArrow && _direction != Direction.LEFT) _direction = Direction.RIGHT;
            else if (key == ConsoleKey.UpArrow && _direction != Direction.DOWN) _direction = Direction.UP;
            else if (key == ConsoleKey.DownArrow && _direction != Direction.UP) _direction = Direction.DOWN;
        }

        internal bool Eat(Point food)
        {
            var head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.sym = head.sym;
                food.Draw();
                pList.Add(food);
                return true;
            }
            else return false;
        }
    }
}
