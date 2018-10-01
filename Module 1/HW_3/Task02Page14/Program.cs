using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
            Написать метод, вычисляющий значение функции G = F(X, Y)
            G = X + sin(Y), X < Y и X > 0
            G = Y - cos(X), X > Y и X < 0
            G = 0.5 * X * Y, в остальных случаях.
*/

namespace Task02Page14
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
        /// Finds value of function G(x, y).
        /// </summary>
        /// <returns>Value of function.</returns>
        /// <param name="x">Real number x.</param>
        /// <param name="y">Real number y.</param>
        static double G(double x, double y)
        {
            if ((x < y) && (x > 0))
                return x + Math.Sin(y);
            if ((x > y) && (x < 0))
                return y - Math.Cos(x);
            return 0.5 * x * y;
        }

        static void Main()
        {
            do
            {
                Console.Clear();

                double x = InputDouble("real number x");
                double y = InputDouble("real number y");

                Console.WriteLine($"G({x}, {y}) = {G(x, y):0.###}");

                Console.WriteLine("Press ESC to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
