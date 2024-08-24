using Microsoft.AspNetCore.Mvc;
using ModelBinding_And_Validations.Models;

namespace ModelBinding_And_Validations.Controllers;

public class HomeController : Controller
{
  [Route("bookstore/{bookid?}/{isLoggedin?}")]
  // public IActionResult Index(int? bookid, bool? isLoggedin) => Utiliza ordem de prioridade para definir o tipo de parâmetro (Route data, Query string)
  // public IActionResult Index([FromRoute] int? bookid, [FromRoute] bool? isLoggedin) => Aceita dados do tipo route data
  // public IActionResult Index([FromQuery] int? bookid, [FromQuery] bool? isLoggedin) => Aceita dados do tipo query string
  // public IActionResult Index([FromQuery] int? bookid, [FromQuery] bool? isLoggedin, Book book) => Model Biding
  // public IActionResult Index([FromRoute] int? bookid, [FromRoute] bool? isLoggedin, [FromRoute] Book book) => Model Biding FromRoute
  public IActionResult Index([FromQuery] int? bookid, [FromQuery] bool? isLoggedin, [FromQuery] Book book) // Model Biding FromQuery
  {
    // url => bookstore?bookid=10&isLoggedin=true&author=Ronaldo

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

    return Content($"Book id: {bookid}, Book {book}", "text/plain");
  }
}