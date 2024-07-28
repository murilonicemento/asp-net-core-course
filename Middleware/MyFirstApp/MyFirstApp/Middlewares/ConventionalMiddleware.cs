namespace MyFirstApp.Middlewares;

public class ConventionalMiddleware
{
    private readonly RequestDelegate _next;

    public ConventionalMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        if (httpContext.Request.Query.ContainsKey("firstname") && httpContext.Request.Query.ContainsKey("lastname"))
        {
            var fullname = httpContext.Request.Query["firstname"] + " " + httpContext.Request.Query["lastname"];
            await httpContext.Response.WriteAsync(fullname);
        }
        
        await _next(httpContext);
    }
}

public static class ConventionalMiddlewareExtension
{
    public static IApplicationBuilder UseConventionalMiddleware(this IApplicationBuilder app) 
        => app.UseMiddleware<ConventionalMiddleware>();
}