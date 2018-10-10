using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
            Посчитать синус через Math.Sin и ряд x - x^3/3! + x^5/5! - ...
            Сравнить и вывести результат.
*/

namespace Task03
{
    class Program
    {

        // Input methods

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
        /// Inputs and parses the variable.
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



        // Methods for solving


        /// <summary>
        /// Inits the array.
        /// </summary>
        /// <param name="array">Array.</param>
        static void InitArray(char[] array)
        {
            const char leftBorder = 'A', rightBorder = 'Z';
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = (char)rnd.Next(leftBorder, rightBorder);
        }

        /// <summary>
        /// Copies the array from source to destination.
        /// </summary>
        /// <param name="destination">Destination array.</param>
        /// <param name="source">Source array.</param>
        static void CopyArray<T>(out T[] destination, T[] source)
        {
            if (source == null)
            {
                Console.WriteLine("Undefined array!");
                destination = null;
                return;
            }
            destination = new T[source.Length];
            for (int i = 0; i < destination.Length; i++)
                destination[i] = source[i];
        }
        
        /// <summary>
        /// Outputs the array.
        /// </summary>
        /// <param name="array">Array.</param>
        static void OutputArray<T>(T[] array)
        {
            foreach (T i in array)
                Console.Write($"{i:G3} ");
            Console.WriteLine();
        }

        /// <summary>
        /// Translates angle to radians.
        /// </summary>
        /// <returns>Radians.</returns>
        /// <param name="angle">Angle.</param>
        static double AngleToRadians(double angle)
        {
            return ((angle % 360) * Math.PI / 180);
        }

        /// <summary>
        /// Counts the sequence of sin(1).
        /// </summary>
        /// <returns>Sequence.</returns>
        /// <param name="n">Number of members in sequence.</param>
        static double[] CountSequence(int n)
        {
            double x = 1;
            double[] sequence = new double[n];
            double sin, sinOld, memb;
            int m;
            for (m = 1, sin = memb = x, sinOld = 0; m <= n; m++)
            {
                sequence[m - 1] = memb;
                sinOld = sin;
                memb *= -x * x / 2.0 / m / (2.0 * m + 1.0);
                sin += memb;
            }
            return sequence;
        }
        
        /// <summary>
        /// Counts sin(angle) using sequence of sin(1).
        /// </summary>
        /// <returns>Sin(x).</returns>
        /// <param name="sin1Sequence">Sequence.</param>
        /// <param name="angle">Angle.</param>
        static double Sin(double[] sin1Sequence, double angle)
        {
            double x = AngleToRadians(angle);
            double rad = x;
            double sin = sin1Sequence[0] * x;
            for (int i = 1; i < sin1Sequence.Length; i++)
            {
                x *= rad * rad;
                sin += sin1Sequence[i] * x;
            }
            return sin;   
        }
        
        static void Main()
        {
            Console.Clear();

            int n = InputVar("number of elements (1 - 100) (more elements - more accurate)", 1, 100, (x, y) => x < y, (x, y) => x > y);
            
            double[] sin1;
            sin1 = CountSequence(n);

            do
            {
                double angle = InputVar("angle", double.MinValue, double.MaxValue, (x, y) => x < y, (x, y) => x > y);
                double sin = Sin(sin1, angle);
                double mathSin = Math.Sin(AngleToRadians(angle));
                
                Console.WriteLine($"Sin({angle}) = {sin:F3}");
                Console.WriteLine($"Math.Sin({angle}) = {mathSin:F3}");
                Console.WriteLine($"Accuracy: {Math.Abs(sin - mathSin):G3}");

                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
