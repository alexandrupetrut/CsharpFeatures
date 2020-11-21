using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();
            var results = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55)
            }).ToArray();

            foreach (var record in results)
            {
                // standard check
                /* 
                    if (record.TemperatureF < 0)
                    {
                        record.Summary = "Well below freezing";
                    }
                */


                // Relational Pattern Matching is   >  <  >=  <=   
                // allow us to do the equivalent of nested if-else statements in a compact manner

                // Logical Pattern Matching is   'and'  'or'  'not'

                record.Summary = record.TemperatureF switch
                {
                    < 0                 => "Well below freezing",
                    >= 0 and < 32       => "Freezing",
                    32 or 212           => "Exactly freezing OR boiling",
                    > 32 and < 65       => "Cool",
                    >= 65 and < 85      => "Warm",
                    >= 85               => null
                //  _                   => "Unknown"   - this is redundant since we already covered everything, no default pattern left
                };

                // previous if-checks for nulls
                if (record.Summary == null)
                    Console.WriteLine($"Missing summary for temperature value {record.TemperatureF} F");
                if (record.Summary is null)
                    Console.WriteLine($"Missing summary again for temperature value {record.TemperatureF} F");
                if (record.Summary != null)
                    Console.WriteLine($"Logging that there is weather forecast summary for the temperature {record.TemperatureF} F");

                // newly introduced 'is not' Pattern Matching
                if (record.Summary is not null)
                    Console.WriteLine($"Logging that there is weather forecast summary for the temperature {record.TemperatureF} F");
            }

            return Task.FromResult(results);
        }
    }
}
