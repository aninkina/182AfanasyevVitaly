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
        static int Compare<T>(T a, T b) where T : IComparable
        {
            return a.CompareTo(b);
        }

        static T Maximum<T>(T a, T b) where T : IComparable
        {
            if (Compare(a, b) == 1)
                return a;
            return b;
        }

        static Random rnd = new Random();
        
        static void Main()
        {
            do
            {
                Console.Clear();

                Point<float>[] points = new Point<float>[10];
                for (int i = 0; i < points.Length; ++i)
                {
                    points[i] = new Point<float>(rnd.Next(10), rnd.Next(10));
                }

                Point<float> p1 = points[0];
                for (int i = 1; i < points.Length; ++i)
                {
                    p1 = Maximum(points[i].Distance, p1);
                }

                Console.WriteLine(p1);
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}