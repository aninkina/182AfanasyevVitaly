using System;

namespace Task05
{
    public class ArrayPrintClass
    {
        public static event Action<int> LineComplete;
        
        public static void ArrayPrint(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); ++i)
            {
                for (int j = 0; j < a.GetLength(1); ++j)
                {
                    Console.Write(a[i, j] + " ");
                    LineComplete(i * a.GetLength(1) + j + 1);
                }
            }
            LineComplete(0);
        }
    }
}
