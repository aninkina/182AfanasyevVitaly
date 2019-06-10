﻿using System;
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

    class Rainbow 
    {
        public IEnumerator GetEnumerator() 
        {
            yield return "каждый ";
            yield return "охотник ";
            yield return "желает ";
            yield return "знать ";
            yield return "где ";
            yield return "сидит ";
            yield return "фазан ";
        }
    }
    
    class Program
    {
        static Random rnd = new Random();
        
        static void Main()
        {
            do
            {
                Console.Clear();

                Rainbow rainbow = new Rainbow();
                foreach (string str in rainbow)
                    Console.Write(str);
                foreach (string str in rainbow)
                    Console.Write(str);
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}