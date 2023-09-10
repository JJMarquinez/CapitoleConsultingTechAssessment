using AxaTechAssessment.Providers.Application.Common.Results.Builders;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AxaTechAssessment.Providers.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        => services
        .AddTransient<IResultDtoBuilder, ResultDtoBuilder>()
        .AddTransient(typeof(IResultDtoBuilder<>), typeof(ResultDtoBuilder<>))
        .AddAutoMapper(Assembly.GetExecutingAssembly());

}
