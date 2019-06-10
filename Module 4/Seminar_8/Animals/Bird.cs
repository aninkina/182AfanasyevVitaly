using System;

namespace Animals
{
    [Serializable]
    public class Bird : Animal
    {
        int speed;
        
        public int Speed
        {
            get => speed;

            set
            {
                if ((value < 1) || (value > 100))
                    throw new ArgumentException("Invalid speed.");
                speed = value;
            }
        }
        
        public Bird(string name, bool isTakenCare, int speed) : base(name, isTakenCare)
        {
            Speed = speed;
        }

        public Bird() : this("", false, 1) { }

        public override string ToString()
        {
            return $"Bird. Speed: {Speed}, " + base.ToString();
        }
    }
}
