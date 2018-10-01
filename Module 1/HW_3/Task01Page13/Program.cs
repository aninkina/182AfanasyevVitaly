using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
           Написать метод, находящий трехзначное десятичное число s, 
           все цифры которого одинаковы и которое представляет собой сумму первых
           членов натурального ряда, то есть s = 1+2+3+4+…
           Вывести полученное число, количество членов ряда и условное
           изображение соответствующей суммы, в которой указаны первые три 
           и последние три члена, а средние члены обозначены многоточием. 
*/


namespace Task01Page13
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
        /// Sums numbers from 1 to n
        /// </summary>
        /// <returns>The sum.</returns>
        /// <param name="n">N.</param>
        static int SumAryphm(int n)
        {
            return (1 + n) * n / 2;
        }

        /// <summary>
        /// Checks if all digits of three-digit number are equal
        /// </summary>
        /// <returns><c>true</c>, if number is three-digit and all digits are equal, <c>false</c> otherwise.</returns>
        /// <param name="x">The x coordinate.</param>
        static bool ThreeDigitEquals(int x)
        {
            if (x < 100 || x > 999)
                return false;
            return (x / 100) == (x / 10 % 10) && (x / 100) == (x % 10);
		}

        /// <summary>
        /// Finds equal-digit three-digit number, that equals sum from 1 to N.
        /// </summary>
        /// <returns>N</returns>
        static int FindThreeDigit()
        {
            int result = 1;
            while (!ThreeDigitEquals(SumAryphm(result)))
            {
                result++;
            }
            return result;
        }

        static void Main()
        {
            int result = FindThreeDigit();

            Console.WriteLine($"1+2+3+...+{result - 2}+{result - 1}+{result}");

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
