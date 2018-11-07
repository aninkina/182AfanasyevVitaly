using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 3        
*/

namespace Task03
{   
    /// <summary>
    /// Polygon.
    /// </summary>
    public class Polygon
    {
        public uint Sides { get; set; }
        public double Radius { get; set; }
        
        public double Perimeter
        {
            get
            {
                return 2 * Radius * Sides * Math.Tan(Math.PI / Sides);
            }
        }
        
        public double Area
        {
            get
            {
                return Perimeter * Radius / 2;
            }
        }
        
        public Polygon(uint sides = 0, double radius = 0)
        {
            this.Sides = sides;
            this.Radius = radius;
        }

        public override string ToString()
        {
            return $"Sides = {Sides}, Radius = {Radius:F3}, Perimeter = {Perimeter:F3}, Area = {Area:F3}";
        }
    }  

    class Program
    {
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
            ConsoleColor fgBase = Console.ForegroundColor;
            int n = 0;
            Polygon[] p = new Polygon[n];
            uint sides;
            double radius;
            do
            {
                sides = InputVar<uint>("number of sides", 0, 1000, (x, y) => x < y, (x, y) => x > y);
                radius = InputVar("radius", 0, 1000, (x, y) => x < y, (x, y) => x > y);
                if ((sides != 0) || (radius != 0))
                {
                    if ((sides < 3) || (radius == 0))
                        Console.WriteLine("Invalid input format! Try again!");
                    else
                    {
                        n++;
                        Array.Resize(ref p, n);
                        p[n - 1] = new Polygon(sides, radius);
                    }
                }

                int min = 0, max = 0;
                for (int i = 0; i < n; ++i)
                {
                    if (p[i].Area < p[min].Area) min = i;
                    if (p[i].Area > p[max].Area) max = i;
                }
                for (int i = 0; i < n; ++i)
                {
                    if (n == 1)
                        Console.WriteLine(p[i]);
                    else
                    {
                        if (i == min)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else if (i == max)
                            Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(p[i]);
                        Console.ForegroundColor = fgBase;
                    }
                }
            } while ((sides != 0) || (radius != 0));
        }
    }
}
