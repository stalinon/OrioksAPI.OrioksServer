using Microsoft.EntityFrameworkCore;
using OrioksServer.Abstractions.Ports;
using OrioksServer.Persistance.Adapters.Database;
using OrioksServer.Persistance.Adapters.Quartz;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connection));
builder.Services.AddScoped<IUnitOfWork>();
builder.Services.AddTransient<JobFactory>();
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

app.Run();
