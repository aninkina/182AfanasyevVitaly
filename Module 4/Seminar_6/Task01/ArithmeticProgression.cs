using System;
using System.Collections;

namespace Task01
{
    public class ArithmeticProgression
    {
        public int A0 { get; set; }
        public int D { get; set; }
        public int N { get; set; }
        
        public ArithmeticProgression(int a0, int d, int n)
        {
            A0 = a0;
            D = d;
            N = n;
        }

        public IEnumerator GetEnumerator()
        {
            return new ArithmeticProgressionEnumerator(A0, D, N);
        }
    }
}
