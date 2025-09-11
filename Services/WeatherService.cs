using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WeatherAPI.Models;
using WeatherAPI.Processes;

namespace WeatherAPI.Services
{
    public static class WeatherService
    {
        private static List<Weather> weather;

        public static List<Weather> GetWeather(int zip, bool isXML)
        {
            try
            {
                string url = string.Empty;

                //Get the URL
                if (isXML)
                    url = string.Format(URLs.OpenWeatherMapXML, zip, APIKeys.WeatherAPIKey);
                else
                    url = string.Format(URLs.OpenWeatherMapJSON, zip, APIKeys.WeatherAPIKey);

                //Create a webrequest to create the URL
                var httpRequest = (HttpWebRequest)WebRequest.Create(url);

                if (!isXML)
                    httpRequest.ContentType = "application/json; charset=utf-8";

                //Get the web response
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();

                //Use stream to get the API information
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    //Read the Stream to the End
                    var result = streamReader.ReadToEnd();

                    //Method to parse the XML (REST API) data
                    if (isXML)
                    {
                        //Convert stream to XDocument (Not XMLDocument)
                        XDocument doc = XDocument.Parse(result);
                        weather = ParseWeatherDataXML.PerformParse(doc);
                    }
                    else
                    {
                        weather = ParseWeatherDataJSON.PerformParse(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new ArgumentException("The zip code is invalid");
            }

            return weather;
        }
    }
}
