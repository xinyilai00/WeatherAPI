using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using WeatherAPI.Models;

namespace WeatherAPI.Processes
{
    public static class ParseWeatherDataJSON
    {
        public static List<Weather> PerformParse(string result)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var obj = js.Deserialize<dynamic>(result);

            string city = obj["name"];
            string longitude = obj["coord"]["lon"].ToString();
            string latitude = obj["coord"]["lat"].ToString();
            string currentTemp = obj["main"]["temp"].ToString();
            string lowTemp = obj["main"]["temp_min"].ToString();
            string highTemp = obj["main"]["temp_max"].ToString();
            string feelsLike = obj["main"]["feels_like"].ToString();
            string wind = "";
            string clouds = obj["weather"][0]["description"].ToString();

            //Convert Temperature Values
            currentTemp = ConvertTemperatures.FromKelvinToFahrenheit(currentTemp).ToString("###");
            lowTemp = ConvertTemperatures.FromKelvinToFahrenheit(lowTemp).ToString("###");
            highTemp = ConvertTemperatures.FromKelvinToFahrenheit(highTemp).ToString("###");
            feelsLike = ConvertTemperatures.FromKelvinToFahrenheit(feelsLike).ToString("###");

            var weather = new List<Weather>
            {
                new Weather
                {
                    City = city,
                    Longitude = longitude,
                    Latitude = latitude,
                    CurrentTemp = currentTemp,
                    LowTemp = lowTemp,
                    HighTemp = highTemp,
                    FeelsLike = feelsLike,
                    Wind = wind,
                    Clouds = clouds
                }
            };

            return weather;
        }
    }
}
