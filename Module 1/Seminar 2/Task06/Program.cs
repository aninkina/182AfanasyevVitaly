using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
           Задан круг с центром в начале координат и радиусом R = 10.
           Ввести координаты точки и вывести сообщение:
           "Точка внутри круга!" или "Точка вне круга!".
           Предусмотреть проверку входных данных и цикл повторения решения.
*/

namespace Task06
{
    struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    class Program
    {
        static double InputDouble(string input, double minValue = double.MinValue, double maxValue = double.MaxValue)
        {
            Console.WriteLine("Enter " + input + ": ");
            double result;
            while (!double.TryParse(Console.ReadLine(), out result) || (result < minValue) || (result > maxValue))
            {
                Console.WriteLine("Invalid input format! Try again");
            }
            return result;
        }

        static string PointLocation(Point p, double R)
        {
            return p.X * p.X + p.Y * p.Y > R * R ? "outside" : "inside";
        }

        static void Main()
        {
            do
            {
                const double R = 10;
                Point p = new Point();
                p.X = InputDouble("X coordinate of point");
                p.Y = InputDouble("Y coordinate of point");
                Console.WriteLine("Point is {0} the circle!", PointLocation(p, R));
                Console.WriteLine("Press ESC to exit. Press any other key to continue");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
