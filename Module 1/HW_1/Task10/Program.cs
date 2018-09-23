using System;

namespace Task10
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите первое слово:");
            string word1 = Console.ReadLine();
            Console.WriteLine("Введите второе слово:");
            string word2 = Console.ReadLine();
            Console.WriteLine("Введите третье слово:");
            string word3 = Console.ReadLine();
            Console.WriteLine("{0}!{1}!{2}", word1, word2, word3);
            Console.ReadKey();
        }
    }
}
