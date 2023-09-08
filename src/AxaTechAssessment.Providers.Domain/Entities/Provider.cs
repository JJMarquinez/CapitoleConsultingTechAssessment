using AxaTechAssessment.Providers.Domain.Common;

namespace AxaTechAssessment.Providers.Domain.Entities;

public class Provider
{
    private int _providerId;
    private string _name;
    private string _postalAddress;
    private DateTime _createdAt;
    private string _type;

    public Provider(int providerId, string name, string postalAddress, DateTime createdAt, string type)
    {
        Ensure.Argument.Is(providerId > 0, string.Format("{0} must be greater then zaro.", nameof(providerId)));
        Ensure.Argument.NotNullOrEmpty(name, string.Format("{0} cannot be null or empty.", nameof(name)));
        Ensure.Argument.NotNullOrEmpty(postalAddress, string.Format("{0} cannot be null or empty.", nameof(postalAddress)));
        Ensure.Argument.NotNullOrEmpty(type, string.Format("{0} cannot be null or empty.", nameof(type)));
        _providerId = providerId;
        _name = name;
        _postalAddress = postalAddress;
        _createdAt = createdAt;
        _type = type;
    }
}
