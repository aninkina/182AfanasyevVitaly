using System;

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

        /// <summary>
        /// Creates the identity matrix.
        /// </summary>
        /// <returns>The identity matrix.</returns>
        /// <param name="n">Size.</param>
        static int[,] CreateIdentityMatrix(int n)
        {
            if (n <= 0)
                throw new ArgumentException("Size should be positive integer!");
            int[,] mx = new int[n, n];
            for (int i = 0; i < n; ++i)
                mx[i, i] = 1;
            return mx;
        }

        /// <summary>
        /// Prints the matrix.
        /// </summary>
        /// <param name="mx">Matrix.</param>
        static void PrintMatrix(int[,] mx)
        {
            int n = mx.GetLength(0), m = mx.GetLength(1);
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    Console.Write(mx[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        
        static void Main()
        { 
            do
            {
                Console.Clear();

                Console.WriteLine("Enter size:");
                try
                {
                    int n = int.Parse(Console.ReadLine());
                    int[,] mx = CreateIdentityMatrix(n);
                    PrintMatrix(mx);
                }
                catch
                {
                    Console.WriteLine("Invalid input!");
                }
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}