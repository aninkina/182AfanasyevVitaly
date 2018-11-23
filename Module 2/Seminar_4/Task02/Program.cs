using System;
using Figures;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 2
*/

namespace Task02
{
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

        static Point[] FigArray()
        {
            int countCircles = rnd.Next(0, 11);
            int countSquares = rnd.Next(0, 11);
            int countTriangles = rnd.Next(0, 11);
            Point[] p = new Point[countCircles + countSquares + countTriangles];
            
            for (int i = 0; i < countCircles; ++i)
                p[i] = new Circle(rnd.Next(10, 99) + rnd.NextDouble(),
                    rnd.Next(10, 99) + rnd.NextDouble(),
                    rnd.Next(10, 99) + rnd.NextDouble());
                    
            for (int i = countCircles; i < countCircles + countSquares; ++i)
                p[i] = new Square(rnd.Next(10, 99) + rnd.NextDouble(),
                    rnd.Next(10, 99) + rnd.NextDouble(),
                    rnd.Next(10, 99) + rnd.NextDouble());
            
            for (int i = countCircles + countSquares; i < p.Length; ++i)
                p[i] = new Triangle(rnd.Next(10, 99) + rnd.NextDouble(),
                    rnd.Next(10, 99) + rnd.NextDouble(),
                    rnd.Next(10, 99) + rnd.NextDouble());

            return p;
        }

        static double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        static double Distance(Point p)
        {
            return Distance(p, new Point(0, 0));
        }
        
        static void Main()
        {
            
            do
            {
                Console.Clear();

                Point[] p = FigArray();

                double averageArea = 0, averageLen = 0;
                int countCircles = 0, countSquares = 0, countTriangles = 0;
                foreach (Point obj in p)
                {
                    if (obj is Circle)
                        countCircles++;
                    if (obj is Square)
                        countSquares++;
                    if (obj is Triangle)
                        countTriangles++;
                    averageArea += obj.Area;
                    averageLen += obj.Len;
                }
                if (p.Length != 0)
                {
                    averageArea /= p.Length;
                    averageLen /= p.Length;
                }
                
                Console.WriteLine($"Circles: {countCircles}, Squares: {countSquares}, Triangles: {countTriangles}");
                Console.WriteLine($"Average area: {averageArea:F3}, Average Length: {averageLen:F3}");

                Array.Sort(p, (x, y) => x.Area > y.Area ? 1 : -1);
                Console.WriteLine("Sorted by area:");
                foreach (Point obj in p)
                    Console.WriteLine($"\tArea: {obj.Area:F3}");

                Array.Sort(p, (x, y) => Distance(x) > Distance(y) ? 1 : -1);
                Console.WriteLine("Sorted by distance to (0;0):");
                foreach (Point obj in p)
                    Console.WriteLine($"\tDistance: {Distance(obj):F3}");
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
