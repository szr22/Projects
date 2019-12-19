using System;

namespace PriceCheck
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string TemperatureF => (32 + (int)(TemperatureC / 0.5556)).ToString() + " F";

        public string Summary { get; set; }
    }
}
