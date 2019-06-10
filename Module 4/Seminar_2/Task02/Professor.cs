using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Task02
{
    [DataContract]
    public class Professor : Human
    {
        public Professor(string name) : base(name) { }
        public Professor() : base() { }
    }
}
