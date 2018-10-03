using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
            
*/

namespace Task03
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
        /// Finds perimeter and area of a triangle with sides x, y and z.
        /// </summary>
        /// <returns><c>true</c>, if triangle with sides x, y and z exists, <c>false</c> otherwise.</returns>
        /// <param name="x">Length of the first side of a triangle.</param>
        /// <param name="y">Length of the second side of a triangle.</param>
        /// <param name="z">Length of the third side of a triangle.</param>
        /// <param name="p">Perimeter.</param>
        /// <param name="s">Area.</param>
        static bool Triangle(double x, double y, double z, out double p, out double s)
        {
			p = s = 0;
            if ((x + y <= z) || (x + z <= y) || (y + z <= x))
                return false;
			p = x + y + z;
			s = Math.Sqrt(p / 2 * (p / 2 - x) * (p / 2 - y) * (p / 2 - z));
            return true; 
        }
        
        static void Main()
        {
            do
            {
                Console.Clear();

				double x = InputDouble("length of the first side of a triangle", 0, double.MaxValue, (a, b) => a <= b, (a, b) => a > b);
                double y = InputDouble("length of the second side of a triangle", 0, double.MaxValue, (a, b) => a <= b, (a, b) => a > b);
                double z = InputDouble("length of the third side of a triangle", 0, double.MaxValue, (a, b) => a <= b, (a, b) => a > b);
				double p, s;
                
                if (Triangle(x, y, z, out p, out s))
                    Console.WriteLine($"Perimeter: {p}\nArea: {s}");
                else
                    Console.WriteLine("Error! This triangle doesn\'t exist!");
                
                Console.WriteLine("Press ESC to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}