using Microsoft.AspNetCore.Mvc;
using MonHttpCs.Models;
using System.Collections.Generic;
using System.Linq;

namespace MonHttpCs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly",
            "Cool", "Mild", "Warm", "Balmy",
            "Hot", "Sweltering", "Scorching"
        ];

        // GET: /weatherforecast
        [HttpGet]
        public IActionResult Get()
        {
            var weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            });
            return Ok(weatherForecasts);
        }

        // GET: /weatherforecast/{summaryIndex}
        [HttpGet("{summaryIndex}")]
        public IActionResult GetBySummaryIndex(int summaryIndex)
        {
            if (summaryIndex < 0 || summaryIndex >= Summaries.Length)
            {
                return BadRequest("Invalid summary index.");
            }

            var weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[summaryIndex]
            });
            return Ok(weatherForecasts);
        }

        // GET: /weatherforecast/summaries
        [HttpGet("summaries")]
        public IActionResult GetSummaries()
        {
            return Ok(Summaries);
        }
    }
}