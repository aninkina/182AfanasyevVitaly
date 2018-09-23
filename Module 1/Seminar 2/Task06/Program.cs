using System;

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

        static string PointLocation(Point p, double r = 10.0)
        {
            return p.X * p.X + p.Y * p.Y > r * r ? "outside" : "inside";
        }

        static void Main()
        {
            do
            { 
                Point p = new Point();
                p.X = InputDouble("X coordinate of point");
                p.Y = InputDouble("Y coordinate of point");
                Console.WriteLine("Point is {0} the circle", PointLocation(p));
                Console.WriteLine("Press ESC to exit. Press any other key to continue");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
