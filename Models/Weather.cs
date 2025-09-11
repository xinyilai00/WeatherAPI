using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
    public class Weather
    {
        public string City { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string CurrentTemp { get; set; }
        public string LowTemp { get; set; }
        public string HighTemp { get; set; }
        public string FeelsLike { get; set; }
        public string Wind { get; set; }
        public string Clouds { get; set; }
    }

}
