using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Task02
{
    [DataContract]
    public class University
    {
        [DataMember]
        public string Name { get; set; }
        
        [DataMember]
        public List<Department> Departments { get; set; }

        public University(string name, List<Department> departments)
        {
            Name = name;
            Departments = departments;
        }

        public University() : this("", new List<Department>())
        {

        }
    }
}
