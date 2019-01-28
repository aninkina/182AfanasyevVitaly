using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Checker.InputChecker;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 8
*/

namespace Task08
{
    class Program
    {
        static int SortByEvennessOfPhotosensitivity(Plant x, Plant y)
        {
            return (int)x.Photosensitivity % 2 > (int)y.Photosensitivity % 2 ? 1 : -1;
        }
    
        /// <summary>
        /// Generates random double [leftBorder; rightBorder].
        /// </summary>
        /// <returns>The random double.</returns>
        /// <param name="leftBorder">Left border.</param>
        /// <param name="rightBorder">Right border.</param>
        static double RandomDouble(int leftBorder, int rightBorder)
        {
            if (leftBorder >= rightBorder)
                throw new ArgumentException("Left border of generating can't be equal or greater than right border.");
            return rnd.Next(leftBorder, rightBorder) + rnd.NextDouble();
        }
    
        static Random rnd = new Random();
        
        static void Main()
        {
            const int maxArraySize = 100;
            Comparison<Plant> comparison = SortByEvennessOfPhotosensitivity;
            do
            {
                Console.Clear();

                int n = InputVar<int>($"size of array (1 - {maxArraySize})", x => (x > 0) && (x <= maxArraySize));
                Plant[] a = new Plant[n];
                for (int i = 0; i < n; ++i)
                {
                    a[i] = new Plant(RandomDouble(25, 100), RandomDouble(0, 100), RandomDouble(0, 80));
                }
                Console.WriteLine("Plants information:");
                Array.ForEach(a, x => Console.WriteLine($"\t{x}"));
                
                Array.Sort(a, delegate (Plant x, Plant y) { return x.Growth < y.Growth ? 1 : -1; } );
                Console.WriteLine("Sorted by growth in descending order:");
                Array.ForEach(a, x => Console.WriteLine($"\t{x}"));
                
                Array.Sort(a, (x, y) => x.Frostresistance > y.Frostresistance ? 1 : -1);
                Console.WriteLine("Sorted by frostrestistance in ascending order:");
                Array.ForEach(a, x => Console.WriteLine($"\t{x}"));

                Array.Sort(a, comparison);
                Console.WriteLine("Sorted by evenness of photosensitivity:");
                Array.ForEach(a, x => Console.WriteLine($"\t{x}"));
                
                a = Array.ConvertAll(a, x => new Plant(x.Growth, x.Photosensitivity, x.Frostresistance / (((int)x.Frostresistance % 2 == 0) ? 3 : 2)));
                Console.WriteLine("Modified frostresistance:");
                Array.ForEach(a, x => Console.WriteLine($"\t{x}"));

                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}