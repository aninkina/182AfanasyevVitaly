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
   Задача: 1
*/

namespace Task01
{

    public class A
    {
        private string[] arr = { "раз ромашка ", "два ромашка ", "три ромашка ", "пять ромашка ", "шесть ромашка " };

        public IEnumerator GetEnumerator()
        {
            foreach (string str in arr)
                yield return str;
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
                
                string[] testArr = { "раз ", "два ", "три " };
                foreach (string str in testArr) // "проходит" по любому массиву
                    Console.Write(str);
                Console.WriteLine();
                
                A a = new A();
                foreach (string str in a) // ошибка компиляции
                    Console.Write(str);
                Console.WriteLine();
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}