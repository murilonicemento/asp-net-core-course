using Microsoft.AspNetCore.Mvc;

namespace IActionResult.Controllers;

public class HomeController : Controller
{
    [Route("book")]
    public Microsoft.AspNetCore.Mvc.IActionResult Index()
    {
        if (!Request.Query.ContainsKey("bookid"))
        {
            // Response.StatusCode = 400;
            // return Content("Book id is not supplied.", "text/plain");
            return BadRequest("Book id is not supplied.");
        }

        if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
        {
            // Response.StatusCode = 400;
            // return Content("Book id can not be null or empty", "text/plain");
            return BadRequest("Book id can not be null or empty.");
        }

        int boookid = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);

        if (boookid <= 0)
        {
            // Response.StatusCode = 400;
            // return Content("Book id can not be less than 1");
            return BadRequest("Book id can not be less than 1.");
        }
        
        if (boookid >= 100)
        {
            // Response.StatusCode = 400;
            // return Content("Book id can not be greater than 100");
            return BadRequest("Book id can not be greater than 100.");
        }

        if (Convert.ToBoolean(Request.Query["isloggedin"] == false))
        {
            // Response.StatusCode = 401;
            // return Content("User must be logged in.");
            return Unauthorized("User must be logged in.");
        }
        
            
        Response.StatusCode = 200;
        // return File("/Sample.txt", "text/plain");
        
        // return new RedirectToActionResult("Books", "Store", new {}); // 302 - Found
        // return RedirectToAction("Books", "Store", new { id = boookid });
        // return new RedirectToActionResult("Books", "Store", new {}, true); // 301 - Moved permanently
        // return RedirectToActionPermanent("Books", "Store", new { }); 
        
        // return new LocalRedirectResult($"store/books/{boookid}"); // 302
        // return LocalRedirect($"store/books/{boookid}"); // 302
        
        // return new LocalRedirectResult($"store/books/{boookid}", true); // 301
        // return LocalRedirectPermanent($"store/books/{boookid}"); // 301
        
        // return Redirect($"store/books/{boookid}"); // 302
        return RedirectPermanent($"store/books/{boookid}"); // 301
    }
}
