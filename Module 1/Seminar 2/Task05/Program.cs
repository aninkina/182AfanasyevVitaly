using System;

namespace Task05
{
    class Program
    {
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
                int number = InputInt("three-digit integer", 100, 999);
                int firstDigit = number / 100, secondDigit = number / 10 % 10, thirdDigit = number % 10;
                Console.WriteLine("{0}\n{1}\n{2}", firstDigit, secondDigit, thirdDigit);
                Console.WriteLine("Press ESC to exit. Press any other key to continue");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
