using System;

namespace Task03
{
    public class TemperatureConvertImp
    {
        public TemperatureConvertImp()
        {
        }
        
        public double CelciusToFahrenheit(double temperature)
        {
            return 9 * temperature / 5 + 32;
        }

        public double FahrenheitToCelcius(double temperature)
        {
            return 5 * (temperature - 32) / 9;
        }
    }
}
