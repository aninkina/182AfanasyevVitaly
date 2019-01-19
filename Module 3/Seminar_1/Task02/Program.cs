using System;
using System.Collections.Generic;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 2
*/

namespace Task02
{
    delegate int[] Func1(int x);
    delegate void Func2<T>(T[] a);
    
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

        static int[] IntToNumbers(int x)
        {
            List<int> digits = new List<int>();
            do
            {
                digits.Add(x % 10);
                x /= 10;
            } while (x > 0);
            digits.Reverse();
            return digits.ToArray();
        }

        static void PrintIntArray(int[] a)
        {
            foreach (int item in a)
                Console.Write(item + " ");
            Console.WriteLine();
        }

        static Random rnd = new Random();
        
        static void Main()
        {
            do
            {
                Console.Clear();

                int randomNumber = rnd.Next(10000, 100000);
                int[] randomArray = new int[10];
                for (int i = 0; i < randomArray.Length; ++i)
                    randomArray[i] = rnd.Next(10, 100);

                Func1 ToDigitArray = IntToNumbers;
                Func2<int> PrintArray = PrintIntArray;

                Console.WriteLine("Random number: " + randomNumber);
                
                Console.WriteLine("Number to digits: ");
                PrintArray(ToDigitArray(randomNumber));
                Console.WriteLine("Print array: ");
                PrintArray(randomArray);
                Console.WriteLine("ToDigitArray.Method: " + ToDigitArray.Method);
                Console.WriteLine("ToDigitArray.Target: " + ToDigitArray.Target);
                Console.WriteLine("PrintArray.Method: " + PrintArray.Method);
                Console.WriteLine("PrintArray.Target: " + PrintArray.Target);
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}