using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
           Ввести значение x и вывести значение полинома: 
           F(x) = 12x^4 + 9x^3 - 3x^2 +  2x – 4. 
           Не применять возведение в степень. 
           Использовать минимальное  количество операций умножения.
*/

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
                double x = InputDouble("real number X");
                Console.WriteLine($"F(X) = {F(x):G3}");
                Console.WriteLine("Press ESC to exit. Press any other key to continue");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
