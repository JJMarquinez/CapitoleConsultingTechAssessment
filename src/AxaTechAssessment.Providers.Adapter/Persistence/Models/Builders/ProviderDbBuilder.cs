namespace AxaTechAssessment.Providers.Adapter.Persistence.Models.Builders;

public class ProviderDbBuilder : IProviderDbBuilder
{
    private int _providerId;
    private string _name;
    private string _postalAddress;
    private DateTime _createdAt;
    private string _type;
    public ProviderDb Build()
        => new ProviderDb
        {
            ProviderId = _providerId,
            Name = _name,
            PostalAddress = _postalAddress,
            CreatedAt = _createdAt,
            Type = _type
        };

    public IProviderDbBuilder WithCreationDate(DateTime CreatedAt)
    {
        _createdAt = CreatedAt;
        return this;
    }

    public IProviderDbBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IProviderDbBuilder WithPostalAddres(string postalAddres)
    {
        _postalAddress = postalAddres;
        return this;
    }

    public IProviderDbBuilder WithProviderId(int providerId)
    {
        _providerId = providerId;
        return this;
    }

    public IProviderDbBuilder WithType(string type)
    {
        _type = type;
        return this;
    }
}
