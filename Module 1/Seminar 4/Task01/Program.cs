using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
            
*/

namespace Task02
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
        /// Cycle shifts latin lower symbol (a - z) 4 positions to right.
        /// </summary>
        /// <returns><c>true</c>, if ch is a latin lower symbol (a - z), <c>false</c> otherwise.</returns>
        /// <param name="ch">Symbol.</param>
		static bool Shift(ref char ch)
        {
            if ((ch < 'a') || (ch > 'z'))
                return false;
            ch = (char)(((int)ch + 4 - (int)'a') % 26 + (int)'a');
            return true;
        }

        static void Main()
        {
            do
            {
                Console.Clear();

                char c = InputChar();

                if (Shift(ref c))
                    Console.WriteLine(c);
                else
                    Console.WriteLine("Error! Symbol isn\'t latin lower symbol (a - z)!");

                Console.WriteLine("Press ESC to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}