using System;

namespace Task02
{
    [Serializable]
    public class Human
    {
        public string Name { get; set; }

        public Human(string name)
        {
            Name = name;
        }

        public Human() : this("") { }
    }
}
