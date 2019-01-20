using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Linq;

namespace SilentCreekRoleplay.Server.Source.World
{
    public class WeatherAPI
    {
        public int Id { get; set; }

        public string Main { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }
    }

    public static class Weather
    {

        public static void Update()
        {
            var weatherId = 20;

            try
            {
                var weather = GetWeather();

                if (weather.Id < 300)
                {
                    weatherId = 16;
                }
                else if(weather.Id >= 300 && weather.Id < 600)
                {
                    weatherId = 12;
                }
                else if (weather.Id >= 600 && weather.Id < 700)
                {
                    weatherId = 5;
                }
                else if (weather.Id >= 700 && weather.Id < 800)
                {
                    weatherId = 9;
                }
                else if (weather.Id == 800)
                {
                    weatherId = 10;
                }
                else if (weather.Id > 800)
                {
                    weatherId = 9;
                }
            }
            catch(Exception e)
            {

            }

            SampSharp.GameMode.SAMP.Server.SetWeather(weatherId);
        }

        private static WeatherAPI GetWeather()
        {
            using (WebClient client = new WebClient())
            {
                // ToDo need other API
                var downloadedWeatherData = client.DownloadString("http://api.openweathermap.org/data/2.5/weather?q=London&APPID=629914fd1613117bb48e5cf556e028ab");
                var weather = JObject.Parse(downloadedWeatherData)["weather"];
                var weatherModel = weather.ToObject<List<WeatherAPI>>();
                return weatherModel.FirstOrDefault();
            }
        }
    }
}
