using System;
using System.Collections.Generic;
using System.Linq;

namespace Task02
{
    public class RectSet 
    {
        public static Random rnd;
        
        int x1;
        int x2;
        HashSet<int> set;
        
        public HashSet<int> GetSet { get { return set; } }
        
        public RectSet() 
        {
            set = new HashSet<int>();
        }
        
        public RectSet(int min, int max, int N) 
        {
            int[] arr = new int[N];
            for (int i = 0; i < N; i++) 
                arr[i] = rnd.Next(min, max + 1);
            set = new HashSet<int>(arr);
            Array.Sort(arr);
            x1 = arr[0]; x2 = arr[arr.Length - 1];
        }

        public RectSet(HashSet<int> mySet) 
        { 
            set = mySet;
            x1 = set.Min(); x2 = set.Max();
        }

        public static RectSet operator +(RectSet a, RectSet b) 
        {
            return new RectSet(new HashSet<int>(a.GetSet.Concat(b.GetSet)));
        }

        public static RectSet operator *(RectSet a, RectSet b)
        {
            return new RectSet(new HashSet<int>(a.GetSet.Intersect(b.GetSet)));
        }
        
        public static RectSet operator ^(RectSet a, RectSet b)
        {
            var c = new HashSet<int>(a.GetSet);
            c.SymmetricExceptWith(b.GetSet);
            return new RectSet(c);
        }
    }
}
