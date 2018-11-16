using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 7
*/

namespace Task07
{
    class Point
    {
        double x, y, z;
        
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point() : this(0, 0, 0) { }

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Finds distance to point p.
        /// </summary>
        /// <returns>Distance to point p.</returns>
        /// <param name="p">Point.</param>
        public double DistanceToPoint(Point p)
        {
            return Math.Sqrt(Math.Pow(p.X - X, 2) + Math.Pow(p.Y - Y, 2) + Math.Pow(p.Z - Z, 2)); 
        }

        public override string ToString()
        {
            return $"({X:F3}; {Y:F3}; {Z:F3})";
        }
    }
    
    class Program
    {
    
        /// <summary>
        /// Checks if inputed value meets the conditions.
        /// </summary>
        /// <returns><c>true</c>, if value met the conditions, <c>false</c> otherwise.</returns>
        /// <param name="input">Input.</param>
        /// <param name="conditions">Conditions.</param>
        static bool CheckConditions<T>(T input, params Func<T, bool>[] conditions)
        {
            foreach (Func<T, bool> condition in conditions)
            {
                if (!condition.Invoke(input))
                    return false;
            }
            return true;
        }
        
        /// <summary>
        /// Inputs and parses the variable of type T.
        /// </summary>
        /// <returns>Variable of type T.</returns>
        /// <param name="input">Input.</param>
        /// <param name="conditions">Conditions.</param>
        static T InputVar<T>(string input, params Func<T, bool>[] conditions)
        {
            var parser = typeof(T).GetMethod("TryParse", new[] { typeof(string), typeof(T).MakeByRefType() });
            if (parser == null)
                throw new ApplicationException($"Invalid type {typeof(T)}");
            Console.WriteLine($"Enter {input}:");
            object[] result = { Console.ReadLine(), null};
            while (!(bool)parser.Invoke(null, result) || !CheckConditions((T)result[1], conditions))
            {
                Console.WriteLine("Invalid input format! Try again!");
                Console.WriteLine($"Enter {input}:");
                result = new object[] { Console.ReadLine(), null };
            }
            return (T)result[1];
        }
        
        static Random rnd = new Random();
        
        static void Main()
        {
            
            do
            {
                Console.Clear();

                int n = rnd.Next(5, 16);
                Console.WriteLine($"N: {n}");
                Point[] points = new Point[n];
                for (int i = 0; i < n; ++i)
                    points[i] = new Point(rnd.Next(-10, 10) + rnd.NextDouble(), rnd.Next(-10, 10) + rnd.NextDouble(), rnd.Next(-10, 10) + rnd.NextDouble());

                double minDist = points[0].DistanceToPoint(new Point(0, 0, 0));
                int min = 0;
                for (int i = 0; i < n; ++i)
                {
                    double distance = points[i].DistanceToPoint(new Point(0, 0, 0));
                    if (distance < minDist)
                    {
                        minDist = distance;
                        min = i;
                    }
                    Console.WriteLine(points[i] + $". Distance: {distance:F3}");
                }
                Console.WriteLine($"Closest point: {points[min]}. Distance: {minDist:F3}");
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
