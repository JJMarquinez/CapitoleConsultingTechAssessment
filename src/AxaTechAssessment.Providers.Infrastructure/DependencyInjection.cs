using AxaTechAssessment.Providers.Infrastructure.Persistence;
using AxaTechAssessment.Providers.Infrastructure.Repositories;
using AxaTechAssessment.Providers.Infrastructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AxaTechAssessment.Providers.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) 
        => services
        .AddDbContextPool<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
        .AddScoped<ApplicationDbContextInitialiser>()
        .AddScoped(typeof(IRepository<>), typeof(Repository<>))
        .AddScoped<IUnitOfWork, UnitOfWork>();
}
