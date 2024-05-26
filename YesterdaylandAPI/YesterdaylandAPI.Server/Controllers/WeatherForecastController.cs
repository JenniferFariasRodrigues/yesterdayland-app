using Microsoft.AspNetCore.Mvc;
using YesterdaylandAPI.Server;

namespace YesterdaylandAPI.Controllers
{
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

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}

//using microsoft.aspnetcore.mvc;

//namespace yesterdaylandapi.server.controllers
//{
//    [apicontroller]
//    [route("[controller]")]
//    public class weatherforecastcontroller : controllerbase
//    {
//        private static readonly string[] summaries = new[]
//        {
//            "freezing", "bracing", "chilly", "cool", "mild", "warm", "balmy", "hot", "sweltering", "scorching"
//        };

//        private readonly ilogger<weatherforecastcontroller> _logger;

//        public weatherforecastcontroller(ilogger<weatherforecastcontroller> logger)
//        {
//            _logger = logger;
//        }

//        [httpget(name = "getweatherforecast")]
//        public ienumerable<weatherforecast> get()
//        {
//            return enumerable.range(1, 5).select(index => new weatherforecast
//            {
//                date = datetime.now.adddays(index),
//                temperaturec = random.shared.next(-20, 55),
//                summary = summaries[random.shared.next(summaries.length)]
//            })
//            .toarray();
//        }
//    }
//}
