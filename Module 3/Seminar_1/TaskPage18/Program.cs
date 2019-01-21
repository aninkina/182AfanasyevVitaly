using System;
using LibPage18;
using Checker;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: Страница 18
*/

namespace TaskPage18
{
    class Program
    {
        static void Main()
        {   
            MyDel f = TestClass.TestMethod;
            
            do
            {
                Console.Clear();

                int a = InputChecker.InputVar<int>("first integer");
                int b = InputChecker.InputVar<int>("second integer");
                Console.WriteLine($"Maximum: {f(a, b)}");
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}