using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AxaTechAssessment.Providers.Host;

public static class DependencyInjection
{
    public static IServiceCollection AddHostServices(this IServiceCollection services)
        => services
        .AddCustomSwaggerGen();

    private static IServiceCollection AddCustomSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(c => {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Axa Technical Assessment",
                    Description = "An ASP.NET Core Web API to import and get providers' information",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "IT Team",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "IT License",
                        Url = new Uri("https://example.com/license")
                    }
                });
            });

        return services;
    }
}
