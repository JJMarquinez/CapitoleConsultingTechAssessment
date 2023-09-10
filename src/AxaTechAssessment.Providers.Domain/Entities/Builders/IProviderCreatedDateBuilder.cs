namespace AxaTechAssessment.Providers.Domain.Entities.Builders;

public interface IProviderCreatedDateBuilder
{
    IProviderTypeBuilder WithCreatedDate(DateTime CreatedAt);
}