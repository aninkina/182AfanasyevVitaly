using System;
using System.Collections.Generic;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 3
*/

namespace Task03
{
    delegate double delegateConvertTemperature(double temperature);
    
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

        enum Temperature { CToF, CToK, CToRa, CToRe };
        
        static void Main()
        {
            const int numberOfConverters = 4;
            do
            {
                Console.Clear();

                double temperature = InputVar<double>("temperature in Celcius");

                delegateConvertTemperature[] converters = new delegateConvertTemperature[numberOfConverters];
                
                converters[(int)Temperature.CToF] = StaticTempConverters.CelciusToFahrenheit;
                converters[(int)Temperature.CToK] = StaticTempConverters.CelciusToKelvin;
                converters[(int)Temperature.CToRa] = StaticTempConverters.CelciusToRankine;
                converters[(int)Temperature.CToRe] = StaticTempConverters.CelciusToReaumur;

                Console.WriteLine($"Celcius: {temperature:F3}");
                for (int i = 0; i < numberOfConverters; ++i)
                {
                    Console.WriteLine($"{converters[i].Method.Name}: {converters[i](temperature):F3}");
                }
                
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}