using System;
using System.Linq;

namespace Task05
{
    public class Interval
    {
        public double Left { get; set; }
        public double Right { get; set; }
        
        public Interval(double left, double right)
        {
            if (right < left)
            {
                Left = right;
                Right = left;
            }
            else
            {
                Left = left;
                Right = right;
            }
        }

        public Interval(Interval i)
        {
            Left = i.Left;
            Right = i.Right;
        }

        public double Length()
        {
            return Right - Left;
        }

        public static Interval operator +(Interval i1, Interval i2)
        {
            return new Interval(i1.Left + i2.Left, i1.Right + i2.Right);
        }
        
        public static Interval operator -(Interval i1, Interval i2)
        {
            return new Interval(i1.Left - i2.Left, i1.Right - i2.Right);
        }
        
        public static Interval operator *(Interval i1, Interval i2)
        {
            double[] arr = { i1.Left * i2.Left, i1.Left * i2.Right, i1.Right * i2.Left, i1.Right * i2.Right };
            return new Interval(arr.Min(), arr.Max());
        }
        
        public static Interval operator /(Interval i1, Interval i2)
        {
            double[] arr = { i1.Left / i2.Left, i1.Left / i2.Right, i1.Right / i2.Left, i1.Right / i2.Right };
            return new Interval(arr.Min(), arr.Max());
        }

        public override string ToString()
        {
            return $"[{Left:G3}; {Right:G3}]";
        }
    }
}
