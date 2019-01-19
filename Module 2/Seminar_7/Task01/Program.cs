using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 1
*/

namespace Task01
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
        
        static string CreateString(int length, char minChar, char maxChar)
        {
            if (length <= 0)
                throw new ArgumentException("Length of string must be a positive number.");
            if (maxChar < minChar)
                throw new ArgumentException("MaxChar can't be less than minChar.");
            string s = "";
            for (int i = 0; i < length; ++i)
                s += (char)rnd.Next(minChar, maxChar);
            return s;
        }

        static string MoveOff(string s, string symbols)
        {
            for (int i = 0; i < symbols.Length; ++i)
                s = s.Replace(new String(symbols[i], 1), "");
            return s;
        }
        
        static void Main()
        { 
            do
            {
                Console.Clear();

                string s1 = CreateString(10, '0', '9');
                string s2 = "02468";
                Console.WriteLine(s1 + '\n' + s2);
                Console.WriteLine(MoveOff(s1, s2));
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}