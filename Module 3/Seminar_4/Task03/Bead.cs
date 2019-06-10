using System;

namespace Task03
{
    public delegate void BeadRadiusChanged();

    public class Bead
    {
        double r;

        public event BeadRadiusChanged BeadRadiusChangedEvent;

        public double Radius { get => r; }
        
        public Bead(double radius)
        {
            if (radius <= 0)
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius of a bead must be a positive number.");
            r = radius;
        }

        public void ChangeRadius(double radius)
        {
            if (radius <= 0)
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius of a bead must be a positive number.");
            r = radius;
            OnRadiusChanged();
        }

        protected virtual void OnRadiusChanged()
        {
            BeadRadiusChangedEvent?.Invoke();
        }
    }
}
