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
            Birthday a = new Birthday();
            Console.WriteLine(a.Information);
            Console.WriteLine(a.HowManyDays);
            Console.WriteLine(a.DMonthY);
            Console.WriteLine(a.DDMMYY);
        }
    }
}