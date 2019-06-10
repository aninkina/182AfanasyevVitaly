using System;

namespace Task
{
    public class Drum : MusicalInstrument
    {
        byte plate;
        public byte Plate
        {
            get => plate;
            set
            {
                if ((value < 1) || (value > 15))
                    throw new ArgumentException("Number of plates should be [1; 15].");
                plate = value;
            }
        }
        
        public override string ToString()
        {
            return $"Drum. Number of plates: {Plate}, " + base.ToString();
        }

        public Drum(string name, bool isCheckMark, byte plate) : base(name, isCheckMark)
        {
            Plate = plate;
        }
    }
}
