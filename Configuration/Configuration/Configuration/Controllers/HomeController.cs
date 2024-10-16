using Microsoft.AspNetCore.Mvc;

namespace Configuration.Controllers;

public class HomeController : Controller
{
    private readonly IConfiguration _configuration;

    public HomeController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [Route("/")]
    public IActionResult Index()
    {
        ViewBag.MyKey = _configuration["MyKey"] ?? string.Empty;
        ViewBag.MyApiKey = _configuration.GetValue<string>("MyApiKey", "oioioi") ?? string.Empty;

        ViewBag.ClientId = _configuration["WeatherApi:ClientId"] ?? string.Empty;
        // ViewBag.ClientSecret =
        //     _configuration.GetValue<string>("WeatherApi:ClientSecret", "1a2a5s3c2f8") ?? string.Empty;

        // IConfigurationSection section = _configuration.GetSection("WeatherApi");

        // ViewBag.ClientSecret = section["ClientSecret"] ?? string.Empty;
        
        // Options Pattern
        
        // loading values into new Options object
        
        // WeatherApiOptions options = _configuration.GetSection("WeatherApi").Get<WeatherApiOptions>()!;
        
        // ViewBag.ClientSecret = options.ClientSecret ?? string.Empty;
        
        // loading values into existing Options object
        WeatherApiOptions options = new WeatherApiOptions();

        _configuration.GetSection("WeatherApi").Bind(options);

        return View();
    }
}