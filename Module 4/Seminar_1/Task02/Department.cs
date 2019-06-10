using System;
using System.Collections.Generic;

namespace Task02
{
    [Serializable]
    public class Department
    {
        List<Human> staff;
        
        public string Name { get; set; }
        public List<Human> Staff
        {
            get => staff;
            set => staff = value;
        }
        
        public Department(string name, List<Human> staff)
        {
            Name = name;
            Staff = new List<Human>(staff);
        }

        public Department() : this("", new List<Human>()) { }
    }
}
