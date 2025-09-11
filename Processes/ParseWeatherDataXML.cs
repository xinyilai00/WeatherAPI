using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WeatherAPI.Models;

namespace WeatherAPI.Processes
{
    public static class ParseWeatherDataXML
    {
        public static List<Weather> PerformParse(XDocument doc)
        {
            //Get XML Values
            /*****************************************************************************
             How to get XML data with "Attibutes"
             
             <city id="0" name="Bronx">
               <coord lon="-73.8196" lat="40.8261"></coord>
             </city>

             //We want to get the longitude ("lon") from above. Below is the template
             doc.Root.Element("NODE NAME").Element("NODE NAME").Attribute("ATTRIBUTE NAME").Value;
             //Below are the values need to get the longitude
             doc.Root.Element("city).Element("coord").Attribute("lon").Value;
            
             <city id="0" name="Bronx">
               <coord lon="-73.8196" lat="40.8261"></coord>
             </city>

             //We want to get the name of the city. Below is the template
             doc.Root.Element("NODE NAME").Attribute("ATTRIBUTE NAME").Value;
             //Below are the values used to get the name of the city
             doc.Root.Element("city").Attribute("name").Value;
             *****************************************************************************/

            string city = doc.Root.Element("city").Attribute("name").Value;
            string longitude = doc.Root.Element("city").Element("coord").Attribute("lon").Value;
            string latitude = doc.Root.Element("city").Element("coord").Attribute("lat").Value;
            string currentTemp = doc.Root.Element("temperature").Attribute("value").Value;
            string lowTemp = doc.Root.Element("temperature").Attribute("min").Value;
            string highTemp = doc.Root.Element("temperature").Attribute("max").Value;
            string feelsLike = doc.Root.Element("feels_like").Attribute("value").Value;
            string wind = doc.Root.Element("wind").Element("speed").Attribute("name").Value;
            string clouds = doc.Root.Element("clouds").Attribute("name").Value;

            //Convert Temperature Values
            currentTemp = ConvertTemperatures.FromKelvinToFahrenheit(currentTemp).ToString("#,##");
            lowTemp = ConvertTemperatures.FromKelvinToFahrenheit(lowTemp).ToString("#,##");
            highTemp = ConvertTemperatures.FromKelvinToFahrenheit(highTemp).ToString("#,##");
            feelsLike = ConvertTemperatures.FromKelvinToFahrenheit(feelsLike).ToString("#,##");

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
