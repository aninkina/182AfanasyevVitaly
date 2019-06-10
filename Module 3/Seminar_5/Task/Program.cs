using System;
using static Checker.InputChecker;

namespace Task
{
    class Program
    {
        static string RandomName(int length)
        {
            string s = "";
            for (int i = 0; i < length; ++i)
                s += (char)rnd.Next('a', 'z');
            return s;
        }

        static MusicalInstrument RandomInstrument()
        {
            int k = rnd.Next(2);
            MusicalInstrument instrument = null;
            bool generated = false;
            while (!generated)
            {
                try
                {
                    if (k == 0)
                    {
                        instrument = new Drum(RandomName(rnd.Next(2, 10)), rnd.Next(100) < 70, (byte)rnd.Next(-4, 30));
                        instrument.onSound += (sender, e) => Console.WriteLine("я барабан, бам-бам-бам");
                    }
                    if (k == 1)
                    {
                        instrument = new Guitar(RandomName(rnd.Next(2, 10)), rnd.Next(100) < 70, (byte)rnd.Next(-4, 30));
                        instrument.onSound += (sender, e) => Console.WriteLine("я гитара, дзынь-дзынь-дзынь");
                    }
                    generated = true;
                }
                catch (ArgumentException)
                {
                    generated = false;
                }
            }
            return instrument;
        }
    
        static Random rnd = new Random();
        public static void Main()
        {
            const int minNumber = 1, maxNumber = 100;
            int n = InputVar<int>($"number of instruments ({minNumber} - {maxNumber})", 
                x => (x >= minNumber) && (x <= maxNumber));
            Orchestra orchestra = new Orchestra();
            for (int i = 0; i < n; ++i)
            {
                orchestra.SetOfMusicalInstruments.Add(RandomInstrument());
            }

            foreach (var instrument in orchestra)
            {
                Console.WriteLine(instrument);
                instrument.DoSound();
            }
        }
    }
}
