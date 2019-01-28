using System;

namespace Task01
{
    public class Converter
    {
        public Converter()
        {
        }

        public string Convert(string str, ConvertRule cr)
        {
            return cr?.Invoke(str);
        }
    }
}
