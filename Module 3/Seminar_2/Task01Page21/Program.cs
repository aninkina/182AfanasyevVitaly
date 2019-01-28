using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Checker.InputChecker;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 1 страница 21
*/

namespace Task01Page21
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
                    a[i] = rnd.Next(-15, 16);
                foreach (int i in a)
                    Console.Write($"{i,4} ");
                Console.WriteLine();
                
                Array.Sort(a, (x, y) => Math.Abs(x) > Math.Abs(y) ? 1 : -1);
                foreach (int i in a)
                    Console.Write($"{i,4} ");
                Console.WriteLine();

                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}