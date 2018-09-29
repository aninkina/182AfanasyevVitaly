using System;

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
        
        
        static void PrintYearBudget(int year, double budget)
		{
			Console.WriteLine($"{year}\t|\t{budget:0.###}");
		}

        /// <summary>
        /// Finds total budget ...
        /// </summary>
        /// <returns>The total.</returns>
        /// <param name="startBudget">Start budget.</param>
        /// <param name="percent">Percent.</param>
        /// <param name="years">Years.</param>
        static double Total(double startBudget, double percent, int years)
		{
			Console.WriteLine("Year\t|\tBudget");
			Console.WriteLine("------------------------");
			Console.WriteLine($"0\t|\t{startBudget}");
			double tmpBudget = startBudget;
			for (int i = 1; i <= years; i++)
			{
				tmpBudget = tmpBudget * (double)(1.0 + percent / 100.0);
				PrintYearBudget(i, tmpBudget);
			}
			return tmpBudget;
		}

        static void Main()
        {
            do
            {
                Console.Clear();

				double startBudget = InputDouble("start budget", 0, double.MaxValue, (x, y) => x <= y, (x, y) => x > y);
				double percent = InputDouble("year percentage", 0, 100, (x, y) => x < y, (x, y) => x > y);
				int years = InputInt("amount of years", 0, int.MaxValue, (x, y) => x <= y, (x, y) => x > y );
                
				double result = Total(startBudget, percent, years);

				Console.WriteLine($"Total budget: {result:0.###}");

                Console.WriteLine("Press ESC to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
