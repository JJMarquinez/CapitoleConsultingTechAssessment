using AxaTechAssessment.Providers.Api.Exceptions.Factories;
using AxaTechAssessment.Providers.Api.Exceptions.Handlers;
using AxaTechAssessment.Providers.Api.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AxaTechAssessment.Providers.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddScoped<IExceptionHandlerFactory, ExceptionHandlerFactory>()
            .AddExceptionHandlers()
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                                new HeaderApiVersionReader("x-api-version"),
                                                                new MediaTypeApiVersionReader("x-api-version"));
            })
            .AddProblemDetails()
            .Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true)
            .AddMvcCore(options =>
            {
                options.Filters.Add<ApiExceptionFilterAttribute>();
                options.Filters.Add<ApiResultFilterAttribute>();
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            })
            .AddApiExplorer()
            .AddApplicationPart(typeof(DependencyInjection).Assembly);

        return services;
    }

    private static IServiceCollection AddExceptionHandlers(this IServiceCollection services)
    {
        var types = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(type => !type.IsAbstract && !type.IsGenericTypeDefinition && typeof(IExceptionHandler).IsAssignableFrom(type));

        types.ToList().ForEach(type => services.AddScoped(typeof(IExceptionHandler), type));
        return services;
    }
}
