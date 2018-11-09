using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: Домашнее задание 3
*/

namespace Task03HW
{
    /// <summary>
    /// Complex number.
    /// </summary>
    class Complex
    {
        double a, b;
        
        public double Re { get => a; set => a = value; }
        public double Im { get => b; set => b = value; }
        
        public double Abs { get => Math.Sqrt(Re * Re + Im * Im); }
        public double Arg 
        { 
            get
            {
                if ((Re > 0) && (Im >= 0))
                    return Math.Atan(Im / Re);
                if ((Re > 0) && (Im < 0))
                    return Math.Atan(Im / Re) + 2 * Math.PI;
                if (Re < 0)
                    return Math.Atan(Im / Re) + Math.PI;
                if (Im > 0)
                    return Math.PI / 2;
                if (Im < 0)
                    return 3 * Math.PI / 2;
                return 0;
            }
        }

        public Complex(double a, double b)
        {
            Re = a;
            Im = b;
        }

        public Complex(Complex obj)
        {
            Re = obj.Re;
            Im = obj.Im;
        }

        public override string ToString()
        {
            return $"Re = {Re:F3}, Im = {Im:F3}";
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.Re + b.Re, a.Im + b.Im);
        }
        
        public static Complex operator +(Complex a, double b)
        {
            return new Complex(a.Re + b, a.Im);
        }
        
        public static Complex operator +(double b, Complex a)
        {
            return new Complex(a.Re + b, a.Im);
        }
        
        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.Re - b.Re, a.Im - b.Im);
        }
        
        public static Complex operator -(Complex a, double b)
        {
            return new Complex(a.Re - b, a.Im);
        }
        
        public static Complex operator -(double b, Complex a)
        {
            return new Complex(b - a.Re, a.Im);
        }
        
        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(a.Re * b.Re - a.Im * b.Im, a.Re * b.Im + a.Im * b.Re);
        }
        
        public static Complex operator *(Complex a, double b)
        {
            return new Complex(a.Re * b, a.Im * b);
        }
        
        public static Complex operator *(double b, Complex a)
        {
            return new Complex(a.Re * b, a.Im * b);
        }
        
        public static Complex operator /(Complex a, Complex b)
        {
            if (b.Re * b.Re + b.Im * b.Im == 0)
                throw new DivideByZeroException();
            return new Complex((a.Re * b.Re + a.Im * b.Im) / (b.Re * b.Re + b.Im * b.Im), (a.Im * b.Re - a.Re * b.Im) / (b.Re * b.Re + b.Im * b.Im));
        }
        
        public static Complex operator /(Complex a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            return new Complex(a.Re / b, a.Im / b);
        }
        
        public static Complex operator /(double b, Complex a)
        {
            if ((a.Re == 0) || (a.Im == 0))
                throw new DivideByZeroException();
            return new Complex(b / a.Re, b / a.Im);
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
            Random rnd = new Random();
            do
            {
                Console.Clear();

                Complex a = new Complex(rnd.NextDouble() + rnd.Next(0, 10), rnd.NextDouble() + rnd.Next(0, 10));
                Complex b = new Complex(rnd.NextDouble() + rnd.Next(0, 10), rnd.NextDouble() + rnd.Next(0, 10));
                double c = rnd.Next(1, 10);
                
                Console.WriteLine($"A: {a}");
                Console.WriteLine($"B: {b}");
                Console.WriteLine($"C: {c:F3}");
                Console.WriteLine($"A + B: {a + b}");
                Console.WriteLine($"A - B: {a - b}");
                Console.WriteLine($"A * B: {a * b}");
                Console.WriteLine($"A / B: {a / b}");
                Console.WriteLine($"C + A: {c + a}");
                Console.WriteLine($"A + C: {a + c}");
                Console.WriteLine($"C - A: {c - a}");
                Console.WriteLine($"A - C: {a - c}");
                Console.WriteLine($"C * A: {c * a}");
                Console.WriteLine($"A * C: {a * c}");
                Console.WriteLine($"C / A: {c / a}");
                Console.WriteLine($"A / C: {a / c}");

                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
