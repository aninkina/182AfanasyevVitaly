using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
            Трехзначным целым числом кодируется номер аудитории в учебном корпусе. 
            Старшая цифра обозначают номер этажа, а две младшие – номер аудитории на этаже. 
            Из трех аудиторий определить и вывести на экран ту аудиторию, 
            которая имеет минимальный номер внутри этажа. 
            Если таких аудиторий несколько - вывести любую из них. 
*/

namespace Task04Page14
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
        /// Swaps two variables of the same type T.
        /// </summary>
        /// <param name="a">First variable.<param>
        /// <param name="b">Second variable.</param>
        static void Swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        /// <summary>
        /// Converts auditorium code to auditorium number on the floor.
        /// </summary>
        /// <returns>Auditorium number.</returns>
        /// <param name="code">Code.</param>
        static int CodeToNum(int code)
        {
            return code % 100;
        }

        /// <summary>
        /// Finds the minimal floor-number auditorium of three.
        /// </summary>
        /// <returns>Code of the minimal auditorium.</returns>
        /// <param name="code1">Code of the first auditorium.</param>
        /// <param name="code2">Code of the second auditorium.</param>
        /// <param name="code3">Code of the third auditorium.</param>
        static int FindMinAuditorium(int code1, int code2, int code3)
        {
            int num1 = CodeToNum(code1), num2 = CodeToNum(code2), num3 = CodeToNum(code3);
            if ((num1 <= num2) && (num1 <= num3))
                return code1;
            if ((num2 <= num1) && (num2 <= num3))
                return code2;
            return code3;
        }

        static void Main()
        {
            do
            {
                Console.Clear();

                int code1 = InputInt("first auditorium code ABC(A - floor, BC - auditorium number)");
                int code2 = InputInt("second auditorium code ABC(A - floor, BC - auditorium number)");
                int code3 = InputInt("third auditorium code ABC(A - floor, BC - auditorium number)");
                
                int result = FindMinAuditorium(code1, code2, code3);
                Console.WriteLine($"Minimal auditorium: {result}");

                Console.WriteLine("Press ESC to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
