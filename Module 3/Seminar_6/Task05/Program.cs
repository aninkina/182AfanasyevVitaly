﻿using System;
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
            do
            {
                Console.Clear();

                int n = InputVar<int>("size of array (1 - 100)", x => (x > 0) && (x <= 100));
                
                Animal[] animals = new Animal[n];
                for (int i = 0; i < n; ++i)
                {
                    int type = rnd.Next(3);
                    switch (type)
                    {
                        case 0:
                            animals[i] = new Cockroach((uint)rnd.Next(100), (uint)rnd.Next(100));
                            break;
                        case 1:
                            animals[i] = new Kangaroo((uint)rnd.Next(100), (uint)rnd.Next(100));
                            break;
                        case 2:
                            animals[i] = new Cheetah((uint)rnd.Next(100), (uint)rnd.Next(100), (uint)rnd.Next(100));
                            break;
                    }
                }

                Console.WriteLine("Animals:");
                for (int i = 0; i < n; ++i)
                {
                    Console.WriteLine("\t" + animals[i]);
                }
                
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}