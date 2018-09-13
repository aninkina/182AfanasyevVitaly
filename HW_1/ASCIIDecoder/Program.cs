using System;


namespace ASCIIDecoder
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите код символа (целое число от 32 до 127):");
            int Code = int.Parse(Console.ReadLine());
            Console.WriteLine("Символ в таблице ASCII:");
            Console.WriteLine((char)Code);
            Console.ReadKey();
        }
    }
}
