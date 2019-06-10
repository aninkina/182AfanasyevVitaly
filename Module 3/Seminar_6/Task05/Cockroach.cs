using System;

namespace Task05
{
    public class Cockroach : Animal, IRun
    {
        public uint Speed { get; private set; }

        public Cockroach(uint age, uint speed) : base(age)
        {
            Speed = speed;
        }

        void IRun.Run()
        {
            Console.WriteLine($"Cockroach runs. Speed: {Speed}");
        }
        
        public override string ToString()
        {
            return $"Cockroach. Age: {Age}, Speed: {Speed}";
        }
    }
}
