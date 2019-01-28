using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Checker.InputChecker;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 2 страница 21
*/

namespace Task02Page21
{
    class Program
    {
        static Random rnd = new Random();
        
        static void Main()
        {
            do
            {
                Console.Clear();

                int[] a = new int[10];
                for (int i = 0; i < a.Length; ++i)
                    a[i] = rnd.Next(1, 20);
                Array.ForEach(a, x => Console.Write($"{x} "));
                Console.WriteLine();

                double[] b = Array.ConvertAll(a, x => 1.0 / x);
                Array.ForEach(b, x => Console.Write($"{x:F2} "));
                Console.WriteLine();

                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}