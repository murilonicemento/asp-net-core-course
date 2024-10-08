using Microsoft.AspNetCore.Mvc;
using Validations.Controllers.CustomModelsBinders;
using Validations.Models;

namespace Validations.Controllers;

public class HomeController : Controller
{
  [Route("register")]
  // [Bind(nameof(Person.PersonName), nameof(Person.Email), nameof(Person.Password), nameof(Person.ConfirmPassword))]
  // [FromBody]
  // [ModelBinder(BinderType = typeof(PersonModelBinder))] 
  public IActionResult Index(Person person, [FromHeader(Name = "User-Agent")] string UserAgent)
  {
    if (!ModelState.IsValid)
    {
      List<string> errors = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage).ToList();
      // List<string> errors = new List<string>();

      // foreach (var value in ModelState.Values)
      // {
      //   foreach (var error in value.Errors)
      //   {
      //     errors.Add(error.ErrorMessage);
      //   }
      // }

      return BadRequest(string.Join("\n", errors));
    }

    return Content($"{person}, {UserAgent}");
  }
}