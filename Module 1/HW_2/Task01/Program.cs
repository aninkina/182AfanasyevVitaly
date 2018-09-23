using System;

namespace Task01
{
    class Program
    {
        static double InputDouble(string input, double minValue = double.MinValue, double maxValue = double.MaxValue)
        {
            Console.WriteLine("Enter " + input + ": ");
            double result;
            while (!double.TryParse(Console.ReadLine(), out result) || (result < minValue) || (result > maxValue))
            {
                Console.WriteLine("Invalid input format! Try again");
            }
            return result;
        }

        static double F(double x)
        {
            double x2 = x * x;
            double x3 = x2 * x;
            double x4 = x3 * x;
            return 12 * x4 + 9 * x3 - 3 * x2 + 2 * x - 4;
        }

        static void Main()
        {
            do
            {
                double x = InputDouble("X");
                Console.WriteLine($"F(X) = {F(x)}");
                Console.WriteLine("Press ESC to exit. Press any other key to continue");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
