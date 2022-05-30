using OrioksServer;
using OrioksServer.Configuration;
using OrioksServer.Helpers;
using OrioksServer.Persistance.Adapters.Quartz;

static WebApplication ConfigureWebApplication(WebApplicationBuilder builder)
{
    DotEnv.Load();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.ConfigureSwagger();
    builder.Services.ConfigureDataAccess();
    builder.Services.ConfigureQuartz();
    builder.Services.ConfigureServices();
    builder.Services.ConfigureCors();

    return builder.Build();
}

static void StartApplication(WebApplication app)
{
    try
    {
        DataScheduler.Start(app.Services);
    }
    catch
    {
        throw;
    }

    app.UseSwaggerConfig();
    app.UseCors();
    app.MapControllers();

    app.Run(Environment.GetEnvironmentVariable(ConfigKeys.ASPNETCORE_URLS));
}

var app = ConfigureWebApplication(WebApplication.CreateBuilder(args));

StartApplication(app);
