using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 5  
*/

namespace Task05
{
    /// <summary>
    /// Char and it's background and foreground colors.
    /// </summary>
    public class ConsolePlate
    {
        char _plateChar = 'A';
        ConsoleColor _plateColor = ConsoleColor.White;
        ConsoleColor _plateForegroundColor = ConsoleColor.Black;
        
        public char PlateChar 
        { 
            get => _plateChar; 
            set
            {
                if ((value >= 'A') && (value <= 'Z'))
                    _plateChar = value;
            } 
        }
        
        public ConsoleColor PlateColor 
        { 
            get => _plateColor; 
            set
            {
                if (value != _plateForegroundColor)
                    _plateColor = value;
            } 
        }
        
        public ConsoleColor PlateForegroundColor
        { 
            get => _plateForegroundColor; 
            set
            {
                if (value != _plateColor)
                    _plateForegroundColor = value;
            } 
        }

        public ConsolePlate()
        {
            _plateChar = 'A';
            _plateColor = ConsoleColor.White;
            _plateForegroundColor = ConsoleColor.Black;
        }

        public ConsolePlate(char plateChar, ConsoleColor plateColor, ConsoleColor backgroundColor)
        {
            if ((plateChar >= 'A') && (plateChar <= 'Z'))
                _plateChar = plateChar;
            if (plateColor != backgroundColor)
            {
                _plateColor = plateColor;
                _plateForegroundColor = backgroundColor;
            }
        }
    }  

    class Program
    {
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

        static Random rnd = new Random();
        readonly static ConsoleColor[] ConsolePlates = { ConsoleColor.White, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.Yellow, ConsoleColor.Magenta, ConsoleColor.Cyan, ConsoleColor.Black };
        
        static void Main()
        {
            ConsoleColor bgBase = Console.BackgroundColor;
            ConsoleColor fgBase = Console.ForegroundColor;
            do
            {
                Console.Clear();
                Console.BackgroundColor = bgBase;
                Console.ForegroundColor = fgBase;

                ConsolePlate plate1 = new ConsolePlate('X', ConsoleColor.Red, ConsoleColor.White);
                ConsolePlate plate2 = new ConsolePlate('O', ConsoleColor.Magenta, ConsoleColor.White);

                ConsolePlate[] plateArr = { plate1, plate2 };

                int n = InputVar("size of field", 2, 35, (x, y) => x < y, (x, y) => x > y);

                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        Console.BackgroundColor = plateArr[(i + j) % 2].PlateColor;
                        Console.ForegroundColor = plateArr[(i + j) % 2].PlateForegroundColor;
                        Console.Write(plateArr[(i + j) % 2].PlateChar);
                    }
                    Console.WriteLine();
                }
                
                Console.BackgroundColor = bgBase;
                Console.ForegroundColor = fgBase;
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
