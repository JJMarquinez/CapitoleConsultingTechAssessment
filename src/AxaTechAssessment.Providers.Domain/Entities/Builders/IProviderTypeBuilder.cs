namespace AxaTechAssessment.Providers.Domain.Entities.Builders;

public interface IProviderTypeBuilder
{
    IProviderBuildBuilder WithType(string type);
}