using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 2
*/

namespace Task02
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

        static bool Validate(string s)
        {
            foreach(char c in s)
            {
                if ((c != ' ') && ((c < 'a') || (c > 'z')))
                    return false;
            }
            return true;
        }

        static string[] ValidatedSplit(string s, char ch = ';')
        {
            string[] array = s.Split(ch);
            return array;
        }

        static string Shorten(string s)
        {
            char[] vowelLetters = "aeiouyAEIOUY".ToCharArray();
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
            
            int index = s.IndexOfAny(letters);
            int startDeleteIndex = s.IndexOfAny(vowelLetters, index);
            s = s.Remove(startDeleteIndex + 1, s.Length - startDeleteIndex - 1);

            s = FirstToUpperCase(s);
            
            return s;
        }

        static string FirstToUpperCase(string s)
        {
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
            
            int firstLetterIndex = Array.IndexOf(letters, s[0]);
            if (firstLetterIndex > 25)
                s = letters[firstLetterIndex - 26] + s.Remove(0, 1);
        }
        
        static void Main()
        { 
            do
            {
                Console.Clear();

                string s1 = "eest";
                Console.WriteLine(Shorten(s1));
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}