using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
            Получить от пользователя размеры двух массивов. Инициализировать массивы случайными целыми числами [10; 50].
            Добавить в конец первого массива четные числа из второго массива.
            Вывести каждый массив.
*/

namespace Task01
{
    class Program
    {
    
        // Input methods
        
        delegate bool Compare<T>(T a, T b);

        /// <summary>
        /// Parses the input.
        /// </summary>
        /// <returns><c>true</c>, if input was parsed, <c>false</c> otherwise.</returns>
        /// <param name="input">Input.</param>
        /// <param name="result">Result.</param>
        /// <typeparam name="T">Type.</typeparam>
        static bool ParseInput<T>(string input, out T result)
        {
            bool parsed;
            if (typeof(T) == typeof(int))
            {
                int tmpResult;
                parsed = int.TryParse(input, out tmpResult);
                result = (T)(object)tmpResult;
            }
            else if (typeof(T) == typeof(double))
            {
                double tmpResult;
                parsed = double.TryParse(input, out tmpResult);
                result = (T)(object)tmpResult;
            }
            else if (typeof(T) == typeof(uint))
            {
                uint tmpResult;
                parsed = uint.TryParse(input, out tmpResult);
                result = (T)(object)tmpResult;
            }
            else if (typeof(T) == typeof(long))
            {
                long tmpResult;
                parsed = long.TryParse(input, out tmpResult);
                result = (T)(object)tmpResult;
            }
            else if (typeof(T) == typeof(byte))
            {
                byte tmpResult;
                parsed = byte.TryParse(input, out tmpResult);
                result = (T)(object)tmpResult;
            }
            else if (typeof(T) == typeof(sbyte))
            {
                sbyte tmpResult;
                parsed = sbyte.TryParse(input, out tmpResult);
                result = (T)(object)tmpResult;
            }
            else if (typeof(T) == typeof(char))
            {
                char tmpResult;
                parsed = char.TryParse(input, out tmpResult);
                result = (T)(object)tmpResult;
            }
            else
            {
                result = default(T);
                parsed = true;
            }
            return parsed;
        }

        /// <summary>
        /// Inputs and parses the variable of type T.
        /// </summary>
        /// <returns>Variable of type T.</returns>
        /// <param name="input">Input.</param>
        /// <param name="minValue">Minimum value.</param>
        /// <param name="maxValue">Maximum value.</param>
        /// <param name="compMin">Comparator for minValue.</param>
        /// <param name="compMax">Comparator for maxValue.</param>
        static T InputVar<T>(string input, T minValue, T maxValue, Compare<T> compMin, Compare<T> compMax)
        {
            Console.WriteLine($"Enter {input}:");
            T result;
            while (!ParseInput(Console.ReadLine(), out result) || compMin(result, minValue) || compMax(result, maxValue))
            {
                Console.WriteLine("Invalid input format! Try again!");
                Console.WriteLine($"Enter {input}:");
            }
            return result;
        }

        
        // Methods for solving
        
        /// <summary>
        /// Inits the array.
        /// </summary>
        /// <param name="array">Array.</param>
        static void InitArray(int[] array)
        {
            const int leftBorder = 10, rightBorder = 50;
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next(leftBorder, rightBorder);
        }
        
        /// <summary>
        /// Outputs the array.
        /// </summary>
        /// <param name="array">Array.</param>
        static void OutputArray<T>(T[] array)
        {
            foreach (T i in array)
                Console.Write($"{i:F3} ");
            Console.WriteLine();
        }
        
        /// <summary>
        /// Adds evens from source to destination array.
        /// </summary>
        /// <param name="destination">Destination array.</param>
        /// <param name="source">Source array.</param>
        static void AddEvens(ref int[] destination, int[] source)
        {
            int evenCount = 0;
            int[] evens = new int[source.Length];
            foreach (int i in source)
            {
                if (i % 2 == 0)
                {
                    evens[evenCount] = i;
                    evenCount++;
                }
            }
            Array.Resize(ref destination, destination.Length + evenCount);
            for (int i = 0; i < evenCount; i++)
                destination[i + destination.Length - evenCount] = evens[i];
        }
        
        static void Main()
        {
            do
            {
                Console.Clear();
                
                int n1 = InputVar("the size of array A (1 - 100)", 1, 100, (x, y) => x < y, (x, y) => x > y);
                int n2 = InputVar("the size of array B (1 - 100)", 1, 100, (x, y) => x < y, (x, y) => x > y);

                int[] a = new int[n1];
                int[] b = new int[n2];

                InitArray(a);
                InitArray(b);

                Console.Write("Array A: ");
                OutputArray(a);
                Console.Write("Array B: ");
                OutputArray(b);

                AddEvens(ref a, b);
                Console.Write("Modified array A: ");
                OutputArray(a);

                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
