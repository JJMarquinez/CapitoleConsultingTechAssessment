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
        RunCriticalBusinessRules(providerId, name, postalAddress, createdAt, type);
        ProviderId = providerId;
        Name = name;
        PostalAddress = postalAddress;
        CreatedAt = createdAt;
        Type = type;
    }

    private void RunCriticalBusinessRules(int providerId, string name, string postalAddress, DateTime createdAt, string type)
    {
        Ensure.Argument.Is(providerId > 0, string.Format("{0} must be greater than zaro.", nameof(providerId)));
        Ensure.Argument.NotNullOrEmpty(name, string.Format("{0} cannot be null or empty.", nameof(name)));
        Ensure.Argument.IsNot(name.Length > 30, string.Format("{0} must not have a length greater than 30.", nameof(name)));
        Ensure.Argument.NotNullOrEmpty(postalAddress, string.Format("{0} cannot be null or empty.", nameof(postalAddress)));
        Ensure.Argument.IsNot(postalAddress.Length > 200, string.Format("{0} must not have a length greater than 200.", nameof(postalAddress)));
        Ensure.Argument.NotNullOrEmpty(type, string.Format("{0} cannot be null or empty.", nameof(type)));
        Ensure.Argument.IsNot(type.Length > 15, string.Format("{0} must not have a length greater than 15.", nameof(type)));
        Ensure.Argument.Is(DateTime.Today.CompareTo(createdAt) >= 0, string.Format("{0} must be equal or later then today.", nameof(createdAt)));
    }

    public static Provider NewInstance(int providerId, string name, string postalAddress, DateTime createdAt, string type) 
        => new(providerId, name, postalAddress, createdAt, type);
}
