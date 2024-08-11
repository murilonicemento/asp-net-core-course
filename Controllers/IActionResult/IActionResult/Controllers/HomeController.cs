using Microsoft.AspNetCore.Mvc;

namespace IActionResult.Controllers;

public class HomeController : Controller
{
    [Route("book")]
    public Microsoft.AspNetCore.Mvc.IActionResult Index()
    {
        if (!Request.Query.ContainsKey("bookid"))
        {
            Response.StatusCode = 400;
            return Content("Book id is not supplied.", "text/plain");
        }

        if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
        {
            Response.StatusCode = 400;
            return Content("Book id can not be null or empty", "text/plain");
        }

        int boookid = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);

        if (boookid <= 0)
        {
            Response.StatusCode = 400;
            return Content("Book id can not be less than 1");
        }
        
        if (boookid >= 100)
        {
            Response.StatusCode = 400;
            return Content("Book id can not be greater than 100");
        }

        if (Convert.ToBoolean(Request.Query["isloggedin"] == true))
        {
            Response.StatusCode = 401;
            return Content("User must be logged in.");
        }
        
            
        Response.StatusCode = 200;
        return File("/Sample.txt", "text/plain");
    }
}