using System;
using System.Collections.Generic;

namespace Task02
{
    public class Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public double Mod
        {
            get { return Math.Sqrt(X * X + Y * Y); }
        }
        public bool Equals(Point other)
        {
            if (X == other.X & Y == other.Y)
                return true;
            else
                return false;
        }
        public override string ToString()
        {
            return String.Format("x = {0}, y = {1}, mod = {2:G5}", X, Y, Mod);
        }
    }
}
