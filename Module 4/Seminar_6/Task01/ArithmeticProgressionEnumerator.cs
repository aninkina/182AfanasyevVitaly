using System;
using System.Collections;
using System.Collections.Generic;

namespace Task01
{
    public class ArithmeticProgressionEnumerator : IEnumerator
    {
        int position = -1;

        int a0;
        int d;
        int n;

        public ArithmeticProgressionEnumerator(int a0, int d, int n)
        {
            this.a0 = a0;
            this.d = d;
            this.n = n;
        }

        object IEnumerator.Current 
        {
            get
            {
                if ((position < 0) || (position >= n))
                {
                    throw new InvalidOperationException();
                }
                return a0 + d * position;
            }
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
