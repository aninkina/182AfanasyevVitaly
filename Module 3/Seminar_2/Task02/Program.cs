using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Checker.InputChecker;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 2
*/

namespace Task02
{
    public delegate void CarEngineHandler(string msgForCaller);

    class Program
    {
        static void Main()
        {
            Car car = new Car("abc", 100, 10);
            car.RegisterWithCarEngine(new CarEngineHandler(Console.WriteLine));
            for (int i = 0; i < 10; ++i)
            {
                car.Accelerate(10);
                Thread.Sleep(500);
            }


            Console.WriteLine("Press any key to exit.");
        }
    }
}