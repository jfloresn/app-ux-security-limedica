using app_ux_security_limedica.Infraestructure;
using app_ux_security_limedica.Model;
using Microsoft.AspNetCore.Mvc;

namespace app_ux_security_limedica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly UsuarioRepository _databaseService;
        private readonly ILogger<WeatherForecastController> _logger;


        public WeatherForecastController(UsuarioRepository databaseService, ILogger<WeatherForecastController> logger)
        {
            _databaseService = databaseService;
            _logger = logger;
        }

        [HttpGet("users")]
        public async IAsyncEnumerable<Usuario> ObtenerUsuarios()
        {
            await foreach (var usuario in _databaseService.ObtenerUsuariosAsync())
            {
                yield return usuario;
            }
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

    

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
    }
}
