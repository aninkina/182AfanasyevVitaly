using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
            
*/

namespace Task06
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
        /// Inputs and parses the char.
        /// </summary>
        /// <returns>The char.</returns>
        public static char InputChar()
        {
            Console.WriteLine("Enter symbol:");
            char c;
            while (!char.TryParse(Console.ReadLine(), out c))
            {
                Console.WriteLine("Invalid input format! Try again!");
                Console.WriteLine("Enter symbol:");
            }
            return c;
        }
        
        /// <summary>
        /// Inputs and parses the uint.
        /// </summary>
        /// <returns>The uint.</returns>
        /// <param name="input">Input.</param>
        /// <param name="minValue">Minimum value.</param>
        /// <param name="maxValue">Max value.</param>
        public static uint InputUInt(string input,
                            uint minValue, uint maxValue,
                            Comp<uint> CompMin, Comp<uint> CompMax)
        {
            Console.WriteLine($"Enter {input} :");
            uint result;
            while (!uint.TryParse(Console.ReadLine(), out result) || (result < minValue) || (result > maxValue))
            {
                Console.WriteLine("Invalid input format! Try again!");
                Console.WriteLine($"Enter {input} :");
            }
            return result;
        }

        public static uint InputUInt(string input)
        {
            return InputUInt(input, uint.MinValue, uint.MaxValue, (x, y) => x < y, (x, y) => x > y);
        }
        
        static void Swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }
        
        /// <summary>
        /// Calculates the first specified sum.
        /// </summary>
        /// <returns>The sum.</returns>
        /// <param name="x">Real number x.</param>
        static double CalculateSum1(double x)
        {
			double sum1 = 0, sum2 = 0, eps = 0, powX = x * x;
			double fact = 2, pow = 2, factCount = 2, sign = 1;
			do
			{
				sum1 = sum2;
				eps = sign * pow * powX / fact;
				sign *= -1;
				fact = fact * (factCount + 1) * (factCount + 2);
				factCount += 2;
				pow *= 4;
				powX *= x * x;
				sum2 = sum1 + eps;
			} while (sum1 != sum2);
			return sum1;
        }
        
        /// <summary>
        /// Calculates the second specified sum.
        /// </summary>
        /// <returns>The sum.</returns>
        /// <param name="x">Real number x.</param>
        static double CalculateSum2(double x)
        {
            double sum1 = 1, sum2 = 1, eps = 0, powX = x;
			double fact = 1, factCount = 1;
            do
            {
                sum1 = sum2;
                eps = powX / fact;
                fact *= (factCount + 1);
				factCount++;
                powX *= x;
                sum2 = sum1 + eps;
            } while (sum1 != sum2);
            return sum1;
        }
        
        static void Main()
        {
            do
            {
                Console.Clear();

				double x1 = InputDouble("real number X1", double.MinValue, 31, (a, b) => a < b, (a, b) => a > b);

				Console.WriteLine($"First sum: {CalculateSum1(x1):F3}");
                
                double x2 = InputDouble("real number X2", double.MinValue, 78, (a, b) => a < b, (a, b) => a > b);
                
                Console.WriteLine($"Second sum: {CalculateSum2(x2):F3}");
                
                Console.WriteLine("Press ESC to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}