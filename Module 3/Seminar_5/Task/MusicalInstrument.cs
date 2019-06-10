using System;

namespace Task
{
    public abstract class MusicalInstrument : ISound
    {
        public event EventHandler onSound;
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCheckMark { get; set; }
        
        public void DoSound()
        {
            onSound(this, new EventArgs());
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, IsCheckMark: {IsCheckMark}";
        }

        protected MusicalInstrument(string name, bool isCheckMark)
        {
            Name = name;
            IsCheckMark = isCheckMark;
        }
    }
}
