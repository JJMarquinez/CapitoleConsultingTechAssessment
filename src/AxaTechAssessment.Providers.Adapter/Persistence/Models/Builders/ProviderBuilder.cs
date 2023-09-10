namespace AxaTechAssessment.Providers.Adapter.Persistence.Models.Builders;

public class ProviderBuilder : IProviderBuilder
{
    private int _providerId;
    private string _name;
    private string _postalAddress;
    private DateTime _createdAt;
    private string _type;
    public Provider Build()
        => new Provider
        {
            ProviderId = _providerId,
            Name = _name,
            PostalAddress = _postalAddress,
            CreatedAt = _createdAt,
            Type = _type
        };

    public IProviderBuilder WithCreationDate(DateTime CreatedAt)
    {
        _createdAt = CreatedAt;
        return this;
    }

    public IProviderBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IProviderBuilder WithPostalAddres(string postalAddres)
    {
        _postalAddress = postalAddres;
        return this;
    }

    public IProviderBuilder WithProviderId(int providerId)
    {
        _providerId = providerId;
        return this;
    }

    public IProviderBuilder WithType(string type)
    {
        _type = type;
        return this;
    }
}
