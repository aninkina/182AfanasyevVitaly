using System;


namespace ASCIIDecoder
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите U(напряжение):");
            string uString = Console.ReadLine();
            Console.WriteLine("Введите R(сопротивление):");
            string rString = Console.ReadLine();
            float U, R;
            if (!float.TryParse(uString, out U) || !float.TryParse(rString, out R))
            {
                Console.WriteLine("Ошибка! Неверный формат входных данных!\nВведите вещественные числа(разделитель - запятая)!");
                Console.ReadKey();
                return;
            }
            float I = U / R, P = U * U / R;
            Console.WriteLine("I(сила тока) = {0}, P(мощность) = {1}", I, P);
            Console.ReadKey();
        }
    }
}
