﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Checker.InputChecker;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 1
*/

namespace Task01
{
    class Program
    {
        static void Main()
        {
            do
            {
                Console.Clear();

                int n = InputVar<int>("number of circles (1 - 100)", x => (x >= 1) && (x <= 100));
                List <Circle> circles = new List<Circle>(n);
                for (int i = 0; i < n; ++i)
                {
                    Console.WriteLine();
                    circles[i] = InputCircle();
                }

                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}