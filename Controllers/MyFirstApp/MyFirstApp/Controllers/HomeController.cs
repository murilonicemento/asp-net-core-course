using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Models;

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
    
    [Route("person")]
    public JsonResult Person()
    {
        Person person = new Person() { Id = Guid.NewGuid(), FirstName = "Ronaldo", LastName = "Silva", Age = 123 };
        // return new JsonResult(person);
        return Json(person);
    }
    
    [Route("file-download")]
    public VirtualFileResult FileDownload()
    {
        // return new VirtualFileResult("/Sample.txt", "text/plain");
        return File("/Sample.txt", "text/plain");
    }
    
    [Route("file-download2")]
    public PhysicalFileResult FileDownload2()
    {
        // return new PhysicalFileResult(@"~/aspnetcore/controllers/MyFirstApp/wwwroot/Sample.txt", "text/plain");
        return PhysicalFile(@"~/aspnetcore/controllers/MyFirstApp/wwwroot/Sample.txt", "text/plain");
    }
    
    [Route("file-download3")]
    public FileContentResult FileDownload3()
    {
        byte[] bytes = System.IO.File.ReadAllBytes(@"~/aspnetcore/controllers/MyFirstApp/wwwroot/Sample.txt");
        // return new FileContentResult(bytes, "text/plain");
        return File(bytes, "text/plain");
    }
    
    [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
    public string Contact()
    {
        return "Contact";
    }
}