using System;
using System.Collections.Generic;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 5
*/

namespace Task05
{
    delegate double Multiplication(int left, int right, Func<double, double> f);
    delegate double Sum(int left, int right, Func<double, double> f);
    
    class Program
    {
        /// <summary>
        /// Checks if inputed value meets the conditions.
        /// </summary>
        /// <returns><c>true</c>, if value met the conditions, <c>false</c> otherwise.</returns>
        /// <param name="input">Input.</param>
        /// <param name="conditions">Conditions.</param>
        static bool CheckConditions<T>(T input, params Func<T, bool>[] conditions)
        {
            foreach (Func<T, bool> condition in conditions)
            {
                if (!condition.Invoke(input))
                    return false;
            }
            return true;
        }
        
        /// <summary>
        /// Inputs and parses the variable of type T.
        /// </summary>
        /// <returns>Variable of type T.</returns>
        /// <param name="input">Input.</param>
        /// <param name="conditions">Conditions.</param>
        static T InputVar<T>(string input, params Func<T, bool>[] conditions)
        {
            var parser = typeof(T).GetMethod("TryParse", new[] { typeof(string), typeof(T).MakeByRefType() });
            if (parser == null)
                throw new ApplicationException($"Invalid type {typeof(T)}");
            Console.WriteLine($"Enter {input}:");
            object[] result = { Console.ReadLine(), null};
            while (!(bool)parser.Invoke(null, result) || !CheckConditions((T)result[1], conditions))
            {
                Console.WriteLine("Invalid input format! Try again!");
                Console.WriteLine($"Enter {input}:");
                result = new object[] { Console.ReadLine(), null };
            }
            return (T)result[1];
        }

        static void Main()
        {
            do
            {
                Console.Clear();

                Multiplication m = (left, right, f) => 
                { 
                    double result = 1; 
                    for (int i = left; i <= right; ++i) 
                        result *= f(i); 
                    return result; 
                };
                
                Sum s = (left, right, f) =>
                {
                    double result = 0;
                    for (int i = left; i <= right; ++i)
                        result += f(i);
                    return result;
                };
                
                double k = InputVar<double>("x");
                int leftBorder = 1, rightBorder = 5;
                Console.WriteLine("Answer: " + s(leftBorder, rightBorder, y => m(1, 5, x => y * k / x)));
                    
                double ans = 0;
                for (int i = leftBorder; i <= rightBorder; ++i)
                {
                    double tmpResult = 1;
                    for (int j = leftBorder; j <= rightBorder; ++j)
                    {
                        tmpResult *= i * k / j;
                    }
                    ans += tmpResult;
                }
                Console.WriteLine("Correct answer: " + ans);
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}