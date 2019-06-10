using System;
using System.Collections;

namespace Task02
{
    public class MyInt : IEnumerator, IEnumerable
    {
        int[] array;
        int position = -1;
        
        public MyInt(int[] array)
        {
            this.array = (int[])array.Clone();
        }

        public object Current { get => array[position]; }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (position < array.Length - 1)
            {
                position++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
