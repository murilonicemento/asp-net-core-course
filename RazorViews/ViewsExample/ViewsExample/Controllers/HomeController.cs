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
        return View(people); // Index.cshtml
        // return View("abc"); // abc.cshtml
        // return new ViewResult() { ViewName = "abc" };
    }

    [Route("person-details/{name}")]
    public IActionResult Details(string? name)
    {
        if (name is null)
            return Content("Person name can't be null");

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

        Person? matchingPerson = people.Where(temp => temp.Name == name).FirstOrDefault();

        return View(matchingPerson);
    }
}