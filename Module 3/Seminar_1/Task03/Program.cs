using System;
using System.Collections.Generic;
using Checker;

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
        enum Temperature { CToF, CToK, CToRa, CToRe };
        
        static void Main()
        {
            const int numberOfConverters = 4;

            delegateConvertTemperature[] converters = new delegateConvertTemperature[numberOfConverters];
            
            converters[(int)Temperature.CToF] = StaticTempConverters.CelciusToFahrenheit;
            converters[(int)Temperature.CToK] = StaticTempConverters.CelciusToKelvin;
            converters[(int)Temperature.CToRa] = StaticTempConverters.CelciusToRankine;
            converters[(int)Temperature.CToRe] = StaticTempConverters.CelciusToReaumur;
            
            do
            {
                Console.Clear();

                double temperature = InputChecker.InputVar<double>("temperature in Celcius");

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