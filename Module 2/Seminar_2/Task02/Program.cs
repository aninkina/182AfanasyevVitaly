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
        // Input methods

        delegate bool Compare<T>(T a, T b);

        /// <summary>
        /// Parses the input.
        /// </summary>
        /// <returns><c>true</c>, if input was parsed, <c>false</c> otherwise.</returns>
        /// <param name="input">Input.</param>
        /// <param name="result">Result.</param>
        /// <typeparam name="T">Type.</typeparam>
        static bool ParseInput<T>(string input, out T result)
        {
            bool parsed;
            if (typeof(T) == typeof(int))
            {
                int tmpResult;
                parsed = int.TryParse(input, out tmpResult);
                result = (T)(object)tmpResult;
            }
            else if (typeof(T) == typeof(double))
            {
                double tmpResult;
                parsed = double.TryParse(input, out tmpResult);
                result = (T)(object)tmpResult;
            }
            else if (typeof(T) == typeof(uint))
            {
                uint tmpResult;
                parsed = uint.TryParse(input, out tmpResult);
                result = (T)(object)tmpResult;
            }
            else if (typeof(T) == typeof(long))
            {
                long tmpResult;
                parsed = long.TryParse(input, out tmpResult);
                result = (T)(object)tmpResult;
            }
            else if (typeof(T) == typeof(byte))
            {
                byte tmpResult;
                parsed = byte.TryParse(input, out tmpResult);
                result = (T)(object)tmpResult;
            }
            else if (typeof(T) == typeof(sbyte))
            {
                sbyte tmpResult;
                parsed = sbyte.TryParse(input, out tmpResult);
                result = (T)(object)tmpResult;
            }
            else if (typeof(T) == typeof(char))
            {
                char tmpResult;
                parsed = char.TryParse(input, out tmpResult);
                result = (T)(object)tmpResult;
            }
            else
            {
                result = default(T);
                parsed = true;
            }
            return parsed;
        }

        /// <summary>
        /// Inputs and parses the variable of type T.
        /// </summary>
        /// <returns>Variable of type T.</returns>
        /// <param name="input">Input.</param>
        /// <param name="minValue">Minimum value.</param>
        /// <param name="maxValue">Maximum value.</param>
        /// <param name="compMin">Comparator for minValue.</param>
        /// <param name="compMax">Comparator for maxValue.</param>
        static T InputVar<T>(string input, T minValue, T maxValue, Compare<T> compMin, Compare<T> compMax)
        {
            Console.WriteLine($"Enter {input}:");
            T result;
            while (!ParseInput(Console.ReadLine(), out result) || compMin(result, minValue) || compMax(result, maxValue))
            {
                Console.WriteLine("Invalid input format! Try again!");
                Console.WriteLine($"Enter {input}:");
            }
            return result;
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

                double x = InputVar("coordinate X", double.MinValue, double.MaxValue, (l, r) => l < r, (l, r) => l > r);
                double y = InputVar("coordinate Y", double.MinValue, double.MaxValue, (l, r) => l < r, (l, r) => l > r);

                arr[2] = new Point(x, y);

                Array.Sort(arr, (l, r) => (l.Ro >= r.Ro ? 1 : -1));

                foreach (Point pt in arr)
                    Console.WriteLine(pt);
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}