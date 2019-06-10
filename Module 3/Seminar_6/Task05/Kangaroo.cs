using System;

namespace Task05
{
    public class Kangaroo : Animal, IJump
    {
        public uint Height { get; private set; }

        public Kangaroo(uint age, uint height) : base(age)
        {
            Height = height;
        }

        public void Jump()
        {
            Console.WriteLine($"Kangaroo jumps. Height: {Height}");
        }
        
        public override string ToString()
        {
            return $"Kangaroo. Age: {Age}, Jump height: {Height}";
        }
    }
}
