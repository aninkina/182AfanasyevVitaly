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

                MyComplex mc1 = new MyComplex(1, 2), mc2 = new MyComplex(2, -1);
                Console.WriteLine($"({mc1}) + ({mc2}) = {mc1 + mc2}");
                Console.WriteLine($"({mc1}) - ({mc2}) = {mc1 - mc2}");
                Console.WriteLine($"({mc1}) * ({mc2}) = {mc1 * mc2}");
                Console.WriteLine($"({mc1}) / ({mc2}) = {mc1 / mc2}");
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}