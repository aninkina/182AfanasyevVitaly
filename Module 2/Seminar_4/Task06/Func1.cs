using System;

namespace Task06
{
    public class Func1 : Integrand
    {
        public Func1(double leftBound, double rightBound)
        {
            LeftBound = leftBound;
            RightBound = rightBound;
        }

        public override double Function(double x)
        {
            return x / Math.Pow(x * x + 1, 2);
        }
    }
}
