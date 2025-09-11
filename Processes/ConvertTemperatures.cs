using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI.Processes
{
    public static class ConvertTemperatures
    {
        public static double FromKelvinToFahrenheit(string temp)
        {
            double t = double.Parse(temp);

            return (((t - 273.15) * 9) / 5) + 32;
        }
    }
}
