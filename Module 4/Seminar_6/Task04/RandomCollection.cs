using System;
using System.Collections;
using System.Collections.Generic;

namespace Task04
{
    public class RandomCollection : IEnumerable<int>
    {
        static Random rnd = new Random();

        List<int> list;
        public int N { get; set; }
        
        public RandomCollection(int n)
        {
            N = n;
        }

        public IEnumerator<int> GetEnumerator()
        {
            list = new List<int>();
            for (int i = 0; i < N; ++i)
                list.Add(rnd.Next(100));

            return new RandomEnumerator(list, N);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            list = new List<int>();
            for (int i = 0; i < N; ++i)
                list.Add(rnd.Next(100));

            return new RandomEnumerator(list, N);
        }
    }
}
