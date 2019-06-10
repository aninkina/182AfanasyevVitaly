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

                MyInt myInt = new MyInt(new int[]{ 1, 2, 3, 4, 5 });
                foreach (var i in myInt)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}