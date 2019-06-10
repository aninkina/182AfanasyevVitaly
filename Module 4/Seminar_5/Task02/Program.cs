using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;
using System.Collections;
using static Checker.InputChecker;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 2
*/

namespace Task02
{
    class Program
    {
        static Random rnd = new Random();

        static void Main()
        {
            do
            {
                Console.Clear();

                PointList set = new PointList();
                set.Add(new Point(4, 5));
                set.Add(new Point(4, 5));
                set.Add(new Point(4, 5));
                set.Add(new Point(7, 1));
                set.Add(new Point(7, 2));
                set.Add(new Point(5, 2));
                set.Add(new Point(7, 2));
                Console.WriteLine("Список точек на плоскости:");
                foreach (Point p in set)
                    Console.WriteLine(p);
            
            Console.WriteLine("Press Esc to exit. Press any other key to continue.");
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
}
}