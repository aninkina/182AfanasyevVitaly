using System;

namespace Task05
{
    public class Cheetah : Animal, IRun, IJump
    {
        public uint Speed { get; private set; }
        public uint Height { get; private set; }

        public Cheetah(uint age, uint speed, uint height) : base(age)
        {
            Speed = speed;
            Height = height;
        }
        
        public void Run()
        {
            Console.WriteLine($"Cheetah runs. Speed: {Speed}");
        }

        public void Jump()
        {
            Console.WriteLine($"Cheetah jumps. Height: {Height}");
        }

        public override string ToString()
        {
            return $"Cheetah. Age: {Age}, Speed: {Speed}, Jump height: {Height}";
        }
    }
}
