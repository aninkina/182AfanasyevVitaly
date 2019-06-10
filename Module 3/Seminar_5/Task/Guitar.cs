using System;

namespace Task
{
    public class Guitar : MusicalInstrument
    {
        byte gStrings;
        public byte GStrings
        {
            get => gStrings;
            set
            {
                if ((value < 2) || (value > 20))
                    throw new ArgumentException("Number of plates should be [2; 20].");
                gStrings = value;
            }
        }
        
        public override string ToString()
        {
            return $"Guitar. Number of strings: {GStrings}, " + base.ToString();
        }

        public Guitar(string name, bool isCheckMark, byte gStrings) : base(name, isCheckMark)
        {
            GStrings = gStrings;
        }
    }
}
