using Microsoft.AspNetCore.Mvc;

namespace ModelBinding_And_Validations.Controllers;

public class HomeController : Controller
{
  [Route("bookstore/{bookid?}/{isLoggedin?}")]
  public Microsoft.AspNetCore.Mvc.IActionResult Index(int? bookid, bool? isLoggedin)
  {
    // url => bookstore?bookid=10&isLoggedin=true

    if (bookid.HasValue == false)
    {
      return BadRequest("Book id is not supplied or empty.");
    }

    if (bookid <= 0)
    {
      return BadRequest("Book id can not be less than 1.");
    }

    if (bookid >= 100)
    {
      return BadRequest("Book id can not be greater than 100.");
    }

    if (isLoggedin == false)
    {
      return Unauthorized("User must be logged in.");
    }

    return Content($"Book id: {bookid}", "text/plain");
  }
}