using AxaTechAssessment.Providers.Domain.Common;

namespace AxaTechAssessment.Providers.Domain.Entities;

public class Provider
{
    internal int ProviderId { get; }
    internal string Name { get; }
    internal string PostalAddress { get; } // It could be a value object to be in charge of address validations
    internal DateTime CreatedAt { get; }
    internal string Type { get; } // It could be an entity with its own rules

    private Provider() { }

    private Provider(int providerId, string name, string postalAddress, DateTime createdAt, string type)
    {
        Ensure.Argument.Is(providerId > 0, string.Format("{0} must be greater then zaro.", nameof(providerId)));
        Ensure.Argument.NotNullOrEmpty(name, string.Format("{0} cannot be null or empty.", nameof(name)));
        Ensure.Argument.NotNullOrEmpty(postalAddress, string.Format("{0} cannot be null or empty.", nameof(postalAddress)));
        Ensure.Argument.NotNullOrEmpty(type, string.Format("{0} cannot be null or empty.", nameof(type)));
        ProviderId = providerId;
        Name = name;
        PostalAddress = postalAddress;
        CreatedAt = createdAt;
        Type = type;
    }

    public static Provider NewInstance(int providerId, string name, string postalAddress, DateTime createdAt, string type) 
        => new(providerId, name, postalAddress, createdAt, type);
}
