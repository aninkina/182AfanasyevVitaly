using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 1       
*/

namespace Task01
{
    /// <summary>
    /// Birthday of person.
    /// </summary>
    class Birthday
    {
        DateTime date;
        string name;

        public Birthday(string name, int year, int month, int day)
        {
            this.name = name;
            date = new DateTime(year, month, day);
        }

        public Birthday() : this("Undefined", 1970, 1, 1) { }

        public string Information
        {
            get => $"{name}: {date.Day}.{date.Month}.{date.Year}";
        }

        /// <summary>
        /// How many days until the next birthday.
        /// </summary>
        /// <value>Integer value of days.</value>
        public int HowManyDays
        {
            get
            {
                int result = date.DayOfYear - DateTime.Now.DayOfYear;
                if (result < 0)
                    result += 365;
                return result;
            }
        }

        /// <summary>
        /// Date of birth in format D Month Y.
        /// </summary>
        /// <value>Format string.</value>
        public string DMonthY
        {
            get => $"{date.Day} {date.ToString("MMMM")} {date.Year}";
        }
        
        /// <summary>
        /// Date of birth in format dd-MM-yy.
        /// </summary>
        /// <value>Format string.</value>
        public string DDMMYY
        {
            get => $"{date.ToString("dd")}-{date.ToString("MM")}-{date.ToString("yy")}";
        }
    }

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
            Birthday a = new Birthday();
            Console.WriteLine(a.Information);
            Console.WriteLine(a.HowManyDays);
            Console.WriteLine(a.DMonthY);
            Console.WriteLine(a.DDMMYY);
        }
    }
}