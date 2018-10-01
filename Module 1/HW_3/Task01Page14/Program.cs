using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
           Написать метод, вычисляющий логическое значение функции G=F(X,Y).
           Результат равен true, если точка с координатами (X,Y) попадает в фигуру G, и
           результат равен false, если точка с координатами (X,Y) не попадает в фигуру G.
           Фигура G - сектор круга радиусом R=2 в диапазоне углов -90 <= fi <=45. 
*/

namespace Task01Page14
{
    delegate bool Comp<T>(T x, T y);
    
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; } 

        public Point()
        {
            X = Program.InputDouble("X coordinate of a point");
            Y = Program.InputDouble("Y coordinate of a point");
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

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
        /// Checks if point is in sector (-90 - 45 degrees) of circle with radius 2.
        /// </summary>
        /// <returns><c>true</c>, if point is in sector, <c>false</c> otherwise.</returns>
        /// <param name="p">Point.</param>
        static bool IsInSector(Point p)
        {
            const int R = 2;
            return (Math.Pow(p.X, 2) + Math.Pow(p.Y, 2) <= Math.Pow(R, 2)) &&   // Inside the circle
                ((p.X >= 0) && (p.Y <= 0) ||    // In lower 90-degrees sector
                 (p.X >= 0) && (p.X >= p.Y));   // In upper 45-degrees sector
        }

        static void Main()
        {
            do
            {
                Console.Clear();

                Point p = new Point();
                if (IsInSector(p))
                    Console.WriteLine("Point is in sector");
                else
                    Console.WriteLine(@"Point isn't in sector");

                Console.WriteLine("Press ESC to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
