using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
           Получить от пользователя три вещественных числа и проверить для них неравенство треугольника. 
           Оператор if не применять.
*/

namespace Task05
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

        static string CheckTriangle(double a, double b, double c)
        {
            return (a + b >= c) && (a + c >= b) && (b + c >= a) ?
                    $"This triangle exists" :
                    $"This triangle doesn\'t exist";
        }

        static void Main()
        {
            do
            {
                double a = InputDouble("length of the first side of triangle");
                double b = InputDouble("length of the second side of triangle");
                double c = InputDouble("length of the third side of triangle");
                string result = CheckTriangle(a, b, c);
                Console.WriteLine(result);
                Console.WriteLine("Press ESC to exit. Press any other key to continue");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
