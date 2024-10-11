using Microsoft.AspNetCore.Mvc;
using ViewComponents.Models;

namespace ViewComponents.Controllers;

public class HomeController : Controller
{
    [Route("/")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("/about")]
    public IActionResult About()
    {
        return View();
    }

    [Route("/friends-list")]
    public IActionResult LoadFriendList()
    {
        PersonGridModel personGridModel = new PersonGridModel()
        {
            GridTitle = "Persons",
            Persons = new List<Person>()
            {
                new Person()
                {
                    PersonName = "Flavinho do Pneu",
                    JobTitle = "Manager"
                },
                new Person()
                {
                    PersonName = "Zé Gatinha",
                    JobTitle = "Advogado"
                },
                new Person()
                {
                    PersonName = "Pitbull do Samba",
                    JobTitle = "Superman"
                }
            }
        };

        return ViewComponent("Grid", new
        {
            grid = personGridModel
        });
    }
}