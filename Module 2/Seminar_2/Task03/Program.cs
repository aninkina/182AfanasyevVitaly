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
            ConsoleColor fgBase = Console.ForegroundColor;
            int n = 0;
            Polygon[] p = new Polygon[n];
            uint sides;
            double radius;
            do
            {
                sides = InputVar<uint>("number of sides", x => x >= 0, y => y <= 1000);
                radius = InputVar<double>("radius", x => x >= 0, y => y <= 1000);
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
