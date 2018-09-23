using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
           Получить от пользователя четырехзначное натуральное число и
           напечатать его цифры в обратном порядке.
*/

namespace Task04
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

        static void Main()
        {
            do
            {
                int number = InputInt("four-digit integer", 1000, 9999);
                int firstDigit = number / 1000, 
                    secondDigit = number / 100 % 10, 
                    thirdDigit = number / 10 % 10, 
                    fourthDigit = number % 10;
                int reversedNumber = fourthDigit * 1000 + thirdDigit * 100 + secondDigit * 10 + firstDigit;
                Console.WriteLine($"Reversed number: {reversedNumber}");
                Console.WriteLine("Press ESC to exit. Press any other key to continue");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
