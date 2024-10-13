using Autofac;
using Autofac.Extensions.DependencyInjection;
using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory
(
    new AutofacServiceProviderFactory()
);

builder.Services.AddControllersWithViews();
// builder.Services.Add
// (
//     new ServiceDescriptor
//     (
//         typeof(ICitiesService),
//         typeof(CitiesService),
//         ServiceLifetime.Scoped
//     )
// );

builder.Host.ConfigureContainer<ContainerBuilder>
(
    containerBuilder =>
    {
        // AddTransient
        // containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerDependency();
        
        // AddScoped
        containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerLifetimeScope();
       
        // AddSingleton
        // containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().SingleInstance();
        
        // AddScoped
        // containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerLifetimeScope();
    } 
);

// builder.Services.AddTransient<ICitiesService, CitiesService>();
// builder.Services.AddScoped<ICitiesService, CitiesService>();
// builder.Services.AddSingleton<ICitiesService, CitiesService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();