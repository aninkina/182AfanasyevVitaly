using System;
using System.Collections;
using System.Collections.Generic;

namespace Task03
{
    public class ArithmeticProgression
    {
        public int N { get; set; }
        public int A0 { get; set; }
        public int D { get; set; }
        
        public ArithmeticProgression(int n, int a0, int d)
        {
            N = n;
            A0 = a0;
            D = d;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < N; ++i)
            {
                yield return A0 + D * i;
            }
        }
    }
}
