using Microsoft.AspNetCore.Mvc;

namespace IActionResult.Controllers;

public class StoreController : Controller
{
    [Route("/store/books/{id}")]
    public Microsoft.AspNetCore.Mvc.IActionResult Books()
    {
        int id = Convert.ToInt32(Request.RouteValues["id"]?.ToString());
        return Content($"<h1>Books Store {id}</h1>", "text/html");
    }
}