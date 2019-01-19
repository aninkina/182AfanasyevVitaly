using System;

namespace Task04
{
    public class Robot
    {
        public event Action PositionChanged;
        public int X { get; private set; } 
        public int Y { get; private set; }

        public void Right() { X++; PositionChanged(); }
        public void Left() { X--; PositionChanged(); }
        public void Forward() { Y++; PositionChanged(); }
        public void Backward() { Y--; PositionChanged(); }

        public void Reset() { X = 0; Y = 0; }

        public string Position() => $"The Robot position: x = {X}, y = {Y}";
    }
}
