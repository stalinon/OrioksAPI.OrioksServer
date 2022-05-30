using OrioksServer.Abstractions.Ports.Quartz;
using OrioksServer.Persistance.Adapters.Quartz;
using Quartz.Spi;

namespace OrioksServer.Configuration;

/// <summary>
///     Конфигурация <c>Quartz</c>
/// </summary>
internal static class QuartzConfiguration
{
    /// <inheritdoc cref="QuartzConfiguration"/>
    public static void ConfigureQuartz(this IServiceCollection services)
    {
        services.AddTransient<IJobFactory, JobFactory>();
        services.AddScoped<DataJob>();
        services.AddScoped<IDataGetter, DataGetter>();
    }
}
