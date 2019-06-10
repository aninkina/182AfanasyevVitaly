using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Task02
{
    [DataContract]
    public class Department
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<Human> Staff { get; set; }

        public Department(string name, List<Human> staff)
        {
            Name = name;
            Staff = new List<Human>(staff);
        }

        public Department() : this("", new List<Human>()) { }

        public override string ToString()
        {
            return $"Name: {Name}, Number of staff: {Staff.Count}";
        }
    }
}
