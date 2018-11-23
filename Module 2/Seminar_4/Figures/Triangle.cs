using System;

namespace Figures
{
    public class Triangle : Point
    {
        public double Side { get; set; }

        public Triangle(double x, double y, double side): base(x, y)
        {
            Side = side;
        }

        public override string ToString()
        {
            return $"Triangle: X: {X:F3}, Y: {Y:F3}, Side: {Side:F3}";
        }

        public override double Area { get => Side * Side * Math.Sqrt(3) / 4; }
        
        public override double Len { get => Side * 3; }
    }
}
