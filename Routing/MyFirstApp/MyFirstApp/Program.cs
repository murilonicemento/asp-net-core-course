using MyFirstApp.CustomConstraints;

var builder = WebApplication.CreateBuilder(args);
// adiciona a constraint personalizada
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("name", typeof(CustomContraint));
});
var app = builder.Build();

// app.Use(async (context, next) =>
// {
//     Endpoint endpoint = context.GetEndpoint();
//     await context.Response.WriteAsync($"Endpoint: {endpoint.DisplayName}\n");
//     await next(context);
// });

// Habilita roteamento
app.UseRouting();

// app.Use(async (context, next) =>
// {
//     Endpoint? endpoint = context.GetEndpoint();
//     await context.Response.WriteAsync($"Endpoint: {endpoint?.DisplayName}\n");
//     await next(context);
// });

// Cria os end points

#pragma warning disable ASP0014
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

    endpoints.Map("files/{filename}.{extension}", async (context) =>
    {
        string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
        await context.Response.WriteAsync($"In file {filename} and have the {extension} extension");
    });
    
    // endpoints.Map("employee/profile/{employeename}", async (context) =>
    // {
    //     string? employee = context.Request.RouteValues["employeename"].ToString();
    //     await context.Response.WriteAsync($"Employee name is {employee}");
    // });
    
    // Default Parameters
    // endpoints.Map("/employee/profile/{employeename=ronaldo}", async (context) =>
    // {
    //     string? employee = context.Request?.RouteValues["employeename"]?.ToString();
    //     await context.Response.WriteAsync($"Employee name is {employee}");
    // });
    
    // Optional Parameters
    // endpoints.Map("/products/details/{id?}", async (context) =>
    // {
    //     int? id = Convert.ToInt32(context.Request?.RouteValues["id"]);
    //     await context.Response.WriteAsync($"Product id is {id}");
    // });
    
    // Route constraints
    endpoints.Map("/products/details/{id:int?}", async (context) =>
    {
        int? id = Convert.ToInt32(context.Request?.RouteValues["id"]);
        await context.Response.WriteAsync($"Product id is {id}");
    });
    
    endpoints.Map("daily-digest-report/{reportdate:datatime}", async (context) =>
    {
        DateTime? reportDate = Convert.ToDateTime(context.Request?.RouteValues["datetime"]);
        await context.Response.WriteAsync($"Product id is {reportDate.Value.ToShortDateString()}");
    });
    
    // Global Universal Identifier
    endpoints.Map("cities/{cityid:guid}", async context =>
    {
        Guid? id = Guid.Parse(context.Request?.RouteValues["cityid"]?.ToString()!);

        await context.Response.WriteAsync($"GUID id is - {id}");
    });
    
    endpoints.Map("cities/{cityid:guid}", async context =>
    {
        Guid? id = Guid.Parse(context.Request?.RouteValues["cityid"]?.ToString()!);

        await context.Response.WriteAsync($"GUID id is - {id}");
    });
    
    // tamanho mínino
    endpoints.Map("/employee/profile/{employeename:minlength(4)}", async (context) =>
    {
        string? employee = context.Request?.RouteValues["employeename"]?.ToString();
        await context.Response.WriteAsync($"Employee name is {employee}");
    });
    
    // tamanho máximo
    endpoints.Map("/employee/profile/{employeename:maxlength(10)}", async (context) =>
    {
        string? employee = context.Request?.RouteValues["employeename"]?.ToString();
        await context.Response.WriteAsync($"Employee name is {employee}");
    });
    
    // tamanho minino e máximo
    endpoints.Map("/employee/profile/{employeename:minlength(4):maxlength(7)}", async (context) =>
    {
        string? employee = context.Request?.RouteValues["employeename"]?.ToString();
        await context.Response.WriteAsync($"Employee name is {employee}");
    });
    
    // tamanho minino e máximo
    endpoints.Map("/employee/profile/{employeename:length(4, 10)}", async (context) =>
    {
        string? employee = context.Request?.RouteValues["employeename"]?.ToString();
        await context.Response.WriteAsync($"Employee name is {employee}");
    });
    
    // valor mínimo
    endpoints.Map("/employee/profile/{employeename:min(1)}", async (context) =>
    {
        int? id = Convert.ToInt32(context.Request?.RouteValues["employeename"]);
        await context.Response.WriteAsync($"Employee id is {id}");
    });
    
    // valor máximo
    endpoints.Map("/employee/profile/{employeename:max(999999)}", async (context) =>
    {
        int? id = Convert.ToInt32(context.Request?.RouteValues["employeename"]);
        await context.Response.WriteAsync($"Employee id is {id}");
    });
    
    // Aceita somente caracteres alfabéticos
    endpoints.Map("/employee/profile/{employeename:alpha}", async (context) =>
    {
        string? employee = context.Request?.RouteValues["employeename"]?.ToString();
        await context.Response.WriteAsync($"Employee name is {employee}");
    });
    
    // regex match (só aceita palavras john, maria e ronaldo)
    endpoints.Map("/employee/profile/{employeename:regex(^(john|maria|ronaldo)$)}", async (context) =>
    {
        string? employee = context.Request?.RouteValues["employeename"]?.ToString();
        await context.Response.WriteAsync($"Employee name is {employee}");
    });
    
    // classe customizada constraint usando regex
    endpoints.Map("/employee/profile/{employeename:name}", async (context) =>
    {
        string? employee = context.Request?.RouteValues["employeename"]?.ToString();
        await context.Response.WriteAsync($"Employee name is {employee}");
    });
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync($"Request received at: {context.Request.Path}");
});

app.Run();