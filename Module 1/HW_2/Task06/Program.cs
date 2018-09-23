using System;

namespace Task06
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

        static int InputInt(string input, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            Console.WriteLine("Enter " + input + ": ");
            int result;
            while (!int.TryParse(Console.ReadLine(), out result) || (result < minValue) || (result > maxValue))
            {
                Console.WriteLine("Invalid input format! Try again");
            }
            return result;
        }


        static void Main()
        {
            do
            {
                double budget = InputDouble("your budget");
                int percent = InputInt("percentage of your budget for computer games (integer from 0 to 100)", 0, 100);
                double sum = (budget / 100.0) * percent;
                Console.WriteLine($"Money for computer games: {sum:C3}");
                Console.WriteLine("Press ESC to exit. Press any other key to continue");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
