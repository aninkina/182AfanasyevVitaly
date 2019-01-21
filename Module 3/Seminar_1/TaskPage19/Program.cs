using System;
using LibPage19;
using Checker;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: Страница 19
*/

namespace TaskPage19
{
    class Program
    {
        static void Main()
        {   
            MyDel f = TestClass.TestMethod;
            
            do
            {
                Console.Clear();

                double a = InputChecker.InputVar<double>("first real number");
                double b = InputChecker.InputVar<double>("second real number");
                Console.WriteLine($"Sum of integer parts: {f(a, b)}");
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}