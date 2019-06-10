using System;

namespace Task04
{
    public class UIString
    {
        string str = "Default text";
        public string Str { get { return str; } set { str = value; } }

        public void NewStringValueHappenedHandler(string s)
        {
            Str = s;
        }
    }
}
