using System;

namespace Task05
{
    public class CD : UnitsBase {
        private int playing_time; // время звучания диска
        
        public int PlayingTime { get => playing_time; private set => playing_time = value; }
        
        public CD(int unit_code, double price, string name, 
                int playingTime) : base(unit_code, price, name)
        {
            PlayingTime = playingTime;
        }

        public override string ToString()
        {
            return $"CD: Name: {Name}, Unit code: {UnitCode}, Playing time: {PlayingTime}";
        }
    }
}
