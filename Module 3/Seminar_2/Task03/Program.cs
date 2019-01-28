using System;
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
    class Program
    {
        static void Main()
        {
            Console.WriteLine(NumMeth.bisec(3, 6, 0.000001, 0.000001, Math.Cos));
            Console.WriteLine(NumMeth.bisec(0, 3, 0.000001, 0.000001, x => x * (x * x - 2) - 5));
            Console.WriteLine(NumMeth.bisec(0, 1, 0.000001, 0.000001, x => -Math.Sin(x) - Math.Sin(3 * x) / 3));
            
            Console.WriteLine("Press any key to exit.");
        }
    }
}