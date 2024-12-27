using MinimalAPI.RouteGroups;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

var mapGroup = app.MapGroup("/products").ProductsApi();

app.Run();