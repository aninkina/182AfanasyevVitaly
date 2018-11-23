using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 5
*/

namespace Task05
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

        static string GenerateName()
        {
            string s = "";
            for (int i = 0; i < 6; ++i)
                s += (char)('a' + rnd.Next(0, 26));
            return s;
        }
        
        static UnitsBase[] UnitArray()
        {
            int countBooks = rnd.Next(3, 6);
            int countCards = rnd.Next(3, 6);
            int countCDs = rnd.Next(3, 6);
            UnitsBase[] p = new UnitsBase[countBooks + countCards + countCDs];

            for (int i = 0; i < countBooks; ++i)
            {
                p[i] = new Books(rnd.Next(1, 101), rnd.Next(50, 500), GenerateName(), rnd.Next(30, 100), rnd.Next(0, 2) == 1);
            }

            for (int i = countBooks; i < countBooks + countCards; ++i)
            {
                p[i] = new Cards(rnd.Next(1, 101), rnd.Next(50, 500), GenerateName(), GenerateName());
            }

            for (int i = countBooks + countCards; i < p.Length; ++i)
            {
                p[i] = new CD(rnd.Next(1, 101), rnd.Next(50, 500), GenerateName(), rnd.Next(30, 1201));
            }

            return p;
        }
        
        static void Main()
        {
            
            do
            {
                Console.Clear();

                UnitsBase[] units = UnitArray();
                int discount = InputVar<int>("discount percentage (0 - 100)", x => x >= 0, y => y <= 100);

                Console.WriteLine("Prices:");
                foreach (UnitsBase item in units)
                {
                    Console.WriteLine("\t" + item + $", Price: {item.Price:F3}");
                }

                Console.WriteLine("Prices with discount:");
                foreach (UnitsBase item in units)
                {
                    Console.WriteLine("\t" + item + $", Price: {item.Discount(discount):F3}");
                }
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
