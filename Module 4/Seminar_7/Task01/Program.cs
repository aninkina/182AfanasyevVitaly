﻿﻿using System;
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
   Задача: 1
*/

namespace Task01
{   
    class Program
    {
        static Random rnd = new Random();
        
        static void Main()
        {
            do
            {
                Console.Clear();

                
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}