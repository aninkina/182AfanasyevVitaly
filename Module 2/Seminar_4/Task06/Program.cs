using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 6
*/

namespace Task06
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

        static double Rectangle(Integrand f, int steps)
        {
            double step = (f.RightBound - f.LeftBound) / steps;
            double sum = 0;
            for (int i = 0; i < steps; ++i)
            {
                sum += f.Function(f.LeftBound + step / 2 + i * step);
            }
            return sum * step;
        }

        static double Trapeze(Integrand f, int steps)
        {
            double step = (f.RightBound - f.LeftBound) / steps;
            double sum = 0;
            double i;
            for (i = f.LeftBound; i + step <= f.RightBound; i += step)
            {
                sum += step * (f.Function(i) + f.Function(i + step)) / 2;
            }
            if (i != f.RightBound)
                sum +=  (f.RightBound - i) * (f.Function(i) + f.Function(f.RightBound)) / 2;
            return sum;
        }
        
        static void Main()
        {
            
            do
            {
                Console.Clear();

                Console.WriteLine($"Integral 1(rectangle) : {Rectangle(new Func1(-1, 2), 20):F3}");
                Console.WriteLine($"Integral 2(rectangle) : {Rectangle(new Func2(0, 0.5), 20):F3}");
                Console.WriteLine($"Integral 3(rectangle) : {Rectangle(new Func3(-1, 1), 20):F3}");
                
                Console.WriteLine($"Integral 1(trapeze) : {Trapeze(new Func1(-1, 2), 20):F3}");
                Console.WriteLine($"Integral 2(trapeze) : {Trapeze(new Func2(0, 0.5), 20):F3}");
                Console.WriteLine($"Integral 3(trapeze) : {Trapeze(new Func3(-1, 1), 20):F3}");
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
