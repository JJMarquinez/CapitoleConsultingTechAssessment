namespace AxaTechAssessment.Providers.Adapter.Persistence.Models.Builders;

public interface IProviderBuilder
{
    IProviderBuilder WithProviderId(int providerId);
    IProviderBuilder WithName(string name);
    IProviderBuilder WithPostalAddres(string postalAddres);
    IProviderBuilder WithCreationDate(DateTime CreatedAt);
    IProviderBuilder WithType(string type);
    Provider Build();
}
