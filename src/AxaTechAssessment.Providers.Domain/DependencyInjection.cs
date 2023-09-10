using AxaTechAssessment.Providers.Domain.Common.Errors.Builders;
using AxaTechAssessment.Providers.Domain.Common.Results.Builders;
using AxaTechAssessment.Providers.Domain.Entities.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace AxaTechAssessment.Providers.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddADomainServices(this IServiceCollection services) 
        => services
        .AddTransient<IErrorBuilder, ErrorBuilder>()
        .AddTransient<IResultBuilder, ResultBuilder>()
        .AddTransient(typeof(IResultBuilder<>), typeof(ResultBuilder<>))
        .AddTransient<IProviderBuilder, ProviderBuilder>();    
}
