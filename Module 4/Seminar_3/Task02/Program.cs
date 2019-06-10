﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
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

                int[] arr1 = { 1, 2, 3, 4, 5 };
                HashSet<int> hs1 = new HashSet<int>(arr1);
                RectSet rs1 = new RectSet(hs1);
                int[] arr2 = { 4, 5, 6 }; 
                HashSet<int> hs2 = new HashSet<int>(arr2);
                RectSet rs2 = new RectSet(hs2);

                RectSet rs3 = rs1 + rs2;
                foreach (int x in rs3.GetSet)
                    Console.Write(x + " ");
                Console.WriteLine();
                
                rs3 = rs1 * rs2;
                foreach (int x in rs3.GetSet)
                    Console.Write(x + " ");
                Console.WriteLine();
                
                rs3 = rs1 ^ rs2;
                foreach (int x in rs3.GetSet)
                    Console.Write(x + " ");
                Console.WriteLine();
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}