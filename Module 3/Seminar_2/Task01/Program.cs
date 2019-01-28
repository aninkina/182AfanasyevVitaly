using System;
using System.Collections.Generic;
using System.Linq;
using static Checker.InputChecker;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 1 
*/

namespace Task01
{
    public delegate string ConvertRule(string str);

    class Program
    {
        public static string RemoveDigits(string str)
        {
            string result = "";
            foreach (char c in str)
            {
                if ((c < '0') || (c > '9'))
                    result += c;
            }
            return result;
        }

        public static string RemoveSpaces(string str)
        {
            string result = "";
            foreach (char c in str)
            {
                if (c != ' ')
                    result += c;
            }
            return result;
        }

        static void Main()
        {
            Converter converter = new Converter();

            string[] stringArray = { "abc", "aba caba", "ab91aa", "a b9" };
            ConvertRule converterRule = new ConvertRule(RemoveDigits);

            Console.WriteLine("RemoveDigits: ");
            foreach (string str in stringArray)
                Console.WriteLine(converter.Convert(str, converterRule));

            converterRule -= RemoveDigits;
            converterRule += RemoveSpaces;
            Console.WriteLine("RemoveSpaces: ");
            foreach (string str in stringArray)
                Console.WriteLine(converter.Convert(str, converterRule));

            converterRule += RemoveDigits;
            Console.WriteLine("RemoveDigits + RemoveSpaces: ");
            foreach (string str in stringArray)
                Console.WriteLine(converter.Convert(str, converterRule));

            Console.WriteLine("Press any key to exit.");
        }
    }
}