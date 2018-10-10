using System;
using System.Collections.Generic;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
            Гипотеза Коллатца.
            Программа находит путь от A0 до 1 при помощи преобразований:
                Если An четное, то An+1 = An / 2;
                Если An нечетное, то An+1 = 3 * An + 1;
*/

namespace Task04
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
        /// Inputs and parses the variable.
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
        /// Copies the array from source to destination.
        /// </summary>
        /// <param name="destination">Destination array.</param>
        /// <param name="source">Source array.</param>
        static void CopyArray<T>(out T[] destination, T[] source)
        {
            if (source == null)
            {
                Console.WriteLine("Undefined array!");
                destination = null;
                return;
            }
            destination = new T[source.Length];
            for (int i = 0; i < destination.Length; i++)
                destination[i] = source[i];
        }
        
        /// <summary>
        /// Outputs the array.
        /// </summary>
        /// <param name="array">Array.</param>
        static void OutputArray<T>(T[] array)
        {
            foreach (T i in array)
                Console.Write($"{i:G3} ");
            Console.WriteLine();
        }

        /// <summary>
        /// Outputs the array in rows.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="elementsInRow">Elements in row.</param>
        static void OutputArrayInRows<T>(T[] array, int elementsInRow = 5)
        {
            int i = 0;
            while (i * 5 < array.Length)
            {
                for (int j = i * 5; j < Math.Min(array.Length, (i + 1) * 5); j++)
                {
                    Console.Write($"[{j}] = {array[j]} ");
                }
                i++;
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Finds sequence of Collatz conjecture.
        /// </summary>
        /// <returns>Sequence.</returns>
        /// <param name="a0">First element of sequence.</param>
        static int[] CollatzConjectureSequence(int a0)
        {
            List<int> sequence = new List<int>();
            sequence.Add(a0);
            while (a0 > 1)
            {
                a0 = a0 % 2 == 0 ? a0 / 2 : 3 * a0 + 1;
                sequence.Add(a0);
            }
            return sequence.ToArray();
        }
        
        static void Main()
        {
            do
            {
                Console.Clear();

                int a0 = InputVar("a0", 1, int.MaxValue, (x, y) => x < y, (x, y) => x > y);

                int[] sequence = CollatzConjectureSequence(a0);
                
                OutputArrayInRows(sequence);
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
