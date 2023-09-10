using AxaTechAssessment.Providers.Domain.Common.Errors.Builders;
using AxaTechAssessment.Providers.Domain.Common.Results.Builders;
using AxaTechAssessment.Providers.Domain.Entities.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace AxaTechAssessment.Providers.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddADomainServices(this IServiceCollection services)
    {
        services.AddTransient<IErrorBuilder, ErrorBuilder>();
        services.AddTransient<IResultBuilder, ResultBuilder>();
        services.AddTransient(typeof(IResultBuilder<>), typeof(ResultBuilder<>));
        services.AddTransient<IProviderBuilder, ProviderBuilder>();
        return services;
    }
}
