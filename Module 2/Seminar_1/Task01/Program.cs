using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
            Определить матрицу как двумерный массив, инициализировать ее элементы.
            Используя свойства и методы класса Array вывести ранг массива,
            общее число его элементов, число элементов по разным  измерениям,
            предельные значения всех индексов, признак фиксированных размеров.
            Вывести элементы массива, используя цикл foreach.
            Вывести элементы массива по строкам (в виде таблицы).
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



        static void Main()
        {
            do
            {
                Console.Clear();

                int[,] array = { { 0, 1, 3, 4 }, { 5, 6, 7, 8 }, { 9, -1, -2, -3 } };
                Console.WriteLine($"Rank: {array.Rank}");
                Console.WriteLine($"Length: {array.Length}");
                Console.WriteLine($"Length 1: {array.GetLength(0)}; Length 2: {array.GetLength(1)}");
                Console.WriteLine($"Lower bound 1: {array.GetLowerBound(0)}; Upper bound 1: {array.GetUpperBound(0)}");
                Console.WriteLine($"Lower bound 2: {array.GetLowerBound(1)}; Upper bound 2: {array.GetUpperBound(1)}");
                Console.WriteLine($"Fixed size: {array.IsFixedSize}");
                foreach (int i in array)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
                

                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
