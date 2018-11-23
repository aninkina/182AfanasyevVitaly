using System;

namespace Figures
{
    public abstract class Dimensions
    {
        protected double X { get; set; }
        protected double Y { get; set; }

        public Dimensions(double x, double y)
        {
            X = x;
            Y = y;
        }

        public abstract override string ToString();

        public void MultiplyDimensions(double k)
        {
            X *= k;
            Y *= k;
        }

        public abstract double Area { get; }

        public abstract string Record { get; }
    }
}
