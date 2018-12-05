using System;

namespace Task02
{
    public class GeomProgr
    {
        public static uint objectNumber = 0;
        double _b, _q;
        
        public double B
        {
            get => _b;
            set
            {
                if (value == 0)
                    throw new ArgumentException("Field _b can't be equal to zero.");
                _b = value;
            }
        }
        
        public double Q
        {
            get => _q;
            set
            {
                if (value == 0)
                    throw new ArgumentException("Field _q can't be equal to zero.");
                _q = value;
            }
        }

        public GeomProgr() : this(1, 1) { }

        public GeomProgr(double b, double q)
        {   
            try
            {
                B = b;
                Q = q;
                objectNumber++;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        /// <summary>
        /// Finds the i-th element of geometric progression.
        /// </summary>
        /// <param name="i">The index.</param>
        public double this[int i]
        {
            get
            {
                if (i < 1)
                    throw new ArgumentException("Number of element can't be neagtive or equal to zero.");
                double elem = B * Math.Pow(Q, i - 1);
                if (double.IsPositiveInfinity(elem))
                    throw new ArgumentException("Too big number.");
                return elem;
            }
        }

        /// <summary>
        /// Finds sum of i elements of geometric progression.
        /// </summary>
        /// <returns>The sum.</returns>
        /// <param name="i">Number of elements.</param>
        public double Sum(int i)
        {
            if (i < 1)
                throw new ArgumentException("Number of elements can't be neagtive or equal to zero.");
            if (Q == 1)
                return B * i;
            double sum = B * (Math.Pow(Q, i) - 1) / (Q - 1);
            if (double.IsPositiveInfinity(sum))
                throw new ArgumentException("Too big number.");
            return sum;
        }
    }
}
