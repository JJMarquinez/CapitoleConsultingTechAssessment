using AxaTechAssessment.Providers.Adapter.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AxaTechAssessment.Providers.Infrastructure.Persistence.Configurations;

public class ProviderDbConfiguration : IEntityTypeConfiguration<ProviderDb>
{
    public void Configure(EntityTypeBuilder<ProviderDb> builder)
    {
        builder.ToTable("Provider");

        builder.Property(p => p.Name)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(p => p.PostalAddress)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.CreatedAt)
            .IsRequired();

        builder.Property(p => p.Type)
            .IsRequired();
    }
}
