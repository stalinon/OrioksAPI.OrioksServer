using Microsoft.EntityFrameworkCore;
using OrioksServer.Abstractions.Ports;
using OrioksServer.Persistance.Adapters.Database;

namespace OrioksServer.Configuration;

/// <summary>
///     Конфигурация доступа к данным
/// </summary>
internal static class DataAccessConfiguration
{
    /// <inheritdoc cref="DataAccessConfiguration"/>
    public static void ConfigureDataAccess(this IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable(ConfigKeys.CONNECTION_STRING);
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new Exception($"Missing ${ConfigKeys.CONNECTION_STRING}");
        }

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
