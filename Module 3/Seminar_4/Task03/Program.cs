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
            Chain chain = new Chain(100, 7);
            do
            {
                Console.Clear();

                Console.WriteLine(chain);
                Console.WriteLine("Select an option: \n\t1. Change length of a chain. \n\t2. Change number of beads.");
                int option = InputVar<int>("an option", x => (x >= 1) && (x <= 2));
                switch (option)
                {
                    case 1:
                        double length = InputVar<double>("new length of a chain", x => x > 0);
                        chain.Len = length;
                        break;
                    case 2:
                        int n = InputVar<int>("new number of beads (1 - 100)", x => (x > 0) && (x <= 100));
                        chain.N = n;
                        break;
                    default:
                        Console.WriteLine("Invalid option! Try again!");
                        break;
                }
                Console.WriteLine(chain);

                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}