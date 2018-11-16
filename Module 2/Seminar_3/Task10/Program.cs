using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 10
*/

namespace Task10
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
    
    class Circle
    {
        Point center;
        double radius;
        
        public Point Center { get => center; set => center = value; }
        public double Radius { get => radius; set => radius = value; }

        public Circle() : this(0, 0, 0) { }

        public Circle(double x, double y, double radius) : this(new Point(x, y), radius) { }

        public Circle(Point center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        /// <summary>
        /// Checks if two circles intersect.
        /// </summary>
        /// <returns><c>true</c>, if circles intersect, <c>false</c>, otherwise.</returns>
        /// <param name="c">Second circle.</param>
        public bool Intersect(Circle c)
        {
            if (Center.DistanceToPoint(c.Center) < Radius)
            {
                return Center.DistanceToPoint(c.Center) >= Radius - c.Radius;
            }
            return Center.DistanceToPoint(c.Center) <= Radius + c.Radius;
        }

        public override string ToString()
        {
            return $"Center: {Center}, Radius: {Radius:F3}";
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

                int n = InputVar<int>("number of circles", x => x > 0, y => y < 1000);
                Circle[] circles = new Circle[n];
                for (int i = 0; i < n; ++i)
                    circles[i] = new Circle(rnd.Next(1, 16), rnd.Next(1, 16), rnd.Next(1, 16));

                foreach (Circle c in circles)
                    Console.WriteLine("\t" + c);

                Circle circle = new Circle(rnd.Next(1, 16), rnd.Next(1, 16), rnd.Next(1, 16));
                Console.WriteLine($"Another circle:\n\t{circle}");

                Console.WriteLine("Intersections:");
                foreach (Circle c in circles)
                    Console.WriteLine(c.Intersect(circle) ? "Yes" : "No");
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
