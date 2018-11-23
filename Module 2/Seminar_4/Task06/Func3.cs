using System;

namespace Task06
{
    public class Func3 : Integrand
    {
        public Func3(double leftBound, double rightBound)
        {
            LeftBound = leftBound;
            RightBound = rightBound;
        }

        public override double Function(double x)
        {
            return Math.Cos(x * x * x);
        }
    }
}
