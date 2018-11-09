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

                int n = InputVar<int>("size of field", x => x >= 2, y => y <= 35);

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
