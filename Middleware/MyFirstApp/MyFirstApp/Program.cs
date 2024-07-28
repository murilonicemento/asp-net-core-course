using MyFirstApp.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

// Run
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello");
});

// Middleware Chain
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello\n");
    await next(context);
});

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello again");
});

// Custom Middleware Class
app.UseMiddleware<MyCustomMiddleware>();

// Custom Middleware Extensions
app.UseMyCustomMiddleware();

// Conventional Middleware Class
app.UseConventionalMiddleware();


app.Run();