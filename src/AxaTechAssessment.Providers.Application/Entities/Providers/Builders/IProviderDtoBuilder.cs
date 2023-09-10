namespace AxaTechAssessment.Providers.Application.Entities.Providers.Builders;

public interface IProviderDtoBuilder
{
    IProviderDtoBuilder WithProviderId(int providerId);
    IProviderDtoBuilder WithName(string name);
    IProviderDtoBuilder WithPostalAddres(string postalAddres);
    IProviderDtoBuilder WithCreationDate(DateTime CreatedAt);
    IProviderDtoBuilder WithType(string type);
    ProviderDto Build();
}
