using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
           Ввести натуральное трехзначное число Р. 
           Найти наибольшее целое число, которое можно получить, переставляя цифры числа Р.
*/

namespace Task02
{
    class Program
    {
        static int InputInt(string input, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            Console.WriteLine("Enter " + input + ": ");
            int result;
            while (!int.TryParse(Console.ReadLine(), out result) || (result < minValue) || (result > maxValue))
            {
                Console.WriteLine("Invalid input format! Try again");
            }
            return result;
        }

        static void Swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        static void ThreeDigitSort(ref int a, ref int b, ref int c)
        {
            if (a < b)
                Swap(ref a, ref b);
            if (a < c)
                Swap(ref a, ref c);
            if (b < c)
                Swap(ref b, ref c);
        }

        static void Main()
        {
            do
            {
                int number = InputInt("three-digit integer", 100, 999);
                int firstDigit = number / 100, secondDigit = number / 10 % 10, thirdDigit = number % 10;
                ThreeDigitSort(ref firstDigit, ref secondDigit, ref thirdDigit);
                int maxNumber = firstDigit * 100 + secondDigit * 10 + thirdDigit;
                Console.WriteLine("Maximal integer: {0}", maxNumber);
                Console.WriteLine("Press ESC to exit. Press any other key to continue");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
