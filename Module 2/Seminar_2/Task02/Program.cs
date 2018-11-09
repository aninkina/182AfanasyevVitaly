using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 2         
*/

namespace Task02
{
    /// <summary>
    /// Point.
    /// </summary>
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public double Ro
        {
            get => X * X + Y * Y;
        }

        public double Fi
        {
            get
            {
                if ((X > 0) && (Y >= 0))
                    return Math.Atan(Y / X);
                if ((X > 0) && (Y < 0))
                    return Math.Atan(Y / X) + 2 * Math.PI;
                if (X < 0)
                    return Math.Atan(Y / X) + Math.PI;
                if (Y > 0)
                    return Math.PI / 2;
                if (Y < 0)
                    return 3 * Math.PI / 2;
                return 0;
            }
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point() : this(0, 0) { }

        public override string ToString()
        {
            return $"X = {X:F3}, Y = {Y:F3}, Ro = {Ro:F3}, Fi = {Fi:F3}";
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
        
        static void Main()
        {
            Random rnd = new Random();
            do
            {
                Console.Clear();
                Point[] arr = new Point[3];

                arr[0] = new Point(rnd.NextDouble() + rnd.Next(0, 10), rnd.NextDouble() + rnd.Next(0, 10));
                arr[1] = new Point(rnd.NextDouble() + rnd.Next(0, 10), rnd.NextDouble() + rnd.Next(0, 10));

                double x = InputVar<double>("coordinate X", l => l >= double.MinValue, r => r <= double.MaxValue);
                double y = InputVar<double>("coordinate Y", l => l >= double.MinValue, r => r <= double.MaxValue);

                arr[2] = new Point(x, y);

                Array.Sort(arr, (l, r) => (l.Ro >= r.Ro ? 1 : -1));

                foreach (Point pt in arr)
                    Console.WriteLine(pt);
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}