using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers;

public class BankController : Controller
{
  [Route("/")]
  public IActionResult Index()
  {
    return Content("Welcome to the Best Bank");
  }

  [Route("/account-details")]
  public IActionResult AccountDetails()
  {
    return Json(new { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 });
  }

  [Route("/account-statement")]
  public IActionResult AccountStatement()
  {
    return File("/some.pdf", "application/pdf");
  }

  [Route("/get-current-balance/{accountNumber:int?}")]
  public IActionResult CurrentBalance()
  {
    int? accountNumber = Convert.ToInt32(HttpContext.Request.RouteValues["accountNumber"]?.ToString());

    if (accountNumber is null) return BadRequest("Account Number should be supplied");

    if (accountNumber != 1001) return BadRequest("Account Number should be 1001");

    return Content("5000");
  }
}