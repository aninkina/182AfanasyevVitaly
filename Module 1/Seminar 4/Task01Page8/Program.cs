using System;
using System.Collections.Generic;
/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
            
*/

namespace Task01Page8
{
    delegate bool Comp<T>(T x, T y);

    class Program
    {
        /// <summary>
        /// Inputs and parses the int.
        /// </summary>
        /// <returns>The int.</returns>
        /// <param name="input">Input.</param>
        /// <param name="minValue">Minimum value.</param>
        /// <param name="maxValue">Max value.</param>
        public static int InputInt(string input,
                            int minValue, int maxValue,
                            Comp<int> CompMin, Comp<int> CompMax)
        {
            Console.WriteLine($"Enter {input} :");
            int result;
            while (!int.TryParse(Console.ReadLine(), out result) || (result < minValue) || (result > maxValue))
            {
                Console.WriteLine("Invalid input format! Try again!");
                Console.WriteLine($"Enter {input} :");
            }
            return result;
        }

        public static int InputInt(string input)
        {
            return InputInt(input, int.MinValue, int.MaxValue, (x, y) => x < y, (x, y) => x > y);
        }

        /// <summary>
        /// Inputs and parses the double.
        /// </summary>
        /// <returns>The double.</returns>
        /// <param name="input">Input.</param>
        /// <param name="minValue">Minimum value.</param>
        /// <param name="maxValue">Max value.</param>
        public static double InputDouble(string input,
                                  double minValue, double maxValue,
                                  Comp<double> compMin, Comp<double> compMax)
        {
            Console.WriteLine($"Enter {input} :");
            double result;
            while (!double.TryParse(Console.ReadLine(), out result) || (compMin(result, minValue)) || (compMax(result, maxValue)))
            {
                Console.WriteLine("Invalid input format! Try again!");
                Console.WriteLine($"Enter {input} :");
            }
            return result;
        }

        public static double InputDouble(string input)
        {
            return InputDouble(input, double.MinValue, double.MaxValue, (x, y) => x < y, (x, y) => x > y);
        }

        /// <summary>
        /// Inputs and parses the char.
        /// </summary>
        /// <returns>The char.</returns>
        public static char InputChar()
        {
            Console.WriteLine("Enter symbol:");
            char c;
            while (!char.TryParse(Console.ReadLine(), out c))
            {
                Console.WriteLine("Invalid input format! Try again!");
                Console.WriteLine("Enter symbol:");
            }
            return c;
        }

        /// <summary>
        /// Inputs and parses the uint.
        /// </summary>
        /// <returns>The uint.</returns>
        /// <param name="input">Input.</param>
        /// <param name="minValue">Minimum value.</param>
        /// <param name="maxValue">Max value.</param>
        public static uint InputUInt(string input,
                            uint minValue, uint maxValue,
                            Comp<uint> CompMin, Comp<uint> CompMax)
        {
            Console.WriteLine($"Enter {input} :");
            uint result;
            while (!uint.TryParse(Console.ReadLine(), out result) || (result < minValue) || (result > maxValue))
            {
                Console.WriteLine("Invalid input format! Try again!");
                Console.WriteLine($"Enter {input} :");
            }
            return result;
        }

        public static uint InputUInt(string input)
        {
            return InputUInt(input, uint.MinValue, uint.MaxValue, (x, y) => x < y, (x, y) => x > y);
        }

        static void Swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        static bool CheckSolve(int a, int b, int c)
        {
            return a * a + b * b == c * c;
        }

        /// <summary>
        /// Finds all solutions of a^2 + b^2 = c^2. a, b, c = [l, r].
        /// </summary>
        /// <returns>List of solutions.</returns>
        /// <param name="l">Left border.</param>
        /// <param name="r">Right border.</param>
        static List<(int, int, int)> FindSolutions(int l = 1, int r = 20)
        {
            List<(int, int, int)> list = new List<(int, int, int)>();
            for (int a = l; a <= r; a++)
            {
                for (int b = a; b <= r; b++)
                {
                    for (int c = b; c <= r; c++)
                    {
                        if (CheckSolve(a, b, c))
                            list.Add((a, b, c));
                    }
                }
            }
            return list;
        }

        static void Main()
        {
            Console.Clear();

            List<(int, int, int)> ans = FindSolutions();
            Console.WriteLine($"{ans.Count} solutions:");
            foreach ((int, int, int) n in ans)
            {
                Console.WriteLine($"{n.Item1}^2 + {n.Item2}^2 = {n.Item3}^2");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}