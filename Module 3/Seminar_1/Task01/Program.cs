using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 1
*/

namespace Task01
{
    delegate int Cast(double x);
    
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

                Cast nearestEvenInteger = x =>
                { 
                    int k = (int)x; 
                    if (k % 2 == 1) 
                        k--; 
                    return x - k < k + 2 - x ? k : k + 2; 
                };
                
                Cast order = x =>
                { 
                    if (x <= 0) 
                        throw new ArgumentException("Can't find order of a negative number.");
                    return (int)Math.Log10(x) + 1; 
                };

                for (decimal i = 0.0M; i <= 2.1M; i += 0.1M)
                {
                    Console.WriteLine($"Nearest even integer for {i} is {nearestEvenInteger((double)i)}");
                }
                Console.WriteLine();
                for (decimal i = 100M; i >= 0.001M; i /= 10)
                {
                    Console.WriteLine($"Order of {i} is {order((double)i)}");
                }
                Console.WriteLine();

                Cast doubleFunc = nearestEvenInteger;
                doubleFunc += order;

                Console.WriteLine(doubleFunc(30));
                
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}