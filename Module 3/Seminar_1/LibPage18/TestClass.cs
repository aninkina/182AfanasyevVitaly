using System;

namespace LibPage18
{
    public delegate int MyDel(int a, int b);
    
    public static class TestClass
    {
        public static int TestMethod(int a, int b)
        {
            return a > b ? a : b;
        }
    }
}
