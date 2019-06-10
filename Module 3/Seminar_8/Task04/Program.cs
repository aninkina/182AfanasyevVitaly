﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Checker.InputChecker;

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
        static void Main()
        {
            do
            {
                Console.Clear();

                MyStack<int> intStack = new MyStack<int>();
                for (int i = 0; i < 10; ++i)
                {
                    intStack.Push(i);
                }
                for (int i = 0; i < 10; ++i)
                {
                    Console.Write(intStack.Pop() + " ");
                }
                Console.WriteLine();
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}