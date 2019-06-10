using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Task02
{
    [DataContract]
    public class Human
    {
        [DataMember]
        public string Name { get; set; }

        public Human(string name)
        {
            Name = name;
        }

        public Human() : this("") { }
    }
}
