using System;

namespace Figures
{
    public class Square : Point
    {
        public double Side { get; set; }

        public Square(double x, double y, double side): base(x, y)
        {
            Side = side;
        }

        public override string ToString()
        {
            return $"Square: X: {X:F3}, Y: {Y:F3}, Side: {Side:F3}";
        }

        public override double Area { get => Side * Side; }
        
        public override double Len { get => Side * 4; }
    }
}
