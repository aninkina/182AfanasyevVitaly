using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
            Ввести положительные значения N и M. 
            Построить двумерный целочисленный массив (матрицу) с размерами N на M,
            элементы которого a[i, j] = (i+1)*(2*j+1), для i от 0 до (N-1), j от 0 до (M-1). 
            Вывести матрицу в виде таблицы, а также значения свойств Rank и Length. 
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

        delegate int Func(int x, int y);
        
        /// <summary>
        /// Inits the array with formula F(i, j) (i and j - indexes);
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="f">Formula for initialization.</param>
        static void InitArray(int[,] array, Func f)
        {
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                {
                    array[i, j] = f(i, j);
                }
            }
        }

        /// <summary>
        /// Outputs the array.
        /// </summary>
        /// <param name="array">Array.</param>
        static void OutputArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Changes elements of the sub diagonal of square array to the integer K.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="k">K.</param>
        static void ChangeSubDiagonal(int[,] array, int k)
        {
            if (array.GetLength(0) != array.GetLength(1))
                throw new ArgumentException("Wrong array size");
            
            int n = array.GetLength(0);
            for (int i = 0; i < n; ++i)
            {
                array[i, n - 1 - i] = k;
            }
        }

        static void Main()
        {
            do
            {
                Console.Clear();

                int n = InputVar("natural integer N", 1, int.MaxValue, (x, y) => x < y, (x, y) => x > y);
                int m = InputVar("natural integer M", 1, int.MaxValue, (x, y) => x < y, (x, y) => x > y);

                int[,] array = new int[n, m];
                
                InitArray(array, (x, y) => (x + 1) * (2 * y + 1));

                if (n == m)
                    ChangeSubDiagonal(array, 0);
                    
                OutputArray(array);

                Console.WriteLine($"Rank: {array.Rank}");
                Console.WriteLine($"Length: {array.Length}");
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
