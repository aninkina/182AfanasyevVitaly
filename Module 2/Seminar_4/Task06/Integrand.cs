using System;

namespace Task06
{
    abstract public class Integrand
    {
        public double LeftBound { get; set; }
        public double RightBound { get; set; }

        public abstract double Function(double x);
    }
}
