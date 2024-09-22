using Microsoft.AspNetCore.Mvc;
using ViewsExample.Models;
namespace ViewsExample.Controllers;

public class HomeController : Controller
{
    [Route("home")]
    [Route("/")]
    public IActionResult Index()
    {
        ViewData["appTitle"] = "Aps.Net Core Demo App";
        List<Person> people = new List<Person>()
        {
            new Person()
            {
                Name = "Dêcio",
                DateOfBirth = DateTime.Now,
                PersonGender = Person.Gender.Male
            },
            new Person()
            {
                Name = "Ronaldo",
                DateOfBirth = DateTime.Now,
                PersonGender = Person.Gender.Other
            },
            new Person()
            {
                Name = "Maria",
                DateOfBirth = DateTime.Now,
                PersonGender = Person.Gender.Female
            }
        };
        // ViewData["people"] = people;
        ViewBag.people = people;
        return View(); // Index.cshtml
        // return View("abc"); // abc.cshtml
        // return new ViewResult() { ViewName = "abc" };
    }
}