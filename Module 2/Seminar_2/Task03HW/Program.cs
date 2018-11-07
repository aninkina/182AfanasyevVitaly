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
            return new Complex((a.Re * b.Re + a.Im * b.Im) / (b.Re * b.Re + b.Im * b.Im), (a.Im * b.Re - a.Re * b.Im) / (b.Re * b.Re + b.Im * b.Im));
        }
        
        public static Complex operator /(Complex a, double b)
        {
            return new Complex(a.Re / b, a.Im / b);
        }
        
        public static Complex operator /(double b, Complex a)
        {
            return new Complex(b / a.Re, b / a.Im);
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
