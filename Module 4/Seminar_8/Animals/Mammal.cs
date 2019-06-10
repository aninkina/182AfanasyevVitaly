using System;

namespace Animals
{
    [Serializable]
    public class Mammal : Animal
    {
        int paws;
        
        public int Paws
        {
            get => paws;
            set
            {
                if ((value < 1) || (value > 20))
                    throw new ArgumentException("Invalid number of paws.");
                paws = value;
            }
        }
        
        public Mammal(string name, bool isTakenCare, int paws) : base(name, isTakenCare)
        {
            Paws = paws;
        }

        public Mammal() : this("", false, 1) { }

        public override string ToString()
        {
            return $"Mammal. Paws: {Paws}, " + base.ToString();
        }
    }
}
