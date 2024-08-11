var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();
#pragma warning disable ASP0014
app.UseEndpoints((endpoints) =>
{
    endpoints.MapGet("/countries", async (context) =>
    {
        await context.Response.WriteAsync(@"
         1, United States
         2, Canada
         3, United Kingdom
         4, India
         5, Japan");
    });

    endpoints.MapGet("/contries/{id:int:min(1):max(100)}", async (context) =>
    {
        int? id = Convert.ToInt32(context.Request.RouteValues["id"]);

        if (Convert.ToInt32(id) > 100)
        {
            await context.Response.WriteAsync("The CountryID should be between 1 and 100");
            // definir o status code 400
        }

        if (Convert.ToInt32(id) > 5 || Convert.ToInt32(id) < 1)
        {
            await context.Response.WriteAsync("[No Country]");
            // definir o status code 404
        }

        switch (id)
        {
            case 1:
                await context.Response.WriteAsync("United States");
                break;
            case 2:
                await context.Response.WriteAsync("Canada");
                break;   
            case 3:
                await context.Response.WriteAsync("United Kingdom");
                break; 
            case 4:
                await context.Response.WriteAsync("India");
                break; 
            default:
                await context.Response.WriteAsync("Japan");
                break; 
        }

        
    });
});
app.MapGet("/", () => "Hello World!");

app.Run();