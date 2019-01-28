using System;
namespace Task08
{
    public class Plant
    {
        double growth, photosensitivity, frostresistance;

        public double Growth { get => growth; set => growth = value; }
        public double Photosensitivity
        {
            get => photosensitivity;
            set
            {
                if ((value < 0) || (value > 100))
                    throw new ArgumentException("Photosensitivity must be a real number from 0 to 100.");
                photosensitivity = value;
            }
        }
        public double Frostresistance
        {
            get => frostresistance;
            set
            {
                if ((value < 0) || (value > 100))
                    throw new ArgumentException("Frostresistance must be a real number from 0 to 100.");
                frostresistance = value;
            }
        }

        public Plant(double growth, double photosensitivity, double frostresistance)
        {
            Growth = growth;
            Photosensitivity = photosensitivity;
            Frostresistance = frostresistance;
        }

        public override string ToString()
        {
            return $"Growth: {Growth:F3}, Photosensitivity: {Photosensitivity:F3}, Frostresistance: {Frostresistance:F3}";
        }
    }
}
