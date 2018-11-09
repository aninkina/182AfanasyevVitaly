using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: Домашнее задание 1
*/

namespace Task01HW
{
    /// <summary>
    /// Circle.
    /// </summary>
    class Circle
    {
        double _r;
        
        public double R
        {
            get => _r;
            
            set
            {
                if (value >= 0)
                    _r = value;
                else
                    throw new ArgumentException("Radius is not positive");
            }
        }
        
        public Circle()
        {
            R = 0;
        }

        public Circle(double r)
        {
            R = r;
        }

        public double S { get => Math.PI * R * R; }
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
            do
            {
                Console.Clear();

                double rMin = InputVar<double>("minimal radius", x => x >= 0, y => y < double.MaxValue);
                double rMax = InputVar<double>("maximum radius", x => x >= rMin, y => y <= double.MaxValue);
                double delta = InputVar<double>("delta", x => x > 0, y => y <= double.MaxValue);
 
                for (Circle c = new Circle(rMin); c.R <= rMax; c.R += delta)
                {
                    Console.WriteLine($"R = {c.R:F3}, S = {c.S:F3}");
                }

                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
