using System.Text.Json;
using MinimalAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

List<Product> products = new()
{
    new() { Id = 1, Name = "Phone" },
    new() { Id = 2, Name = "Notebook" },
    new() { Id = 3, Name = "TV" }
};

app.MapGet("/products",
    async context => { await context.Response.WriteAsync(JsonSerializer.Serialize(products)); });

app.MapGet("/products/{id:int}",
    async (HttpContext context, int id) =>
    {
        var product = products.FirstOrDefault(product => product.Id == id);

        if (product is null)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("Product no found.");

            return;
        }

        await context
            .Response
            .WriteAsync(JsonSerializer.Serialize(product));
    });

app.MapPost("/products", async (HttpContext context, Product product) =>
{
    products.Add(product);

    await context.Response.WriteAsync("Product added.");
});

app.Run();