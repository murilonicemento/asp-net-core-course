using Microsoft.Extensions.Primitives;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    // Status Code
    if (1 == 1)
    {
        context.Response.StatusCode = 200;
    }
    else
    {
        context.Response.StatusCode = 400;
    }
    await context.Response.WriteAsync("Hello");
    await context.Response.WriteAsync(" World");
    
    // Response Headers
    context.Response.Headers["MyKey"] = "my value";
    context.Response.Headers["Server"] = "My server";
    context.Response.Headers["Content-Type"] = "text/html";
    await context.Response.WriteAsync("<h1>Hello</h1>");
    await context.Response.WriteAsync("<h2>World</h2>");
    
    // Request
    string path = context.Request.Path;
    string method = context.Request.Method;
  
    context.Response.Headers["Content-type"] = "text/html";
    await context.Response.WriteAsync($"<p>{path}</p>");
    await context.Response.WriteAsync($"<p>{method}</p>");
    
    // Query String
    context.Response.Headers["Content-type"] = "text/html";
    if (context.Request.Method == "GET")
    {
        if (context.Request.Query.ContainsKey("id"))
        {
            string id = context.Request.Query["id"];
            await context.Response.WriteAsync($"<p>{id}</p>");
        }
    }
    
    // Request Headers
    context.Response.Headers["Content-type"] = "text/html";
    if (context.Request.Headers.ContainsKey("User-Agent"))
    {
        string userAgent = context.Request.Headers["User-Agent"];
        await context.Response.WriteAsync($"<p>{userAgent}</p>");
    }
    
    // Postman
    context.Response.Headers["Content-type"] = "text/html";
    if (context.Request.Headers.ContainsKey("AuthorizationKey"))
    {
        string auth = context.Request.Headers["AuthorizationKey"];
        await context.Response.WriteAsync($"<p>{auth}</p>");
    }
    
    // Get vs Post
    StreamReader reader = new StreamReader(context.Request.Body);
    string body = await reader.ReadToEndAsync();

    Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
    
    if (queryDict.ContainsKey("firstName"))
    {
        string firstName = queryDict["firstName"][0];
        await context.Response.WriteAsync(firstName);
    }
});

app.Run();