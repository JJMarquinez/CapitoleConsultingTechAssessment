namespace AxaTechAssessment.Providers.Domain.Entities.Builders;

public interface IProviderNameBuilder
{
    IProviderPostalAddressBuilder WithName(string name);
}