using System;
using System.Collections.Generic;

namespace Task01
{
    [Serializable]
    public class Group
    {
        List<Student> students;
        
        public string Name { get; set; }
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
