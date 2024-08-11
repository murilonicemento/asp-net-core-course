using Microsoft.AspNetCore.Mvc;

namespace MyFirstApp.Controllers;

public class HomeController : Controller
{
    [Route("home")]
    [Route("/")]
    public ContentResult Index()
    {
        // return new ContentResult()
        // {
        //     Content = "Hello from index",
        //     ContentType = "text/plain",
        //     StatusCode = 200
        // };

        return Content("<h1>Welcome</h1><p>Hello from index</p>", "text/html");
    }
    
    [Route("about")]
    public string About()
    {
        return "About";
    }
    
    [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
    public string Contact()
    {
        return "Contact";
    }
}