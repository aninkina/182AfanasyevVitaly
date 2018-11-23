using System;
using Figures;

namespace Task08
{
    public class Ellipse : Dimensions
    {
        public Ellipse(double x, double y) : base(x, y) { }

        public override string ToString()
        {
            return $"Ellipse: X: {X:F3}, Y: {Y:F3}, Area: {Area:F3}";
        }

        public override double Area { get => Math.PI * X * Y / 4; }

        public override string Record { get => $"Ellipse {X:F3} {Y:F3}"; }
    }
}
