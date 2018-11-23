using System;

namespace Task06
{
    public class Func2 : Integrand
    {
        public Func2(double leftBound, double rightBound)
        {
            LeftBound = leftBound;
            RightBound = rightBound;
        }

        public override double Function(double x)
        {
            return 4 * Math.Cos(x) * Math.Cos(x);
        }
    }
}
