using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Models;

namespace MinimalAPI.RouteGroups;

public static class ProductsMapGroup
{
    public static RouteGroupBuilder ProductsApi(this RouteGroupBuilder groupBuilder)
    {
        List<Product> products = new()
        {
            new() { Id = 1, Name = "Phone" },
            new() { Id = 2, Name = "Notebook" },
            new() { Id = 3, Name = "TV" }
        };

        groupBuilder.MapGet("/",
            async context => { await context.Response.WriteAsync(JsonSerializer.Serialize(products)); });

        groupBuilder.MapGet("/{id:int}",
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

        groupBuilder.MapPost("/", async (HttpContext context, Product product) =>
        {
            products.Add(product);

            await context.Response.WriteAsync("Product added.");
        });

        groupBuilder.MapPut("/{id:int}", async (HttpContext context, [FromBody] Product product, [FromQuery] int id) =>
        {
            var content = products.FirstOrDefault(temp => temp.Id == id);

            if (content is null)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Product no found.");

                return;
            }

            content.Name = product.Name;

            await context.Response.WriteAsync("Product Updated.");
        });

        groupBuilder.MapDelete("/{id:int}", async (HttpContext context, int id) =>
        {
            var product = products.FirstOrDefault(product => product.Id == id);

            if (product is null)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Product no found.");

                return;
            }

            products.Remove(product);

            await context.Response.WriteAsync("Product deleted.");
        });

        return groupBuilder;
    }
}