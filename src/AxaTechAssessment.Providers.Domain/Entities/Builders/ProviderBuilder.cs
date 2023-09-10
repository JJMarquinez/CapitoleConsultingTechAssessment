namespace AxaTechAssessment.Providers.Domain.Entities.Builders;

public class ProviderBuilder
    : IProviderBuilder,
    IProviderNameBuilder,
    IProviderPostalAddressBuilder,
    IProviderCreatedDateBuilder,
    IProviderTypeBuilder,
    IProviderBuildBuilder
{
    private int _providerId;
    private string _name = null!;
    private string _postalAddress = null!;
    private DateTime _createdAd;
    private string _type = null!;

    public Provider Build() => Provider.NewInstance(_providerId, _name, _postalAddress, _createdAd, _type);

    public IProviderTypeBuilder WithCreatedDate(DateTime CreatedAt)
    {
        _createdAd = CreatedAt;
        return this;
    }

    public IProviderPostalAddressBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IProviderCreatedDateBuilder WithPostalAddress(string postalAddress)
    {
        _postalAddress = postalAddress;
        return this;
    }

    public IProviderNameBuilder WithProviderId(int providerId)
    {
        _providerId = providerId;
        return this;
    }

    public IProviderBuildBuilder WithType(string type)
    {
        _type = type;
        return this;
    }
}
