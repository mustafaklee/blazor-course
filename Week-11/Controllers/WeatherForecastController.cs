using Microsoft.AspNetCore.Mvc;
using Week11.Models;

namespace Week11.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly VeriTabanýServis _servis;
    public WeatherForecastController(ILogger<WeatherForecastController> logger, VeriTabanýServis servis)
    {
        _logger = logger;
        _servis = servis;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("/urunler")]
    public List<Urun> UrunleriGetir()
    {
        return _servis.UrunleriGetir();
    }

}
