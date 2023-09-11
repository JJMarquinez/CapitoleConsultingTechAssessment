using AxaTechAssessment.Providers.Domain.Common;
using AxaTechAssessment.Providers.Domain.Properties;

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
        RunCriticalBusinessRules(providerId, name, postalAddress, createdAt, type);
        ProviderId = providerId;
        Name = name;
        PostalAddress = postalAddress;
        CreatedAt = createdAt;
        Type = type;
    }

    private void RunCriticalBusinessRules(int providerId, string name, string postalAddress, DateTime createdAt, string type)
    {
        Ensure.Argument.Is(providerId > 0, BusinessString.InvalidProviderId);
        Ensure.Argument.NotNullOrEmpty(name, BusinessString.InvalidProviderName);
        Ensure.Argument.IsNot(name.Length > 30, BusinessString.InvalidProviderNameLength);
        Ensure.Argument.NotNullOrEmpty(postalAddress, BusinessString.InvalidProviderPostalAddress);
        Ensure.Argument.IsNot(postalAddress.Length > 200, BusinessString.InvalidProviderPostalAddressLength);
        Ensure.Argument.NotNullOrEmpty(type, BusinessString.InvalidProviderType);
        Ensure.Argument.IsNot(type.Length > 15, BusinessString.InvalidProviderTypeLength);
        Ensure.Argument.Is(createdAt.CompareTo(DateTime.Today) >= 0, BusinessString.InvalidProviderCreationDate);
    }

    internal static Provider NewInstance(int providerId, string name, string postalAddress, DateTime createdAt, string type) 
        => new(providerId, name, postalAddress, createdAt, type);
}
