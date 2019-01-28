using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Checker.InputChecker;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 3 страница 21
*/

namespace Task03Page21
{
    class Program
    {
        static Random rnd = new Random();
        
        static void Main()
        {
            do
            {
                Console.Clear();

                double[] a = new double[10];
                for (int i = 0; i < a.Length; ++i)
                    a[i] = rnd.Next(-3, 3) + rnd.NextDouble();
                Array.ForEach(a, x => Console.Write($"{x:F2} "));
                Console.WriteLine();

                int[] b = Array.ConvertAll(a, delegate (double x) { return x >= 0 ? (int)x : 0; });
                Array.ForEach(b, x => Console.Write($"{x} "));
                Console.WriteLine();

                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}