using Microsoft.AspNetCore.Mvc;
using PartialViews.Models;

namespace PartialViews.Controllers;

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

    [Route("programming-languages")]
    public IActionResult ProgrammingLanguages()
    {
        ListModel listModel = new ListModel()
        {
            ListTitle = "Programming Languages",
            ListItems = new List<string>()
            {
                "JavaScript",
                "Python",
                "Go",
                "PHP"
            }
        };

        // return new PartialViewResult() { ViewName = "_ListPartialView", Model = listModel };

        return PartialView("_ListPartialView", listModel);
    }
}