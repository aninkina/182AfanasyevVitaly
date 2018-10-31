using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
            Создать двумерный массив NxM (числа вводятся пользователем).
            Инициализировать массив целыми числами [-100; 100).
            Заменить максимальный по модулю элемент каждой строки на противоположный по знаку.
            Вставить после каждой строки с чётным индексом нулевую строку.
            Удалить все строки, содержащие хотя бы одно нулевое значение.
            Поменять местами средние столбцы.
            
            Выводить матрицу после каждого преобразования.
*/

namespace Task01Page33
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
        
        /// <summary>
        /// Changes the max element in each row to negative.
        /// </summary>
        /// <param name="matrix">Matrix.</param>
        static void ChangeMaxInRowToNegative(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                int maxIndex = 0;
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    if (Math.Abs(matrix[i, maxIndex]) < Math.Abs(matrix[i, j]))
                        maxIndex = j;
                }
                matrix[i, maxIndex] *= -1;
            }
        }

        /// <summary>
        /// Adds the zero rows after rows of matrix with even indexes.
        /// </summary>
        /// <param name="matrix">Matrix.</param>
        static void AddZeroRowsAfterEvenRows(ref int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            
            int evenRows = (n - 1) / 2 + 1;
            int[,] tmp = new int[evenRows + n, m];

            int k = 0;
            for (int i = 0; i < n; i += 2)
            {
                for (int j = 0; j < m; ++j)
                {
                    tmp[k, j] = matrix[i, j];
                    if (k + 1 < evenRows + n)
                        tmp[k + 1, j] = 0;
                    if ((k + 2 < evenRows + n) && (i + 1 < n))
                        tmp[k + 2, j] = matrix[i + 1, j];
                }
                k += 3;
            }
            matrix = tmp;
        }

        /// <summary>
        /// Deletes the rows of matrix with zero.
        /// </summary>
        /// <param name="matrix">Matrix.</param>
        static void DeleteRowsWithZero(ref int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);

            int rows = 0;
            int[,] tmp = new int[n, m];
            for (int i = 0; i < n; ++i)
            {
                bool haveZero = false;
                for (int j = 0; j < m; ++j)
                {
                    tmp[rows, j] = matrix[i, j];
                    if (matrix[i, j] == 0)
                    {
                        haveZero = true;
                        break;
                    }
                }
                if (!haveZero)
                    rows++;
            }
            matrix = new int[rows, m];
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < m; ++j)
                    matrix[i, j] = tmp[i, j];
            }
            
        }
        
        /// <summary>
        /// Swaps two variables.
        /// </summary>
        /// <param name="a">First variable.</param>
        /// <param name="b">Second variable.</param>
        static void Swap<T>(ref T a, ref T b)
        {
            T c = a;
            a = b;
            b = c;
        }
        
        /// <summary>
        /// Swaps two columns.
        /// </summary>
        /// <param name="matrix">Matrix.</param>
        /// <param name="a">Index of the first column.</param>
        /// <param name="b">Index of the second column.</param>
        static void SwapColumns(int[,] matrix, int a, int b)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
                Swap(ref matrix[i, a], ref matrix[i, b]);
        }
        
        static void Main()
        {
            const int lowerBound = -100, upperBound = 99;
            do
            {
                Console.Clear();

                int n = InputVar("number of rows in matrix", 1, int.MaxValue, (x, y) => x < y, (x, y) => x > y);
                int m = InputVar("number of columns in matrix", 1, int.MaxValue, (x, y) => x < y, (x, y) => x > y);

                int[,] matrix = CreateMatrix(n, m, lowerBound, upperBound);
                Console.WriteLine($"Matrix:\n{MatrixToString(matrix)}");

                ChangeMaxInRowToNegative(matrix);
                Console.WriteLine($"Max elements in each row are changed to negative:\n{MatrixToString(matrix)}");

                AddZeroRowsAfterEvenRows(ref matrix);
                Console.WriteLine($"Rows of zeros are added after rows with even indexes:\n{MatrixToString(matrix)}");

                DeleteRowsWithZero(ref matrix);
                Console.WriteLine($"Rows with zeros are deleted:\n{MatrixToString(matrix)}");

                SwapColumns(matrix, (n - 1) / 2, n / 2);
                Console.WriteLine($"Middle columns are swapped:\n{MatrixToString(matrix)}");
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
