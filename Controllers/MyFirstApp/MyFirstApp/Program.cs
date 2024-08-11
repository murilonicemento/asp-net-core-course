using MyFirstApp.Controllers;

var builder = WebApplication.CreateBuilder(args);
// adiciona um controller específico manualmente
// builder.Services.AddTransient<HomeController>();

// adiciona todas as classes controllers como service 
builder.Services.AddControllers();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();