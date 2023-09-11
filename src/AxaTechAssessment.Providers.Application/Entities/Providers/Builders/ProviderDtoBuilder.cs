namespace AxaTechAssessment.Providers.Application.Entities.Providers.Builders;

public class ProviderDtoBuilder : IProviderDtoBuilder
{
    private int _providerId;
    private string _name;
    private string _postalAddress;
    private DateTime _createdAt;
    private string _type;
    public ProviderDto Build()
        => new ProviderDto 
        {
            provider_id = _providerId,
            name = _name,
            postal_address = _postalAddress,
            created_at = _createdAt,
            type = _type
        }; 

    public IProviderDtoBuilder WithCreatedDate(DateTime CreatedAt)
    {
        _createdAt = CreatedAt;
        return this;
    }

    public IProviderDtoBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IProviderDtoBuilder WithPostalAddress(string postalAddres)
    {
        _postalAddress = postalAddres;
        return this;
    }

    public IProviderDtoBuilder WithProviderId(int providerId)
    {
        _providerId = providerId;
        return this;
    }

    public IProviderDtoBuilder WithType(string type)
    {
        _type = type;
        return this;
    }
}
