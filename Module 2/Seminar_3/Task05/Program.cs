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
    /// Video file.
    /// </summary>
    class VideoFile
    {
        string _name;
        int _duration;
        int _quality;

        public VideoFile() : this("", 0, 0) { }
        
        public VideoFile(string name, int duration, int quality)
        {
            _name = name;
            _duration = duration;
            _quality = quality;
        }
        
        public int Size { get => _duration * _quality; }

        public override string ToString()
        {
            return $"Name: {_name}, Duration: {_duration}, Quality: {_quality}";
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

        /// <summary>
        /// Generates the random name (length = [2; 9]).
        /// </summary>
        /// <returns>The random name.</returns>
        static string GenerateRandomName()
        {
            int n = rnd.Next(2, 10);
            string s = "";
            for (int i = 0; i < n; ++i)
                s += (char)rnd.Next('a', 'z' + 1);
            return s;
        }
        
        static Random rnd = new Random();
        
        static void Main()
        {
            
            do
            {
                Console.Clear();

                VideoFile videoElement = 
                    new VideoFile(GenerateRandomName(), rnd.Next(60, 361), rnd.Next(100, 1001));
                int n = rnd.Next(5, 16);
                VideoFile[] videos = new VideoFile[n];

                Console.WriteLine($"N: {n}");
                for (int i = 0; i < n; ++i)
                    videos[i] = 
                        new VideoFile(GenerateRandomName(), rnd.Next(60, 361), rnd.Next(100, 1001));

                Console.WriteLine("Videos[i] > VideoElement[i]:");
                foreach (var item in videos)
                {
                    if (item.Size > videoElement.Size)
                        Console.WriteLine(item);
                }
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
