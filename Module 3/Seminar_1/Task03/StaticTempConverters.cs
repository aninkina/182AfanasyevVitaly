using System;

namespace Task03
{
    public class StaticTempConverters
    {
        public StaticTempConverters()
        {
        }
           
        public static double CelciusToFahrenheit(double temperature)
        {
            return 9 * temperature / 5 + 32;
        }
        
        public static double FahrenheitToCelcius(double temperature)
        {
            return 5 * (temperature - 32) / 9;
        }
  
        public static double CelciusToKelvin(double temperature)
        {
            return temperature + 273.15;
        }
        
        public static double KelvinToCelcius(double temperature)
        {
            return temperature - 273.15;
        }
        
        public static double CelciusToRankine(double temperature)
        {
            return (temperature + 273.15) * 9 / 5;
        }
        
        public static double RankineToCelcius(double temperature)
        {
            return (temperature * 5 / 9) - 273.15;
        }
        
        public static double CelciusToReaumur(double temperature)
        {
            return temperature * 0.8;
        }
        
        public static double ReaumurToCelcius(double temperature)
        {
            return temperature / 0.8;
        }
    }
}
