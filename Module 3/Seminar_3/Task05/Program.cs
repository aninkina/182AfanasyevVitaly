using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Checker.InputChecker;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 5
*/

namespace Task05
{
    class Program
    {
        static Random rnd = new Random();
        
        static void Main()
        {
            ArrayPrintClass.LineComplete += (x) => { if (x % 5 == 0) Console.WriteLine(); };
            do
            {
                Console.Clear();

                int[,] a = new int[3, 7];
                for (int i = 0; i < a.GetLength(0); ++i)
                {
                    for (int j = 0; j < a.GetLength(1); ++j)
                    {
                        a[i, j] = rnd.Next(10);
                    }
                }
                ArrayPrintClass.ArrayPrint(a);

                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}