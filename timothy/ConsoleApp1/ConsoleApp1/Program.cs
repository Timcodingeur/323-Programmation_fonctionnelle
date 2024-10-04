﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;


namespace ConsoleApp1
{
    public record WeatherData(Hourly hourly);

    public record Hourly(string[] time, float[] temperature_2m, float[] precipitation, float[] wind_speed_10m);
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            using HttpClient client = new HttpClient();
            string url = "https://api.open-meteo.com/v1/forecast?latitude=46.3833&longitude=6.2348&hourly=temperature_2m,precipitation,wind_speed_10m";

            var response = await client.GetStringAsync(url);
            var weatherData = JsonConvert.DeserializeObject<WeatherData>(response);
            Hourly hourly = weatherData.hourly;

            Console.WriteLine("Best running hours");
            foreach (var x in GetBestRunningHours(hourly))
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("average");
            Console.WriteLine(CalculateAverages(hourly));
            Console.WriteLine("Count Ideal");
            Console.WriteLine(CountIdealSportHours(hourly));

        }

        public static IEnumerable<(string Time, float Temperature, float WindSpeed)> GetBestRunningHours(Hourly hourly)
        {
        
            return hourly.time
                .Select((t, index) => new { Time = t, Temperature = hourly.temperature_2m[index], Precipitation = hourly.precipitation[index], WindSpeed = hourly.wind_speed_10m[index] })
                .Where(x => x.Temperature >= 18 && x.Temperature <= 22 && x.Precipitation == 0 && x.WindSpeed < 10)
                .Select(x => (x.Time, x.Temperature, x.WindSpeed));

           
        }


        public static (float AverageTemperature, float AverageWindSpeed) CalculateAverages(Hourly hourly)
        {
            var averageTemperature = hourly.temperature_2m.Average();
            var averageWindSpeed = hourly.wind_speed_10m.Average();

            return (averageTemperature, averageWindSpeed);
        }

        public static int CountIdealSportHours(Hourly hourly)
        {
            return hourly.time
                .Select((t, index) => new { Temperature = hourly.temperature_2m[index], Precipitation = hourly.precipitation[index], WindSpeed = hourly.wind_speed_10m[index] })
                .Aggregate(0, (count, hour) =>
                {
                    // Incrémenter le compteur si les conditions sont idéales
                    if (hour.Temperature >= 15 && hour.Temperature <= 25 && hour.Precipitation == 0 && hour.WindSpeed < 15)
                        return count + 1;
                    else
                        return count;
                });
        }
    }
}
