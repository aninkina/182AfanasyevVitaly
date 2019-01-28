using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Checker.InputChecker;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 6
*/

namespace Task06
{
    class Program
    {
        static void Main()
        {
            double[] a = new double[5];
            do
            {
                Console.Clear();

                Console.WriteLine($"Input array of {a.Length} elements. Each element is a positive real number.");
                for (int i = 0; i < a.Length; ++i)
                {
                    a[i] = InputVar<double>($"element №{i + 1}", x => x > 0);
                }

                double max = a[0];
                Array.ForEach(a, x => max = Math.Max(x, max));
                a = Array.ConvertAll(a, x => x / max);
                Console.WriteLine("Normalized array:");
                Array.ForEach(a, x => Console.Write(x + " "));
                Console.WriteLine();

                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}