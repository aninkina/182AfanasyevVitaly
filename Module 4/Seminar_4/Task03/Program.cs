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
   Задача: 3
*/

namespace Task03
{
    class Fibonacci
    {
        int s = 1, n = 0;

        public IEnumerable NextMemb(int limit)
        {
            int t;
            for (int i = 0; i < limit; ++i)
            {
                t = s + n;
                s = n;
                yield return n = t;
            }
        }
    }

    public class TriangleNums : IEnumerator
    {
        public IEnumerable NextMemb(int limit)
        {
            for (int i = 0; i < limit; ++i)
            {
                yield return i * (i + 1) / 2;
            }
        }

        int position = -1;
        
        public void Reset()
        {
            position = -1;
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

                Fibonacci fib = new Fibonacci();
                TriangleNums trNums = new TriangleNums();
                int m = 10;
                
                foreach (int i in fib.NextMemb(m))
                    Console.Write(i + " ");
                Console.WriteLine();
                foreach (int i in trNums.NextMemb(m))
                    Console.Write(i + " ");
                Console.WriteLine();

                
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}