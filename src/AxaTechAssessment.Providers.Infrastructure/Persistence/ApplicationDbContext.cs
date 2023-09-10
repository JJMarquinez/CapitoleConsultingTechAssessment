using AxaTechAssessment.Providers.Adapter.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AxaTechAssessment.Providers.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ProviderDb> Providers => Set<ProviderDb>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
