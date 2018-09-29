using System;

namespace Task04
{
	delegate bool Comp<T>(T x, T y);

    class Program
    {
		/// <summary>
        /// Inputs and parses the int.
        /// </summary>
        /// <returns>The int.</returns>
        /// <param name="input">Input.</param>
        /// <param name="minValue">Minimum value.</param>
        /// <param name="maxValue">Max value.</param>
        public static int InputInt(string input,
                            int minValue, int maxValue,
                            Comp<int> CompMin, Comp<int> CompMax)
        {
            Console.WriteLine($"Enter {input} :");
            int result;
            while (!int.TryParse(Console.ReadLine(), out result) || (result < minValue) || (result > maxValue))
            {
                Console.WriteLine("Invalid input format! Try again!");
                Console.WriteLine($"Enter {input} :");
            }
            return result;
        }

        public static int InputInt(string input)
        {
            return InputInt(input, int.MinValue, int.MaxValue, (x, y) => x < y, (x, y) => x > y);
        }

        /// <summary>
        /// Inputs and parses the double.
        /// </summary>
        /// <returns>The double.</returns>
        /// <param name="input">Input.</param>
        /// <param name="minValue">Minimum value.</param>
        /// <param name="maxValue">Max value.</param>
        public static double InputDouble(string input,
                                  double minValue, double maxValue,
                                  Comp<double> compMin, Comp<double> compMax)
        {
            Console.WriteLine($"Enter {input} :");
            double result;
            while (!double.TryParse(Console.ReadLine(), out result) || (compMin(result, minValue)) || (compMax(result, maxValue)))
            {
                Console.WriteLine("Invalid input format! Try again!");
                Console.WriteLine($"Enter {input} :");
            }
            return result;
        }

        public static double InputDouble(string input)
        {
            return InputDouble(input, double.MinValue, double.MaxValue, (x, y) => x < y, (x, y) => x > y);
        }
        
        
        /// <summary>
        /// Calculates square root of X
        /// </summary>
        /// <returns>The newton.</returns>
        /// <param name="x">Number X.</param>
        /// <param name="result">Result.</param>
        /// <param name="eps">Eps.</param>
        static bool Newton(double x, out double result, out double eps)
		{
			double k1, k2 = x;
			result = eps = 0;
			if (x < 0)
				return false;
			do
			{
				k1 = k2;
				eps = (x / k1 - k1) / 2;
				k2 += eps;
			} while (k1 != k2);
			result = k1;
			return true;
		}

        static void Main()
        {
			do
			{
				Console.Clear();

				double num = InputDouble("sub radical expression");
				double result, eps;
    
				if (!Newton(num, out result, out eps))
					Console.WriteLine("Error! Negative sub radical expression!");
				else
					Console.WriteLine($"Square root of {num} = {result:G4}, eps = {eps:e3}");

				Console.WriteLine("Press ESC to exit. Press any other key to continue.");
			} while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
