using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
            Подсчитать общее количество автомобилей, проданных всеми филиалами компании за год.
            Вывести максимальное количество автомобилей, проданных филиалом за квартал, 
                а также название филиала и номер квартала.
            Вывести название филиала, который продал максимальное количество автомобилей по результатам года, 
                а также проданное филиалом количество автомобилей.
            Вывести наиболее успешный квартал, в котором компания показала наилучший результат по продажам (учитываются все филиалы), 
                а также количество автомобилей проданное в нем.
*/

namespace Task07
{
    class Program
    {

        // Input methods

        delegate bool Compare<T>(T a, T b);

        /// <summary>
        /// Parses the input.
        /// </summary>
        /// <returns><c>true</c>, if input was parsed, <c>false</c> otherwise.</returns>
        /// <param name="input">Input.</param>
        /// <param name="result">Result.</param>
        /// <typeparam name="T">Type.</typeparam>
        static bool ParseInput<T>(string input, out T result)
        {
            bool parsed;
            if (typeof(T) == typeof(int))
            {
                int tmpResult;
                parsed = int.TryParse(input, out tmpResult);
                result = (T)(object)tmpResult;
            }
            else if (typeof(T) == typeof(double))
            {
                double tmpResult;
                parsed = double.TryParse(input, out tmpResult);
                result = (T)(object)tmpResult;
            }
            else if (typeof(T) == typeof(uint))
            {
                uint tmpResult;
                parsed = uint.TryParse(input, out tmpResult);
                result = (T)(object)tmpResult;
            }
            else if (typeof(T) == typeof(long))
            {
                long tmpResult;
                parsed = long.TryParse(input, out tmpResult);
                result = (T)(object)tmpResult;
            }
            else if (typeof(T) == typeof(byte))
            {
                byte tmpResult;
                parsed = byte.TryParse(input, out tmpResult);
                result = (T)(object)tmpResult;
            }
            else if (typeof(T) == typeof(sbyte))
            {
                sbyte tmpResult;
                parsed = sbyte.TryParse(input, out tmpResult);
                result = (T)(object)tmpResult;
            }
            else if (typeof(T) == typeof(char))
            {
                char tmpResult;
                parsed = char.TryParse(input, out tmpResult);
                result = (T)(object)tmpResult;
            }
            else
            {
                result = default(T);
                parsed = true;
            }
            return parsed;
        }

        /// <summary>
        /// Inputs and parses the variable of type T.
        /// </summary>
        /// <returns>Variable of type T.</returns>
        /// <param name="input">Input.</param>
        /// <param name="minValue">Minimum value.</param>
        /// <param name="maxValue">Maximum value.</param>
        /// <param name="compMin">Comparator for minValue.</param>
        /// <param name="compMax">Comparator for maxValue.</param>
        static T InputVar<T>(string input, T minValue, T maxValue, Compare<T> compMin, Compare<T> compMax)
        {
            Console.WriteLine($"Enter {input}:");
            T result;
            while (!ParseInput(Console.ReadLine(), out result) || compMin(result, minValue) || compMax(result, maxValue))
            {
                Console.WriteLine("Invalid input format! Try again!");
                Console.WriteLine($"Enter {input}:");
            }
            return result;
        }


        // Methods for solving

        static readonly string[] filials = { "West", "Central", "East" };
        static readonly string[] quarters = { "I", "II", "III", "IV" };
        static readonly int[,] autosSold = 
        { 
            { 20, 24, 25 }, 
            { 21, 20, 18 }, 
            { 23, 27, 24 }, 
            { 22, 19, 20 } 
        };

        /// <summary>
        /// Counts all sold autos.
        /// </summary>
        /// <returns>Sum of all sold autos.</returns>
        static int CountAllSoldAutos()
        {
            int sum = 0;
            for (int i = 0; i < quarters.Length; ++i)
            {
                for (int j = 0; j < filials.Length; ++j)
                {
                    sum += autosSold[i, j];
                }
            }
            return sum;
        }

        /// <summary>
        /// Finds quarter with max amount of autos sold by filial.
        /// </summary>
        /// <returns>Tuple of int and string. Item1: amount of sold autos, Item2: quarter.</returns>
        /// <param name="filial">Number of a filial.</param>
        static (int, string) MaxAutosSoldQuarterByFilial(int filial)
        {
            var max = (Amount: -1, Quarter: "");
            for (int i = 0; i < quarters.Length; ++i)
            {
                if (autosSold[i, filial] > max.Amount)
                {
                    max.Amount = autosSold[i, filial];
                    max.Quarter = quarters[i];
                }
            }
            return max;
        }
        
        /// <summary>
        /// Finds filial with max amount of autos sold in a year.
        /// </summary>
        /// <returns>Tuple of int and string. Item1: amount of sold autos, Item2: filial.</returns>
        static (int, string) MaxAutosSoldFilial()
        {
            var max = (Amount: -1, Filial: "");
            for (int i = 0; i < filials.Length; ++i)
            {
                int sum = 0;
                for (int j = 0; j < quarters.Length; ++j)
                    sum += autosSold[j, i];
                
                if (sum > max.Amount)
                {
                    max.Amount = sum;
                    max.Filial = filials[i];
                }
            }
            return max;
        }

        /// <summary>
        /// Finds quarter with max amount of autos sold by a company.
        /// </summary>
        /// <returns>Tuple of int and string. Item1: amount of sold autos, Item2: quarter.</returns>
        static (int, string) MaxAutosSoldQuarterByCompany()
        {
            var max = (Amount: -1, Quarter: "");
            for (int i = 0; i < quarters.Length; ++i)
            {
                int sum = 0;
                for (int j = 0; j < filials.Length; ++j)
                    sum += autosSold[i, j];

                if (sum > max.Amount)
                {
                    max.Amount = sum;
                    max.Quarter = quarters[i];
                }
            }
            return max;
        }
        
        static void Main()
        {
            Console.Clear();

            Console.WriteLine($"Autos sold: {CountAllSoldAutos()}");

            Console.WriteLine("Quarter with max amount of autos sold by each filial:");
            for (int i = 0; i < filials.Length; ++i)
            {
                (int, string) maxQuarter = MaxAutosSoldQuarterByFilial(i);
                Console.WriteLine($"\tFilial: {filials[i]}, Quarter: {maxQuarter.Item2}, Autos sold: {maxQuarter.Item1}, ");
            }

            Console.WriteLine("Filial with max amount of autos sold in a year:");
            (int, string) maxFilial = MaxAutosSoldFilial();
            Console.WriteLine($"\tFilial: {maxFilial.Item2}, Autos sold: {maxFilial.Item1}");

            Console.WriteLine("Quarter with max amount of autos sold by a company:");
            (int, string) maxCompany = MaxAutosSoldQuarterByCompany();
            Console.WriteLine($"\tQuarter: {maxCompany.Item2}, AutosSold: {maxCompany.Item1}");
        }
    }
}
