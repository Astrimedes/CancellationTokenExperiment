using Microsoft.AspNetCore.Mvc;

namespace CancellationTokenExperimentA.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
	private static readonly string[] Summaries = new[]
	{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};

	private readonly ILogger<WeatherForecastController> _logger;

	public WeatherForecastController(ILogger<WeatherForecastController> logger)
	{
		_logger = logger;
	}

	[HttpGet]
	public async Task<IEnumerable<WeatherForecast>?> Get(CancellationToken cancelToken)
	{
		try
		{
			var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();

			await Task.Delay(TimeSpan.FromSeconds(5), cancelToken);

			_logger.LogInformation("{0}: {1}:\n........Delay Completed, returning result...", DateTime.Now, HttpContext.Request.Headers.UserAgent);

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogError("{0}: {1}:\n........ERROR: {2}", DateTime.Now, HttpContext.Request.Headers.UserAgent, ex);
			return null;
		}
	
	}
}
