using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
            Сформировать и заполнить случайными значениями 
            вещественную матрицу размером MxN (M и N задаются с клавиатуры). 
            На экран вывести сумму элементов для каждого столбца.
*/

namespace Task02Page32
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
        /// Creates the matrix NxM. Initializes it with random numbers [lowerBound, upperBound].
        /// </summary>
        /// <returns>The matrix.</returns>
        /// <param name="n">Size N.</param>
        /// <param name="m">Size M.</param>
        /// <param name="lowerBound">Lower bound of random numbers.</param>
        /// <param name="upperBound">Upper bound of random numbers.</param>
        static int[,] CreateMatrix(int n, int m, int lowerBound = 1, int upperBound = 10)
        {
            Random rnd = new Random();
            int[,] matrix = new int[n, m];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    matrix[i, j] = rnd.Next(lowerBound, upperBound + 1);
                }
            }
            return matrix;
        }

        /// <summary>
        /// Summarizes the elements of column K of matrix.
        /// </summary>
        /// <returns>Sum.</returns>
        /// <param name="matrix">Matrix.</param>
        /// <param name="k">Number of column.</param>
        static int SumCol(int[,] matrix, int k)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); ++i)
                sum += matrix[i, k];
            return sum;
        }
        
        /// <summary>
        /// Translates matrix to string.
        /// </summary>
        /// <returns>String.</returns>
        /// <param name="matrix">Matrix.</param>
        static string MatrixToString(int[,] matrix)
        {
            string output = "";
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    output += matrix[i, j] + " ";
                }
                output += "\n";
            }
            return output;
        }
        
        static void Main()
        {
            do
            {
                Console.Clear();

                int n = InputVar("number of rows in matrix", 1, int.MaxValue, (x, y) => x < y, (x, y) => x > y);
                int m = InputVar("number of columns in matrix", 1, int.MaxValue, (x, y) => x < y, (x, y) => x > y);

                int[,] matrix = CreateMatrix(n, m);

                Console.WriteLine($"Matrix:\n{MatrixToString(matrix)}");

                for (int i = 0; i < m; ++i)
                {
                    Console.WriteLine($"Sum of column {i + 1}: {SumCol(matrix, i)}");
                }
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
