using System;
using System.Collections.Generic;
using Checker;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 5
*/

namespace Task05
{
    delegate double Multiplication(int left, int right, Func<double, double> f);
    delegate double Sum(int left, int right, Func<double, double> f);
    
    class Program
    {
        static void Main()
        {
            Multiplication m = (left, right, f) => 
            { 
                double result = 1; 
                for (int i = left; i <= right; ++i) 
                    result *= f(i); 
                return result; 
            };
            
            Sum s = (left, right, f) =>
            {
                double result = 0;
                for (int i = left; i <= right; ++i)
                    result += f(i);
                return result;
            };
                
            do
            {
                Console.Clear();

                double k = InputChecker.InputVar<double>("x");
                int leftBorder = 1, rightBorder = 5;
                Console.WriteLine("Answer: " + s(leftBorder, rightBorder, y => m(1, 5, x => y * k / x)));
                    
                double ans = 0;
                for (int i = leftBorder; i <= rightBorder; ++i)
                {
                    double tmpResult = 1;
                    for (int j = leftBorder; j <= rightBorder; ++j)
                    {
                        tmpResult *= i * k / j;
                    }
                    ans += tmpResult;
                }
                Console.WriteLine("Correct answer: " + ans);
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}