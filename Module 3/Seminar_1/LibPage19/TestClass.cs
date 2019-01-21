using System;

namespace LibPage19
{
    public delegate int MyDel(double a, double b);
    
    public static class TestClass
    {
        public static int TestMethod(double a, double b)
        {
            return (int)a + (int)b;
        }
    }
}
