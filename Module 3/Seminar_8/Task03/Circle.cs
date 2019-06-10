using System;

namespace Task03
{
    public class Circle : IFigure
    {
        public double Radius { get; set; }

        public double Area { get => Math.PI * Radius * Radius; }

        public Circle() : this(1) { }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override string ToString()
        {
            return $"Radius: {Radius:F3}";
        }
    }
}
