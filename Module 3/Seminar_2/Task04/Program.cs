using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Checker.InputChecker;
using Task03;

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
            Console.WriteLine(NumMeth.Optimum_1(Math.Cos, 3, 6, 0.000001, 0.000001));
            Console.WriteLine(NumMeth.Optimum_1(x => x * (x * x - 2) - 5, 0, 1, 0.000001, 0.000001));
            Console.WriteLine(NumMeth.Optimum_1(x => -Math.Sin(x) - Math.Sin(3 * x) / 3, 0, 1, 0.000001, 0.000001));
            
            Console.WriteLine("Press any key to exit.");
        }
    }
}