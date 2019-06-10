﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Checker.InputChecker;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 3
*/

namespace Task03
{
    interface IFigure
    {
        double Area { get; }
    }
    
    class Program
    {
        static void PrintInformation<T>(T[] array, double border = 0) where T : IFigure
        {
            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i].Area <= border)
                    continue;
                if (array[i] is Square)
                    Console.Write("Square. ");
                if (array[i] is Circle)
                    Console.Write("Circle. ");
                Console.WriteLine(array[i] + $" Area: {array[i].Area:F3}");
            }
        }

        static Random rnd = new Random();
        
        static void Main()
        {
            do
            {
                Console.Clear();

                IFigure[] figures = new IFigure[10];
                for (int i = 0; i < figures.Length; ++i)
                {
                    int type = rnd.Next(2);
                    switch (type)
                    {
                        case 0:
                            figures[i] = new Square(rnd.Next(10));
                            break;
                        case 1:
                            figures[i] = new Circle(rnd.Next(10));
                            break;
                    }
                }
                PrintInformation(figures);
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}