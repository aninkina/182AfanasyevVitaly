using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
           Получить от пользователя размер массива. Создать массив из случайных символов от A до Z.
           Отсортировать массив. Перевернуть массив.
           Вывести каждый массив. 
*/

namespace Task02
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
        static void InitArray(char[] array)
        {
            const char leftBorder = 'A', rightBorder = 'Z';
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = (char)rnd.Next(leftBorder, rightBorder);
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
                Console.Write($"{i:F3} ");
            Console.WriteLine();
        }
        
        
        static void Main()
        {
            do
            {
                Console.Clear();

                int k = InputVar("the size of array (1 - 100)", 1, 100, (x, y) => x < y, (x, y) => x > y);

                char[] a = new char[k];

                InitArray(a);

                Console.Write("Array: ");
                OutputArray(a);

                char[] b;
                
                CopyArray(out b, a);

                Array.Sort(b);

                Console.Write("Sorted array: ");
                OutputArray(b);

                Array.Reverse(b);

                Console.Write("Reversed sorted array: ");
                OutputArray(b);

                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
