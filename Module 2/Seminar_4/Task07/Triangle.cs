using System;
using Figures;

namespace Task07
{
    public class Triangle : Dimensions
    {
        public Triangle(double x, double y) : base(x, y) { }

        public override string ToString()
        {
            return $"Triangle: X: {X:F3}, Y: {Y:F3}, Area: {Area:F3}";
        }

        public override double Area { get => X * Y / 2; }
        
        public override string Record { get => $"Triangle {X:F3} {Y:F3}"; }
    }
}
