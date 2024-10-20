using Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// inject configuration as service
builder.Services.Configure<WeatherApiOptions>(builder.Configuration.GetSection("WeatherApi"));

// load MyOwnConfig.json
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("MyOwnConfig.json", optional: true, reloadOnChange: true);
});
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
// app.UseEndpoints(endpoints =>
// {
// endpoints.Map("/", async context =>
// {
//     await context.Response.WriteAsync(app.Configuration["MyKey"] + "\n");
//
//     // getvalue
//     await context.Response.WriteAsync(app.Configuration.GetValue<string>("MyKey") + "\n");
//
//     // default value
//     await context.Response.WriteAsync(app.Configuration.GetValue<int>("x", 1) + "\n");
// });
// endpoints.Map("/config", async context =>
// {
//     await context.Response.WriteAsync(app.Configuration["MyKey"] + "\n");
//
//     // getvalue
//     await context.Response.WriteAsync(app.Configuration.GetValue<string>("MyKey") + "\n");
//
//     // default value
//     await context.Response.WriteAsync(app.Configuration.GetValue<int>("x", 1) + "\n");
// });
// });
app.MapControllers();
app.Run();