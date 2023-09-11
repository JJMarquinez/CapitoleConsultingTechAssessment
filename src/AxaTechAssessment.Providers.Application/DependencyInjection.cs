using AxaTechAssessment.Providers.Application.Common.Errors.Builders;
using AxaTechAssessment.Providers.Application.Common.Results.Builders;
using AxaTechAssessment.Providers.Application.Entities.Providers.Builders;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AxaTechAssessment.Providers.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        => services
        .AddTransient<IProviderDtoBuilder, ProviderDtoBuilder>()
        .AddTransient<IErrorDtoBuilder, ErrorDtoBuilder>()
        .AddTransient<IResultDtoBuilder, ResultDtoBuilder>()
        .AddTransient(typeof(IResultDtoBuilder<>), typeof(ResultDtoBuilder<>))
        .AddAutoMapper(Assembly.GetExecutingAssembly())
        .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
        .AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

}
