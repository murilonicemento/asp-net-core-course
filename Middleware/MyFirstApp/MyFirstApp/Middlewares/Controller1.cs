using Microsoft.AspNetCore.Mvc;

namespace MyFirstApp.Middlewares;

public class Controller1 : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}