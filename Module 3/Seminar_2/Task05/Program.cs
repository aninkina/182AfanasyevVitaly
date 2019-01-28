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
        static void Main()
        {
            Series series = new Series(new int[] { 1, 5, 4, 2, 3 });

            series.Order((x, y) => x > y ? 1 : -1);
            foreach (int i in series.Arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            series.Order((x, y) => x > y ? -1 : 1);
            foreach (int i in series.Arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Press any key to exit.");
        }
    }
}