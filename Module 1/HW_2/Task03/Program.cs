using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
            Введя значения коэффициентов А, В, С, вычислить корни квадратного  уравнения. 
            Учесть (как хотите) возможность появления комплексных корней. 
            Оператор if не применять.
*/

namespace Task03
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

        static string SolveQuadratic(double a, double b, double c)
        {
            double D = checked(b * b - 4 * a * c);
            return D < 0 ? "Solution is in complex numbers" : 
                a == 0 ? (b == 0) ? (c != 0) ? "No solutions" : "Infinite solutions" : $"One solution X = {-c / b}" :
                D == 0 ? $"One solution. X = {-b / (2 * a):F3}" :
                $"Two solutions. X1 = {(-b + Math.Sqrt(D)) / (2 * a):F3}, X2 = {(-b - Math.Sqrt(D)) / (2 * a):F3}";
        }

        static void Main()
        {
            do
            {
                double a = InputDouble("coefficient A of quadratic equation ax^2 + bx + c = 0");
                double b = InputDouble("coefficient B of quadratic equation ax^2 + bx + c = 0");
                double c = InputDouble("coefficient C of quadratic equation ax^2 + bx + c = 0");
                string solution = SolveQuadratic(a, b, c);
                Console.WriteLine(solution);
                Console.WriteLine("Press ESC to exit. Press any other key to continue");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
