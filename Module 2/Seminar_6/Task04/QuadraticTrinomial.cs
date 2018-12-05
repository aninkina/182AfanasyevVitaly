using System;

namespace Task04
{
    public class QuadraticTrinomial
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public QuadraticTrinomial(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }
        
        /// <summary>
        /// Calculates the value of trinomial in point X.
        /// </summary>
        /// <returns>Value.</returns>
        /// <param name="x">X.</param>
        public double Calculate(double x)
        {
            return A * x * x + B * x + C;
        }

        /// <summary>
        /// Divides the trinomial on another trinomial and finds value in point X.
        /// </summary>
        /// <returns>Value.</returns>
        /// <param name="x">X.</param>
        /// <param name="tr">Second trinomial.</param>
        public double Divide(double x, QuadraticTrinomial tr)
        {
            double arg1 = Calculate(x), arg2 = tr.Calculate(x);
            if (arg2 == 0)
                throw new DivideByZeroException();
            return arg1 / arg2;
        }
    }
}
