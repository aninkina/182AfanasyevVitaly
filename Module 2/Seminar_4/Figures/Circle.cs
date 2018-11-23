using System;

namespace Figures
{
    public class Circle : Point
    {
        public double Rad { get; set; }

        public Circle(double x, double y, double rad) : base(x, y)
        {
            Rad = rad;
        }

        public override string ToString()
        {
            return $"Circle: X: {X:F3}, Y: {Y:F3}, Radius: {Rad:F3}";
        }

        public override double Area { get => Math.PI * Math.Pow(Rad, 2); }
        
        public override double Len { get => 2 * Math.PI * Rad; }
    }
}
