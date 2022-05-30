using Microsoft.EntityFrameworkCore;
using OrioksServer;
using OrioksServer.Abstractions.Ports;
using OrioksServer.Abstractions.Ports.Quartz;
using OrioksServer.Domain.IServices;
using OrioksServer.Domain.Services;
using OrioksServer.Helpers;
using OrioksServer.Persistance.Adapters.Database;
using OrioksServer.Persistance.Adapters.Quartz;
using Quartz.Spi;

static WebApplication ConfigureWebApplication(WebApplicationBuilder builder)
{
    DotEnv.Load();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var connectionString = Environment.GetEnvironmentVariable(ConfigKeys.CONNECTION_STRING);
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new Exception($"Missing ${ConfigKeys.CONNECTION_STRING}");
    }

    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseNpgsql(connectionString);
    });
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddSingleton<IDomainServiceFactory, DomainServiceFactory>();
    builder.Services.AddTransient<IJobFactory, JobFactory>();
    builder.Services.AddScoped<DataJob>();
    builder.Services.AddScoped<IDataGetter, DataGetter>();

    builder.Services.AddCors(_ => _.AddDefaultPolicy(p => p.AllowAnyHeader().AllowAnyOrigin()));

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

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();

    app.MapControllers();

    var url = Environment.GetEnvironmentVariable(ConfigKeys.ASPNETCORE_URLS);
    app.Run(url);
}

var app = ConfigureWebApplication(WebApplication.CreateBuilder(args));

StartApplication(app);
