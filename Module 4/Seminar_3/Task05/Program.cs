﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;
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
            do
            {
                Console.Clear();

                Interval i1 = new Interval(1, 2);
                Interval i2 = new Interval(3, 4);

                Console.WriteLine(i1 + i2);
                Console.WriteLine(i1 - i2);
                Console.WriteLine(i1 * i2);
                Console.WriteLine(i1 / i2);
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}