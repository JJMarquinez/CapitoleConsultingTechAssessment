using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AxaTechAssessment.Providers.Host;

public static class DependencyInjection
{
    public static IServiceCollection AddHostServices(this IServiceCollection services)
        => services
        //.AddEndpointsApiExplorer()
        .AddSwaggerGen()
        .AddCustomOpenApiDocument();

    private static IServiceCollection AddCustomOpenApiDocument(this IServiceCollection services)
    {
        services.AddSwaggerGen(c => {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "BMJ Query Authenticator API",
                    Description = "An ASP.NET Core Web API to query identity users' detials and get tokens",
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
