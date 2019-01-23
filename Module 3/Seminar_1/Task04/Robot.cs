using System;

namespace Task04
{
    public class Robot
    {
        public event EventHandler PositionChanged;
        public int X { get; private set; } 
        public int Y { get; private set; }

        public void Right() { X++; PositionChanged?.Invoke(this, null); }
        public void Left() { X--; PositionChanged?.Invoke(this, null); }
        public void Forward() { Y++; PositionChanged?.Invoke(this, null); }
        public void Backward() { Y--; PositionChanged?.Invoke(this, null); }

        public void Reset() { X = 0; Y = 0; }

        public string Position() => $"The Robot position: x = {X}, y = {Y}";
    }
}
