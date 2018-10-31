using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
            Определить массив из трех элементов – ссылок на массивы разной длины.
                1-й элемент - массив из 3-х элементов – ссылок на массивы, 
                соответственно, из 2-х, 3-х и 4-х элементов типа char. 
                2-й элемент - массив из 2-х элементов ссылок на массивы, 
                соответственно, из 2-х и 3-х элементов типа char. 
                3-й элемент - массив из ОДНОГО элемента – ссылки на массив из 4-х элементов типа char. 
            Используя свойства и методы класса Array вывести ранг массива,
            общее число его элементов, число элементов по разным измерениям, предельные значения всех индексов. 
            Вывести элементы массива с помощью циклов foreach,  размещая 
            значения элементов каждого массива нижнего уровня по строкам.
*/

namespace Task03
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

                char[][][] array = 
                { 
                    new char[][] 
                    { 
                        new char[] { 'a', 'b' }, 
                        new char[] { 'c', 'd', 'e' }, 
                        new char[] { 'f', 'g', 'h', 'i' } 
                    },
                    new char[][] 
                    { 
                        new char[] { 'j', 'k' }, 
                        new char[] { 'l', 'm', 'n' } 
                    },
                    new char[][] 
                    { 
                        new char[] { 'o', 'p', 'q', 'r' } 
                    } 
                };

                Console.WriteLine($"Length: {array.Length}");
                Console.WriteLine($"GetLength(0): {array.GetLength(0)}");
                Console.WriteLine($"[0].GetLength(0): {array.GetLength(0)}");
                Console.WriteLine($"Rank: {array.Rank}");
                Console.WriteLine($"Rank[0]: {array[0].Rank}");
                Console.WriteLine($"Rank[0][0]: {array[0][0].Rank}");
                Console.WriteLine($"Type: {array.GetType()}");


                foreach (char[][] i in array)
                {
                    Console.WriteLine();
                    foreach (char[] j in i)
                    {
                        foreach (char k in j)
                            Console.Write(k + "\t");
                        Console.WriteLine();
                    }          
                }

                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
