using System;

namespace Task02
{
    [Serializable]
    public class Professor : Human
    {
        public Professor(string name) : base(name) { }
        public Professor() : base() { }
    }
}
