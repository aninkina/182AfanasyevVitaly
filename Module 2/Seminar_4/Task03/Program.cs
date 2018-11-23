using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 3
*/

namespace Task03
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
        
        static Employee[] EmpArray()
        {
            int countSales = rnd.Next(0, 11);
            int countPartTime = rnd.Next(0, 11);
            Employee[] p = new Employee[countSales + countPartTime];

            for (int i = 0; i < countSales; ++i)
            {
                string name = GenerateName();
                p[i] = new SalesEmployee(name, rnd.Next(0, 1000), rnd.Next(0, 100));
            }

            for (int i = countSales; i < p.Length; ++i)
            {
                string name = GenerateName();
                p[i] = new PartTimeEmployee(name, rnd.Next(0, 1000), rnd.Next(0, 100));
            }

            return p;
        }
        
        static void Main()
        {
            
            do
            {
                Console.Clear();

                Employee[] employees = EmpArray();

                Array.Sort(employees, (x, y) => x.CalculatePay() > y.CalculatePay() ? 1 : -1);

                Console.WriteLine("SalesEmployees:");
                foreach (Employee emp in employees)
                {
                    if (emp is SalesEmployee)
                        Console.WriteLine($"{emp.name}: {emp.CalculatePay():F3}");
                }
                Console.WriteLine();
                
                Console.WriteLine("PartTimeEmployees:");
                foreach (Employee emp in employees)
                {
                    if (emp is PartTimeEmployee)
                        Console.WriteLine($"{emp.name}: {emp.CalculatePay():F3}");
                }
                Console.WriteLine();
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
