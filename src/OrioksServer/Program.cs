using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using OrioksServer;
using OrioksServer.Abstractions.Ports;
using OrioksServer.Abstractions.Ports.Quartz;
using OrioksServer.Domain.IServices;
using OrioksServer.Domain.Services;
using OrioksServer.Persistance.Adapters.Database;
using OrioksServer.Persistance.Adapters.Quartz;
using Quartz.Spi;

static WebApplication ConfigureWebApplication(WebApplicationBuilder builder)
{
    // Add services to the container.
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    
    var connectionString = Env.GetString(ConfigKeys.CONNECTION_STRING);
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new Exception($"Missing ${ConfigKeys.CONNECTION_STRING}");
    }

    var url = Env.GetString(ConfigKeys.ASPNETCORE_URLS);

    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseNpgsql(connectionString);
    });
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

    builder.WebHost.ConfigureKestrel(options => options.ListenLocalhost(int.Parse(url.Split(':').Last())));

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

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    var url = Env.GetString("ASPNETCORE_URLS");
    app.Run(url);
}

Env.Load("../../local.env");

var app = ConfigureWebApplication(WebApplication.CreateBuilder(args));

StartApplication(app);
