using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 7     
*/

namespace Task07
{
    delegate double Func(double x);
    
    /// <summary>
    /// Function of one argument on the segment [xMin; xMax];
    /// </summary>
    class MyFunction
    {
        public double xMin, xMax;
        public Func f = Math.Sin;

        public MyFunction(double xMin, double xMax, Func f)
        {
            this.xMin = xMin;
            this.xMax = xMax;
            this.f = f;
        }
        
        public double this[double x]
        {
            get
            {
                return x < xMin || x > xMax ? 0 : f(x);
            }
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
            MyFunction f = new MyFunction(0, Math.PI, Math.Sin);

            double sum = 0;
            const double step = 0.000001;
            for (double i = f.xMin; i <= f.xMax; i += step)
            {
                sum += f[i];
            }
            sum *= step;
            Console.WriteLine(sum);
        }
    }
}
