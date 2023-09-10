using AxaTechAssessment.Providers.Adapter.Persistence.Models.Builders;
using AxaTechAssessment.Providers.Adapter.Providers;
using AxaTechAssessment.Providers.Application.Common.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace AxaTechAssessment.Providers.Adapter;

public static class DependencyInjection
{
    public static IServiceCollection AddAdapterServices(this IServiceCollection services)
        => services
        .AddTransient<IProviderDbBuilder, ProviderDbBuilder>()
        .AddTransient<IProviderAdapter, ProviderAdapter>();
}
