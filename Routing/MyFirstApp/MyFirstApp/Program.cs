var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    Endpoint endpoint = context.GetEndpoint();
    await context.Response.WriteAsync($"Endpoint: {endpoint.DisplayName}\n");
    await next(context);
});

// Habilita roteamento
app.UseRouting();

app.Use(async (context, next) =>
{
    Endpoint? endpoint = context.GetEndpoint();
    await context.Response.WriteAsync($"Endpoint: {endpoint.DisplayName}\n");
    await next(context);
});

// Cria os end points
app.UseEndpoints(endpoints =>
{
    // Adiciona os end points
    endpoints.MapGet("/map1", async (context) =>
    {
        await context.Response.WriteAsync("Hello map1");
    });
    
    endpoints.MapPost("/map2", async (context) =>
    {
        await context.Response.WriteAsync("Hello map2");
    });
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync($"Request received at: {context.Request.Path}");
});

app.Run();