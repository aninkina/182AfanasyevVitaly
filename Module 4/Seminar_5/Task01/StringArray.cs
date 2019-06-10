using System;
using System.Collections;
using System.Collections.Generic;

namespace Task01
{
    public class StringArray : IEnumerable<string[]>
    {
        string[] arr;
        
        public string[] Arr { get => arr; set => arr = (string[])value.Clone(); }
        
        public StringArray(string[] arr)
        {
            Arr = arr;
        }

        public StringArray()
        {
            Arr = new string[0];
        }

        public IEnumerator<string[]> GetEnumerator()
        {
            Array.Sort(Arr);
            yield return Arr;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Array.Sort(Arr);
            return Arr.GetEnumerator();
        }
    }
}
