using System;
using System.Collections.Generic;
using Checker;

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
        /// Converts integer to array of it's digits.
        /// </summary>
        /// <returns>The array of digits.</returns>
        /// <param name="x">Integer number.</param>
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

        /// <summary>
        /// Prints the array of integers
        /// </summary>
        /// <param name="a">Array of integers.</param>
        static void PrintIntArray(int[] a)
        {
            foreach (int item in a)
                Console.Write(item + " ");
            Console.WriteLine();
        }

        static Random rnd = new Random();
        
        static void Main()
        {
            Func1 ToDigitArray = IntToNumbers;
            Func2<int> PrintArray = PrintIntArray;
            
            do
            {
                Console.Clear();

                int randomNumber = rnd.Next(10000, 100000);
                int[] randomArray = new int[10];
                for (int i = 0; i < randomArray.Length; ++i)
                    randomArray[i] = rnd.Next(10, 100);

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