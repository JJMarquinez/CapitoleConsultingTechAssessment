namespace AxaTechAssessment.Providers.Application.Entities.Providers.Builders;

public interface IProviderDtoBuilder
{
    IProviderDtoBuilder WithProviderId(int providerId);
    IProviderDtoBuilder WithName(string name);
    IProviderDtoBuilder WithPostalAddress(string postalAddres);
    IProviderDtoBuilder WithCreatedDate(DateTime CreatedAt);
    IProviderDtoBuilder WithType(string type);
    ProviderDto Build();
}
