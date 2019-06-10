using System;

namespace Task01
{
    public class Circle
    {
        Point center;
        double rad;
        
        public double Rad
        {
            get => rad;
            set
            {
                if (value < 0)
                    throw new ArgumentException(@"Radius can't be a negative number.");
                rad = value;
            }
        }
        
        public Circle(double x, double y, double rad)
        {
            center = new Point(x, y);
            Rad = rad;
        }

        public override string ToString()
        {
            return $"Center: ({center.X:F3};{center.Y:F3}), Radius: {Rad:F3}";
        }
    }
}
