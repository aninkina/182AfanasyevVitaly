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

                List<Department> departments = new List<Department>()
                {
                    new Department("Sofrwa
                }
                
                University university = new University("HSE",
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}