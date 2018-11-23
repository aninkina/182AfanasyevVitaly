using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 4
*/

namespace Task04
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

        static string GenerateName()
        {
            string s = "";
            for (int i = 0; i < 6; ++i)
                s += (char)('a' + rnd.Next(0, 26));
            return s;
        }
        
        static Shape[] ShapeArray()
        {
            int countCircles = rnd.Next(4, 5);
            int countCylinders = rnd.Next(4, 5);
            int countSpheres = rnd.Next(4, 5);
            Shape[] p = new Shape[countCircles + countCylinders + countSpheres];

            for (int i = 0; i < countCircles; ++i)
            {
                p[i] = new Circle(rnd.Next(0, 21));
            }

            for (int i = countCircles; i < countCircles + countCylinders; ++i)
            {
                p[i] = new Cylinder(rnd.Next(0, 21), rnd.Next(0, 21));
            }

            for (int i = countCircles + countCylinders; i < p.Length; ++i)
            {
                p[i] = new Sphere(rnd.Next(0, 21));
            }

            return p;
        }
        
        static void Main()
        {
            
            do
            {
                Console.Clear();

                Shape[] shapes = ShapeArray();

                Console.WriteLine("Areas:");
                foreach (Shape obj in shapes)
                    Console.WriteLine($"\t{obj.Area():F3}");

                Console.WriteLine("Shapes with areas: ");
                foreach (Shape obj in shapes)
                {
                    if (obj is Circle)
                        Console.Write("\tCircle ");
                    if (obj is Cylinder)
                        Console.Write("\tCylinder ");
                    if (obj is Sphere)
                        Console.Write("\tSphere ");
                    Console.WriteLine($"{obj.Area():F3}");
                }

                Array.Sort(shapes, (x, y) => (x is Circle) && (y is Cylinder)
                    || (x is Circle) && (y is Sphere)
                    || (x is Cylinder) && (y is Sphere) ? -1 : 1);

                Console.WriteLine("Sorted by type: ");
                foreach (Shape obj in shapes)
                {
                    if (obj is Circle)
                        Console.WriteLine("\tCircle");
                    if (obj is Cylinder)
                        Console.WriteLine("\tCylinder");
                    if (obj is Sphere)
                        Console.WriteLine("\tSphere");
                }
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
