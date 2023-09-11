namespace AxaTechAssessment.Providers.Adapter.Persistence.Models.Builders;

public interface IProviderDbBuilder
{
    IProviderDbBuilder WithProviderId(int providerId);
    IProviderDbBuilder WithName(string name);
    IProviderDbBuilder WithPostalAddres(string postalAddres);
    IProviderDbBuilder WithCreatedDate(DateTime CreatedAt);
    IProviderDbBuilder WithType(string type);
    ProviderDb Build();
}
