namespace MyFirstApp.Middlewares;

public class MyCustomMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("My custom middleware start");
        await next(context);
        await context.Response.WriteAsync("My custom middleware ends");
    }
}

public static class CustomMiddlewareExtension
{
    public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app) 
        => app.UseMiddleware<MyCustomMiddleware>();
}