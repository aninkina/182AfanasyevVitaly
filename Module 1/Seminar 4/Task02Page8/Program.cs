using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
            Пользователь последовательно вводит целые числа. Для хранения полученных
            чисел в программе используется одна переменная. Окончание ввода чисел
            определяется либо желанием пользователя, либо когда сумма уже введённых
            отрицательных чисел становится меньше -1000. Определить и вывести на
            экран среднее арифметическое отрицательных чисел.
*/

namespace Task02Page8
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


        /// <summary>
        /// Inputs integers while sum of negative numbers >= -1000.
        /// </summary>
        /// <returns>Sum of negative numbers and number of them.</returns>
        static (int, int) InputNumbers()
        {
            int sumNeg = 0, countNeg = 0, a;
            bool inputing = true;
            do
            {
                Console.WriteLine("Enter integer. Enter \"stop\" to stop.");
                string input = Console.ReadLine();
                if (input == "stop")
                    inputing = false;
                else if (int.TryParse(input, out a))
                {
                    if (a < 0)
                    {
                        sumNeg += a;
                        countNeg++;
                    }
                }
                else
                    Console.WriteLine("Invalid input format! Try again!");
            } while (inputing && (sumNeg >= -1000));
            return (sumNeg, countNeg);
        }

        static void Main()
        {
            do
            {
                Console.Clear();

                (int, int) input = InputNumbers();
                if (input.Item2 > 0)
                    Console.WriteLine($"Average of negative numbers: {(double)input.Item1 / input.Item2}");
                else
                    Console.WriteLine("No negative numbers was inputed!");
                Console.WriteLine("Press ESC to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}