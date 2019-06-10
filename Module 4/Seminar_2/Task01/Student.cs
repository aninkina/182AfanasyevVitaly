using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Task01
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Course { get; set; }
        
        public Student(string name, int course)
        {
            Name = name;
            Course = course;
        }

        public Student() : this("", 0) { }
    }
}
