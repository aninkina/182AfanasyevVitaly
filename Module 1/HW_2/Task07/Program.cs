using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
           Написать программу с использованием двух методов. Первый метод  возвращает дробную и целую часть числа.
           Второй метод возвращает квадрат и корень из числа. В основной программе пользователь вводит  дробное число. 
           Программа должна вычислить, если это возможно, 
           значение корня, квадрата числа, выделить целую и дробную часть из числа.
*/

namespace Task07
{
    struct Pair<T, U>
    {
        public T first { get; set; }
        public U second { get; set; }

        public Pair(T first, U second)
        {
            this.first = first;
            this.second = second;
        }
    }

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

        static Pair<int, double> RealNumberSplit(double x)
        {
            int integer = (int)x;
            double fraction = x - integer;
            return new Pair<int, double>(integer, fraction);
        }

        static Pair<string, double> SqrtPow(double x)
        {
            return new Pair<string, double>(x > 0 ? Math.Sqrt(x).ToString("G3") : "complex number", x * x);
        }

        static void Main()
        {
            do
            {
                double x = InputDouble("real number X");
                Pair<int, double> split = RealNumberSplit(x);
                Pair<string, double> sqrtPow = SqrtPow(x);
                Console.WriteLine("Integer part: {0}\nFraction part: {1:G3}", split.first, split.second);
                Console.WriteLine("Square root: {0}\nSquared: {1:G3}", sqrtPow.first, sqrtPow.second);
                Console.WriteLine("Press ESC to exit. Press any other key to continue");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
