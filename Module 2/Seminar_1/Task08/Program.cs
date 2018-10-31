using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
            В классе Program, размещённом в файле Program.cs написать:
                Метод CreateMatrix() возвращает целочисленную матрицу размера M, N, 
                    заполненную случайными значениями из диапазона [1;10]. М, N – целочисленные параметры метода. 
                Метод MatrixMult() возвращает целочисленную матрицу представляющую произведение матриц A и  B, 
                    переданных в качестве параметров. Если A и B не могут быть перемножены, метод возвращает значение null.
                Метод MatrixToString() возвращает строку с табличным представлением матрицы (каждая строка матрицы должна при выводе отображаться на новой строке)
            В том же классе разместить код метода Main(), который:
                Получает от пользователя значения размеры двух матриц A и B и формирует их при помощи метода CreateMatrix();
                При помощи метода MatrixMult() формирует матрицу C произведения AxB, если это возможно, в противном случае вывести понятное сообщение. 
                Формирует строки-представления матриц A, B и C при помощи метода MatrixToString() и выводит их на экран.
                Если матрицы перемножить невозможно, выводит на экран только строки-представления матриц A, B и сообщение о невозможности их перемножения.
*/

namespace Task08
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
        /// Multiplies the matrices A and B.
        /// </summary>
        /// <returns>Matrix C - result of multiplication, if A and B can be multiplied, null, otherwise</returns>
        /// <param name="a">Matrix A.</param>
        /// <param name="b">Matrix B.</param>
        static int[,] MatrixMult(int[,] a, int[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0))
                return null;
            int n = a.GetLength(0), m = b.GetLength(1);
            int[,] matrix = new int[n, m];
            for (int row = 0; row < n; ++row)
            {
                for (int column = 0; column < m; ++column)
                {
                    matrix[row, column] = 0;
                    for (int i = 0; i < a.GetLength(1); ++i)
                        matrix[row, column] += a[row, i] * b[i, column];
                }
            }
            return matrix;
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

                int aN = InputVar("number of rows in matrix A", 1, int.MaxValue, (x, y) => x < y, (x, y) => x > y);
                int aM = InputVar("number of columns in matrix A", 1, int.MaxValue, (x, y) => x < y, (x, y) => x > y);
                int bN = InputVar("number of rows in matrix B", 1, int.MaxValue, (x, y) => x < y, (x, y) => x > y);
                int bM = InputVar("number of columns in matrix B", 1, int.MaxValue, (x, y) => x < y, (x, y) => x > y);

                int[,] a = CreateMatrix(aN, aM);
                int[,] b = CreateMatrix(bN, bM);

                Console.WriteLine($"A:\n{MatrixToString(a)}");
                Console.WriteLine($"B:\n{MatrixToString(b)}");

                int[,] c = MatrixMult(a, b);

                if (c != null)
                    Console.WriteLine($"AxB:\n{MatrixToString(c)}");
                else
                    Console.WriteLine("Matrices can\'t be multiplied");
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
