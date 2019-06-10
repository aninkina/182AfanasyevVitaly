using System;
using System.Collections;
using System.Collections.Generic;

namespace Task04
{
    public class RandomEnumerator : IEnumerator<int>
    {
        List<int> list;
        int n;
        int position = -1;
        
        public RandomEnumerator(List<int> list, int n)
        {
            this.list = new List<int>(list);
            this.n = n;
        }

        public int Current { get => list[position]; }

        object IEnumerator.Current { get => list[position]; }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (position < n - 1)
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
