using OrioksServer.Domain.IServices;
using OrioksServer.Domain.Services;

namespace OrioksServer.Configuration;

/// <summary>
///     Конфигурация сервисов
/// </summary>
internal static class ServicesConfiguration
{
    /// <inheritdoc cref="ServicesConfiguration"/>
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddSingleton<IDomainServiceFactory, DomainServiceFactory>();
    }
}
