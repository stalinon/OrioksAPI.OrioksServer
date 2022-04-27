using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using OrioksServer.Abstractions.Ports;
using OrioksServer.Persistance.Adapters.Database;
using OrioksServer.Persistance.Adapters.Quartz;
using Quartz.Spi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



Env.Load("../../local.env");
var connectionString = Env.GetString("CONNECTION_STRING");

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IJobFactory,JobFactory>();
builder.Services.AddScoped<DataJob>();

var app = builder.Build();

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

app.Run(Env.GetString("ASPNETCORE_URLS"));
