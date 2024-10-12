using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts;

namespace DependencyInjection.Controllers;

public class HomeController : Controller
{
    private readonly ICitiesService _citiesService1;
    private readonly ICitiesService _citiesService2;
    private readonly ICitiesService _citiesService3;

    // Constructor Injection
    public HomeController(ICitiesService citiesService1, ICitiesService citiesService2, ICitiesService citiesService3)
    {
        _citiesService1 = citiesService1;
        _citiesService2 = citiesService2;
        _citiesService3 = citiesService3;
    }

    [Route("/")]
    // public IActionResult Index([FromServices] ICitiesService citiesService) => Method Injection
    public IActionResult Index()
    {
        List<string> cities = _citiesService1.GetCities();
        
        ViewBag.InstanceId_Cities_1 = _citiesService1.ServiceInstanceId;
        ViewBag.InstanceId_Cities_2 = _citiesService2.ServiceInstanceId;
        ViewBag.InstanceId_Cities_3 = _citiesService3.ServiceInstanceId;
        
        return View(cities);
    }
}