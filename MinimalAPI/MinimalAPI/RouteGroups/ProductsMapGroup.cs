using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MinimalAPI.EndpointFilters;
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

        groupBuilder.MapGet("/{id:int}", (HttpContext context, int id) =>
        {
            var product = products.FirstOrDefault(product => product.Id == id);

            return product is null ? Results.NotFound(new { message = "Product no found." }) : Results.Ok(product);
        });

        groupBuilder.MapPost("/", (HttpContext context, Product product) =>
        {
            products.Add(product);

            return Results.Ok(new { message = "Product added." });
        }).AddEndpointFilter<CustomEndpointFilter>();

        groupBuilder.MapPut("/{id:int}", (HttpContext context, [FromBody] Product product, [FromQuery] int id) =>
        {
            var content = products.FirstOrDefault(temp => temp.Id == id);

            if (content is null) return Results.NotFound(new { message = "Product no found." });

            content.Name = product.Name;

            return Results.Ok(new { message = "Product Updated." });
        });

        groupBuilder.MapDelete("/{id:int}", (HttpContext context, int id) =>
        {
            var product = products.FirstOrDefault(product => product.Id == id);

            if (product is null)
            {
                // return Results.NotFound(new { message = "Product no found." });

                return Results.ValidationProblem(new Dictionary<string, string[]>
                    { { "id", ["Incorrect product id"] } });
            }

            products.Remove(product);

            return Results.Ok(new { message = "Product deleted." });
        });

        return groupBuilder;
    }
}