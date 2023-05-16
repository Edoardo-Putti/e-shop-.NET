
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration(ic => ic.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json"));


builder.Host.ConfigureLogging((hostingctx, loggingbuilder) =>
{
    loggingbuilder.AddConfiguration(hostingctx.Configuration.GetSection("logging"));
    loggingbuilder.AddConsole();
    loggingbuilder.AddDebug();
});



builder.Services.AddOcelot(builder.Configuration).AddCacheManager(settings => settings.WithDictionaryHandle()); ;
var app = builder.Build();

app.UseOcelot().Wait();
app.MapGet("/", () => "Hello World!");


app.Run();
