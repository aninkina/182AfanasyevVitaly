using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
            
*/

namespace Task05
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
        
        
        static void ShowPartSum(int k, double sum)
        {
			Console.WriteLine($"{k, -5} {sum, 5:F3}");
        }
        
        /// <summary>
        /// Calculates the specified sum from 1 to K.
        /// </summary>
        /// <returns>The sum.</returns>
        /// <param name="k">K.</param>
        static double CalculateSum(uint k)
        {
			double sum = 0;
			Console.WriteLine("{0, -5} {1, 5}", "K", "Sum");
			Console.WriteLine();
			for (int i = 1; i <= k; i++)
            {
				sum += (k + 0.3) / (3 * k * k + 5);
				ShowPartSum(i, sum);
            }
			return sum;
        }
        
        static void Main()
        {
            do
            {
                Console.Clear();

				uint k = InputUInt("positive integer k");

				CalculateSum(k);
                
                Console.WriteLine("Press ESC to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}