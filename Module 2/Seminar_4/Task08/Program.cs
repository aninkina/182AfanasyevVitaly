using System;
using Figures;
using System.IO;
using System.Collections.Generic;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 8
*/

namespace Task08
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
        
        static void Main()
        {
            do
            {
                Console.Clear();
                
                Dimensions[] fig = new Dimensions[rnd.Next(1, 6) * 2];
                for (int i = 0; i < fig.Length / 2; ++i)
                {
                    fig[i] = new Ellipse(rnd.Next(1, 11), rnd.Next(1, 11));
                    fig[i + fig.Length / 2] = new Triangle(rnd.Next(1, 11), rnd.Next(1, 11));
                }

                StreamWriter output = new StreamWriter("Figures.txt");
                foreach (Dimensions item in fig)
                    output.WriteLine(item.Record);
                output.Flush();
                output.Close();

                StreamReader input = new StreamReader("Figures.txt");
                List<string> figInput = new List<string>();
                string line = input.ReadLine();
                while (line != null)
                {
                    figInput.Add(line);
                    line = input.ReadLine();
                }
                input.Close();

                Dimensions[] fig2 = new Dimensions[figInput.Count];
                int j = 0;
                foreach(string item in figInput)
                {
                    string[] parts = item.Split(' ');
                    double x = double.Parse(parts[1]), y = double.Parse(parts[2]);
                    if (parts[0] == "Ellipse")
                        fig2[j++] = new Ellipse(x, y);
                    if (parts[0] == "Triangle")
                        fig2[j++] = new Triangle(x, y);
                }

                foreach (Dimensions item in fig2)
                    Console.WriteLine(item);
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
