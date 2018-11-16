using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 11
*/

namespace Task11
{
    class GeometricProgression
    {
        double _start;
        double _increment;

        public GeometricProgression() : this(0, 1) { }

        public GeometricProgression(double start, double increment)
        {
            _start = start;
            _increment = increment;
        }
        
        public double this[int index]
        {
            get
            {
                if (index == 0)
                    return 0;
                return _start * Math.Pow(_increment, index - 1);
            }
        }

        public override string ToString()
        {
            return $"Start = {_start:F3}, Increment = {_increment:F3}";
        }

        /// <summary>
        /// Returns sum of n elements of arithmetic sequence.
        /// </summary>
        /// <returns>The sum.</returns>
        /// <param name="n">Number of elements.</param>
        public double GetSum(int n)
        {
            if (_increment == 1)
                return _start * n;
            return _start * (1 - Math.Pow(_increment, n)) / (1 - _increment);
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
                
                GeometricProgression progressionElement = 
                    new GeometricProgression(rnd.Next(0, 11) + rnd.NextDouble(), rnd.Next(0, 6) + rnd.NextDouble() + 0.00000001);
                Console.WriteLine($"Progression element: {progressionElement}");
                
                int n = rnd.Next(5, 16);
                Console.WriteLine($"N: {n}");
                GeometricProgression[] progressions = new GeometricProgression[n];
                for (int i = 0; i < n; ++i)
                    progressions[i] = 
                        new GeometricProgression(rnd.Next(0, 11) + rnd.NextDouble(), rnd.Next(0, 6) + rnd.NextDouble() + 0.00000001);
                
                Console.WriteLine("Progressions:");
                foreach (var pr in progressions)
                    Console.WriteLine("\t" + pr);
                
                int step = rnd.Next(3, 16);
                Console.WriteLine($"Step: {step}");
                
                Console.WriteLine("Sequences[i][step] > SequenceElement[step]");
                foreach (var pr in progressions)
                {
                    if (pr[step] > progressionElement[step])
                        Console.WriteLine("\t" + pr);
                }
                
                Console.WriteLine("Sums: ");
                foreach (var pr in progressions)
                {
                    Console.WriteLine($"\t{pr.GetSum(step):F3}");
                }
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
