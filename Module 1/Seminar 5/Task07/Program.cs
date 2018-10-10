using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
            Получить от пользователя число N > 0. Разбить число на цифры, создать из них массив символов.
            Вывести массив.
*/

namespace Task07
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
        static void InitArray(long[] array)
        {
            const int leftBorder = -10, rightBorder = 10;
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
                Console.Write($"{i} ");
            Console.WriteLine();
        }

        /// <summary>
        /// Translates positive integer N to array of chars.
        /// </summary>
        /// <returns>Char array.</returns>
        /// <param name="n">N.</param>
        static char[] IntToCharArray(int n)
        {
            int length = (int)Math.Log10(n) + 1;
            char[] array = new char[length];
            int i = length - 1;
            while (n > 0)
            {
                array[i--] = (char)('0' + n % 10);
                n /= 10;
            }
            return array;
        }

        static void Main()
        {
            do
            {
                Console.Clear();

                int n = InputVar("positive integer", 1, int.MaxValue, (x, y) => x < y, (x, y) => x > y);

                char[] a = IntToCharArray(n);

                Console.Write("Array: ");
                OutputArray(a);     

                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
