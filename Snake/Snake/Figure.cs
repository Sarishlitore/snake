﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Figure
    {
        protected List<Point> pList;

        public void Draw()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }

        internal bool IsHit(Figure figure)
        {
            foreach (Point p in pList)
            {
                if (figure.IsHit(p)) return true;
            }
            return false;
        }

        private bool IsHit(Point p)
        {
            foreach (Point i in pList)
            {
                if (p.x == i.x && p.y == i.y) return true;
            }
            return false;
        }
    }
}