using System;

namespace Task05
{
    interface IRun
    {
        void Run();
    }

    interface IJump
    {
        void Jump();
    }

    public abstract class Animal
    {
        public uint Age { get; private set; }
        
        public Animal(uint age)
        {
            Age = age;
        }
    }
}
