using System;

namespace Task05
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите длину первого катета:");
            string cathString1 = Console.ReadLine();
            Console.WriteLine("Введите длину второго катета:");
            string cathString2 = Console.ReadLine();
            double cath1, cath2;
            if (!double.TryParse(cathString1, out cath1) || !double.TryParse(cathString2, out cath2))
            {
                Console.WriteLine("Ошибка! Неверный формат входных данных!\nВведите вещественные числа(разделитель - запятая)!");
                Console.ReadKey();
                return;
            }
            if ((cath1 <= 0) || (cath2 <= 0))
            {
                Console.WriteLine("Ошибка! Длины катетов должны быть строго положительными!");
                Console.ReadKey();
                return;
            }
            double hyp = Math.Sqrt(cath1 * cath1 + cath2 * cath2);
            Console.WriteLine("Длина гипотенузы = " + hyp.ToString());
            Console.ReadKey();
        }
    }
}
