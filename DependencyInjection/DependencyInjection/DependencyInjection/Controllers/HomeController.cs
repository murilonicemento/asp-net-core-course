using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts;

namespace DependencyInjection.Controllers;

public class HomeController : Controller
{
    // private readonly ICitiesService _citiesService;
    //
    // public HomeController(ICitiesService citiesService)
    // {
    //     _citiesService = citiesService;
    // }

    [Route("/")]
    public IActionResult Index([FromServices] ICitiesService citiesService)
    {
        List<string> cities = citiesService.GetCities();
        return View(cities);
    }
}