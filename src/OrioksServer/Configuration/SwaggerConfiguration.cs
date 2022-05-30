using Microsoft.OpenApi.Models;
using System.Reflection;

namespace OrioksServer.Configuration;

/// <summary>
///     Конфигурация <c>Swagger</c>
/// </summary>
internal static class SwaggerConfiguration
{
    /// <inheritdoc cref="SwaggerConfiguration"/>
    public static void UseSwaggerConfig(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });
    }

    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "OrioksAPI.OrioksServer",
                Description = "Открытый API для расписаний и преподавателей МИЭТ.",
                Contact = new OpenApiContact
                {
                    Name = "stalinon",
                    Url = new Uri("https://github.com/stalinon/OrioksAPI.OrioksServer")
                }
            });
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
    }
}
