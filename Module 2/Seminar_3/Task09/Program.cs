using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 9
*/

namespace Task09
{
    class LinearEquation
    {
        double a, b, c;
        
        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }
        public double C { get => c; set => c = value; }

        public LinearEquation() : this(1, 0, 0) { }

        public LinearEquation(double a, double b, double c)
        {
            if (a == 0)
                throw new ArgumentException("Not a linear equation");
            A = a;
            B = b;
            C = c;
        }

        public double Solve { get => (C - B) / A; }

        public override string ToString()
        {
            return $"A = {A:F3}, B = {B:F3}, C = {C:F3}";
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

                int n = InputVar<int>("number of linear equations", x => x > 0, y => y < 1000);
                LinearEquation[] equations = new LinearEquation[n];
                for (int i = 0; i < n; ++i)
                {
                    double a = rnd.Next(-10, 11);
                    if (a == 0)
                        a++;
                    equations[i] = new LinearEquation(a, rnd.Next(-10, 11), rnd.Next(-10, 11));
                }

                foreach (LinearEquation eq in equations)
                    Console.WriteLine("\t" + eq + $". X = {eq.Solve:F3}");

                Array.Sort(equations, (x, y) => x.Solve > y.Solve ? 1 : -1);
                Console.WriteLine("Sorted equations:");
                foreach (LinearEquation eq in equations)
                    Console.WriteLine("\t" + eq + $". X = {eq.Solve:F3}");
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
