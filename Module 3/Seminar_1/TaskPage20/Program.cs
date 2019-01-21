using System;
using Checker;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: Страница 20
*/

namespace TaskPage20
{
    delegate double Sum(int n);
    
    class Program
    {
        static void Main()
        {
            Sum sum1 = (n) =>
            {
                double result = 0;
                for (int i = 1; i <= n; ++i)
                    result += 1.0 / i ;
                return result;
            };

            Sum doubleSum1 = (n) =>
            {
                double result = 0;
                for (int i = 1; i <= n; ++i)
                {
                    result += sum1(i);
                }
                return result;
            };

            Sum sum2 = (n) =>
            {
                double result = 0;
                for (int i = 1; i <= n; ++i)
                    result += 1.0 / Math.Pow(2, i) ;
                return result;
            };

            Sum doubleSum2 = (n) =>
            {
                double result = 0;
                for (int i = 1; i <= n; ++i)
                {
                    result += sum2(i);
                }
                return result;
            };

            const int maxInput = 1000;
            
            do
            {
                Console.Clear();

                int n = InputChecker.InputVar<int>($"positive integer N (1 - {maxInput})", x => (x > 0) && (x <= maxInput));

                double sum1Check = 0;
                for (int i = 1; i <= n; ++i)
                {
                    for (int j = 1; j <= i; ++j)
                    {
                        sum1Check += 1.0 / j;
                    }
                }
                
                double sum2Check = 0;
                for (int i = 1; i <= n; ++i)
                {
                    for (int j = 1; j <= i; ++j)
                    {
                        sum2Check += 1.0 / Math.Pow(2, j);
                    }
                }
                
                Console.WriteLine($"Sum1 : {doubleSum1(n):F3}");
                Console.WriteLine($"Correct Sum1 : {sum1Check:F3}");
                Console.WriteLine($"Sum2 : {doubleSum2(n):F3}");
                Console.WriteLine($"Correct Sum2 : {sum2Check:F3}");
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}