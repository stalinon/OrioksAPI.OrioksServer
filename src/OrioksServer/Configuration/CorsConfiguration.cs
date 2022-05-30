namespace OrioksServer.Configuration;

/// <summary>
///     Конфигурация CORS
/// </summary>
internal static class CorsConfiguration
{
    /// <inheritdoc cref="CorsConfiguration"/>
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(_ => _.AddDefaultPolicy(p => p.AllowAnyHeader().WithMethods("GET").AllowAnyOrigin()));
    }
}
