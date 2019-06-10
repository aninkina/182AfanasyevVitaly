using System;

namespace Task01
{
    public class Point<T>
    {
        public dynamic X { get; set; }
        public dynamic Y { get; set; }
        
        public Point(T x, T y)
        {
            X = x;
            Y = y;
        }

        public dynamic Distance { get => Math.Sqrt(X * X + Y * Y); }

        public override string ToString()
        {
            return $"({X: F3}; {Y: F3})";
        }
    }
}
