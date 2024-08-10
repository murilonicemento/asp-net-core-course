using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    WebRootPath = "myroot"
});

var app = builder.Build();

app.UseStaticFiles(); // trabalha com a pasta myroot
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "mywebroot"))
}); // trabalha com a mywebroot
app.UseRouting();

#pragma warning disable ASP0014
app.UseEndpoints((endpoints) =>
{
    endpoints.Map("/", async (context) =>
    {
        await context.Response.WriteAsync("Hello");
    });
});
app.Run();