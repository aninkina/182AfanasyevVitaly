﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;
using System.Collections;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 4
*/

namespace Task04
{
    class Program
    {
        static Random rnd = new Random();
        
        static void Main()
        {
            do
            {
                Console.Clear();

                int[] array = { 1, 3, 6, 2, 7, 9, 4, 0 };

                ArrayEnumerator<int> enumerator = new ArrayEnumerator<int>(array);
                foreach (int i in enumerator)
                    Console.Write(i + " ");
                Console.WriteLine();
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}