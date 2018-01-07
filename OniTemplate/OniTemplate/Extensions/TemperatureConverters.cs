using System;

namespace OniTemplate.Extensions
{
    public static class TemperatureConverters
    {
        public static double ToCelcius(this double kelvin)
        {
            return Math.Round(kelvin - 273.15, 2);
        }

        public static double ToFarenheight(this double kelvin)
        {
            var farenheight = 1.8d * (kelvin - 273d) + 32d;
            return Math.Round(farenheight, 2);
        }
    }
}
