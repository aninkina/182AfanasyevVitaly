using System;
using Checker;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 1
*/

namespace Task01
{
    delegate int Cast(double x);
    
    class Program
    {
        static void Main()
        {
            Cast nearestEvenInteger = x =>
            { 
                int k = (int)x; 
                if (k % 2 == 1) 
                    k--; 
                return x - k < k + 2 - x ? k : k + 2; 
            };
            
            Cast order = x =>
            { 
                if (x <= 0) 
                    throw new ArgumentException("Can't find order of a negative number.");
                return (int)Math.Log10(x) + 1; 
            };
                
            for (decimal i = 0.0M; i <= 2.1M; i += 0.1M)
            {
                Console.WriteLine($"Nearest even integer for {i} is {nearestEvenInteger((double)i)}");
            }
            Console.WriteLine();
            for (decimal i = 100M; i >= 0.001M; i /= 10)
            {
                Console.WriteLine($"Order of {i} is {order((double)i)}");
            }
            Console.WriteLine();

            Cast doubleFunc = nearestEvenInteger;
            doubleFunc += order;

            Console.WriteLine(doubleFunc(30));
            
            Console.WriteLine("Press any key to exit.");
        }
    }
}