using System;
using System.Collections;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
            Определите и инициализируйте массив строк.
            Выведите строки в порядке возрастания их длин.
            Порядок элементов в исходном массиве строк не менять.
*/

namespace Task06
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
        /// Outputs the array.
        /// </summary>
        /// <param name="array">Array.</param>
        static void OutputArray(string[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
        
        /// <summary>
        /// Copies the source array to destination array.
        /// </summary>
        /// <param name="destination">Destination array.</param>
        /// <param name="source">Source array.</param>
        static void CopyArray(string[] destination, string[] source)
        {
            int n = source.Length;
            Array.Resize(ref destination, n);
            for (int i = 0; i < n; ++i)
            {
                destination[i] = source[i];
            }
        }
        
        /// <summary>
        /// Compares the length of strings x and y.
        /// </summary>
        /// <returns>1, if length of x >= length of y, -1, otherwise.</returns>
        /// <param name="x">String x.</param>
        /// <param name="y">String y.</param>
        static int CompareLength(string x, string y)
        {
            return (x.Length >= y.Length) ? 1 : -1;
        }
        
        static void Main()
        {
            do
            {
                Console.Clear();

                string[] array = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };
                
                string[] tmp = new string[array.Length];

                CopyArray(tmp, array);

                Array.Sort(tmp, CompareLength);

                Console.WriteLine("Sorted array: ");
                OutputArray(tmp);
                Console.WriteLine("Array: ");
                OutputArray(array);
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
