using System;

namespace Figures
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"Point: X: {X:F3}, Y: {Y:F3}";
        }

        public virtual double Area { get => 0; }
        
        public virtual double Len { get => 0; }
    }
}
