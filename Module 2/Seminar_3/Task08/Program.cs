using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 8
*/

namespace Task08
{
    class Point
    {
        double x, y;
        
        public double X { get; set; }
        public double Y { get; set; }

        public Point() : this(0, 0) { }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Finds distance to point p.
        /// </summary>
        /// <returns>Distance to point p.</returns>
        /// <param name="p">Point.</param>
        public double DistanceToPoint(Point p)
        {
            return Math.Sqrt(Math.Pow(p.X - X, 2) + Math.Pow(p.Y - Y, 2)); 
        }

        public override string ToString()
        {
            return $"({X:F3}; {Y:F3})";
        }
    }

    class Triangle
    {
        Point[] points = new Point[3];
        
        public Point[] Points { get => points; set => points = value.Length == 3 ? (Point[])value.Clone() : points; }
        
        public double A { get => points[0].DistanceToPoint(points[1]); }
        public double B { get => points[1].DistanceToPoint(points[2]); }
        public double C { get => points[2].DistanceToPoint(points[0]); }

        public Triangle() : this(0, 0, 0, 0, 0, 0) { }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3) :
            this(new Point(x1, y1), new Point(x2, y2), new Point(x3, y3))
        { }
        
        public Triangle(Point p1, Point p2, Point p3)
        {
            points[0] = p1;
            points[1] = p2;
            points[2] = p3;
        }
        
        public double Perimeter
        {
            get
            {
                return A + B + C;
            }
        }
        
        public double Area
        {
            get
            {
                double p = Perimeter / 2;
                return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            }
        }

        public override string ToString()
        {
            return $"P1: {points[0]}, P2: {points[1]}, P3: {points[2]}";
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

                Triangle[] triangles = new Triangle[n];
                for (int i = 0; i < n; ++i)
                {
                    Point p1 = new Point(rnd.Next(-10, 10) + rnd.NextDouble(), rnd.Next(-10, 10) + rnd.NextDouble());
                    Point p2 = new Point(rnd.Next(-10, 10) + rnd.NextDouble(), rnd.Next(-10, 10) + rnd.NextDouble());
                    Point p3 = new Point(rnd.Next(-10, 10) + rnd.NextDouble(), rnd.Next(-10, 10) + rnd.NextDouble());
                    triangles[i] = new Triangle(p1, p2, p3);
                }

                foreach (Triangle t in triangles)
                    Console.WriteLine("\t" + t + $". Perimeter: {t.Perimeter:F3}, Area: {t.Area:F3}");

                Array.Sort(triangles, (x, y) => x.Area < y.Area ? 1 : -1);
                Console.WriteLine("Sorted by area:");
                foreach (Triangle t in triangles)
                    Console.WriteLine("\t" + t + $". Perimeter: {t.Perimeter:F3}, Area: {t.Area:F3}");
                    
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
