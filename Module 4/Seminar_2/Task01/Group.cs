using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Task01
{
    [DataContract]
    public class Group
    {
        List<Student> students;
        
        [DataMember]
        public string Name { get; set; }
        
        [DataMember]
        public List<Student> Students 
        { 
            get => students;
            set => students = new List<Student>(value);
        }
        
        public Group(string name, List<Student> students)
        {
            Name = name;
            Students = students;
        }

        public Group() : this("", new List<Student>()) { }

        public override string ToString()
        {
            return $"Name: {Name}, Number of students: {Students.Count}";
        }
    }
}
