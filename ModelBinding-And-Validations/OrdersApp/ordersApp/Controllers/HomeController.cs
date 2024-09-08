using Microsoft.AspNetCore.Mvc;

namespace ordersApp.Controllers;

public class HomeController : Controller
{
  [Route("order")]
  // url => OrderDate=2025-12-31T22:00:00&InvoicePrice=160&Products[0].ProductCode=1&Products[0].Price=15&Products[0].Quantity=10&Products[1].ProductCode=2&Products[1].Price=2&Products[1].Quantity=5
  public IActionResult Index()
  {
    if (!ModelState.IsValid)
    {
      List<string> errors = ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage).ToList();

      return BadRequest(string.Join("\n", errors));
    }

    Random random = new Random();

    return Content($"{random.Next(1, 999999)}");
  }
}