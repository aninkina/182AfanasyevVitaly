﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

                ListT<int> a = new ListT<int>();
                for (int i = 0; i < 10; ++i)
                    a.Add(rnd.Next(10));
                
                Console.WriteLine($"Length: {a.Length}");
                for (int i = 0; i < a.Length; ++i)
                    Console.Write(a[i] + " ");
                Console.WriteLine();
                a.Remove(3);
                Console.WriteLine($"Length: {a.Length}");
                for (int i = 0; i < a.Length; ++i)
                    Console.Write(a[i] + " ");
                Console.WriteLine();
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}