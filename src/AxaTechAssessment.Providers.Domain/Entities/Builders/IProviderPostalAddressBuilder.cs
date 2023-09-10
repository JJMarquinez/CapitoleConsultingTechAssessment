namespace AxaTechAssessment.Providers.Domain.Entities.Builders;

public interface IProviderPostalAddressBuilder
{
    IProviderCreatedDateBuilder WithPostalAddress(string postalAddress);
}