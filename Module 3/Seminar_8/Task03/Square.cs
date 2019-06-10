using System;

namespace Task03
{
    public class Square : IFigure
    {
        public double Side { get; set; }
        
        public double Area { get => Side * Side; }

        public Square() : this(1) { }
        
        public Square(double side)
        {
            Side = side;
        }

        public override string ToString()
        {
            return $"Side: {Side:F3}";
        }
    }
}
