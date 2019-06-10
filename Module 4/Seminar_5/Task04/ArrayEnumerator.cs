using System;
using System.Collections;

namespace Task04
{
    public class ArrayEnumerator<T> : IEnumerator
    {
        T[] arr;
        int position = -1;
        
        public ArrayEnumerator(T[] arr)
        {
            this.arr = arr;
        }

        public object Current { get => arr [position]; }

        public bool MoveNext()
        {
            if (position < arr.Length - 1)
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
