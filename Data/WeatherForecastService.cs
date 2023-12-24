using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSV.Data
{
	public class WeatherForecastService
	{

		private static readonly Random SharedRandom = new Random();

		private static readonly string[] Summaries = new[]
		{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};

		public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
		{
			return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = startDate.AddDays(index),
				TemperatureC = SharedRandom.Next(-20, 55),
				Summary = Summaries[SharedRandom.Next(Summaries.Length)]
			}).ToArray());
		}
	}
}