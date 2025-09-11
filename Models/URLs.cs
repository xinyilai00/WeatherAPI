using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
    public static class URLs
    {
        public static string OpenWeatherMapXML { get; } =
            "http://api.openweathermap.org/data/2.5/weather?zip={0}&mode=xml&appid={1}";

        public static string OpenWeatherMapJSON { get; } =
            "http://api.openweathermap.org/data/2.5/weather?zip={0}&appid={1}";
    }
}
