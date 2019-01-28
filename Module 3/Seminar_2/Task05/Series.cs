using System;

namespace Task05
{
    public class Series
    {
        int[] array;
        
        public int[] Arr { get => array; set => array = (int[])value.Clone(); }
        
        public Series(int[] array)
        {
            Arr = array;
        }

        public void Order(Comparison<int> comp)
        {
            Array.Sort(array, comp);
        }
    }
}
