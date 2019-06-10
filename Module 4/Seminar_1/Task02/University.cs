using System;
using System.Collections.Generic;

namespace Task02
{
    [Serializable]
    public class University
    {
        List<Department> departments;
        
        public string Name { get; set; }
        public List<Department> Departments
        {
            get => departments;
            set => departments = value;
        }
        
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
