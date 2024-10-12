using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts;

namespace DependencyInjection.Controllers;

public class HomeController : Controller
{
    private readonly ICitiesService _citiesService;

    public HomeController()
    {
        _citiesService = new CitiesService();
    }

    [Route("/")]
    public IActionResult Index()
    {
        List<string> cities = _citiesService.GetCities();
        return View(cities);
    }
}