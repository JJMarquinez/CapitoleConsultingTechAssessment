using AxaTechAssessment.Providers.Domain.Entities;
using AxaTechAssessment.Providers.Domain.Entities.Builders;
using AxaTechAssessment.Providers.Domain.Properties;

namespace AxaTechAssessment.Providers.Domain.UnitTests.Entities;

public class ProviderTests
{
    private readonly IProviderBuilder _providerBuilder;

    public ProviderTests()
    {
        _providerBuilder = new ProviderBuilder();
    }

    [Fact]
    public void ShouldInstanceNewProvider()
    {
        Provider? provider = null!;

        var exception = Record.Exception(() => 
            { 
                provider = _providerBuilder
                .WithProviderId(1)
                .WithName("Alex")
                .WithPostalAddress("2 rue des invalides, Paris")
                .WithCreatedDate(DateTime.Now)
                .WithType("domestic")
                .Build(); 
            });

        Assert.Null(exception);
        Assert.NotNull(provider);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    [InlineData(-10)]
    [InlineData(-20)]
    [InlineData(-40)]
    public void ShouldThrowArgumentExceptionGivenInvalidProviderId(int providerId)
    {
        Provider? provider = null!;

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            provider = _providerBuilder
            .WithProviderId(providerId)
            .WithName("Alex")
            .WithPostalAddress("2 rue des invalides, Paris")
            .WithCreatedDate(DateTime.Now)
            .WithType("domestic")
            .Build();
        });

        Assert.Null(provider);
        Assert.Equal(BusinessString.InvalidProviderId, exception.Message);
    }

    [Fact]
    public void ShouldThrowArgumentExceptionGivenInvalidProviderNameWithLengthGraterThanThirty()
    {
        Provider? provider = null!;

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            provider = _providerBuilder
            .WithProviderId(1)
            .WithName("Andres Javier Jorge Joe James Megan")
            .WithPostalAddress("2 rue des invalides, Paris")
            .WithCreatedDate(DateTime.Now)
            .WithType("domestic")
            .Build();
        });

        Assert.Null(provider);
        Assert.Equal(BusinessString.InvalidProviderNameLength, exception.Message);
    }

    [Fact]
    public void ShouldThrowArgumentExceptionGivenInvalidEmptyProviderName()
    {
        Provider? provider = null!;

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            provider = _providerBuilder
            .WithProviderId(1)
            .WithName(string.Empty)
            .WithPostalAddress("2 rue des invalides, Paris")
            .WithCreatedDate(DateTime.Now)
            .WithType("domestic")
            .Build();
        });

        Assert.Null(provider);
        Assert.Equal(BusinessString.InvalidProviderName, exception.Message);
    }

    [Fact]
    public void ShouldThrowArgumentExceptionGivenInvalidNullProviderName()
    {
        Provider? provider = null!;

        var exception = Assert.Throws<ArgumentNullException>(() =>
        {
            provider = _providerBuilder
            .WithProviderId(1)
            .WithName(null!)
            .WithPostalAddress("2 rue des invalides, Paris")
            .WithCreatedDate(DateTime.Now)
            .WithType("domestic")
            .Build();
        });

        Assert.Null(provider);
        Assert.Equal(String.Format("Value cannot be null. (Parameter '{0}')", BusinessString.InvalidProviderName), exception.Message);
    }

    [Fact]
    public void ShouldThrowArgumentExceptionGivenInvalidProviderPostalAddressWithLengthGraterThanTwoHundred()
    {
        Provider? provider = null!;

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            provider = _providerBuilder
            .WithProviderId(1)
            .WithName("Alex")
            .WithPostalAddress("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.")
            .WithCreatedDate(DateTime.Now)
            .WithType("domestic")
            .Build();
        });

        Assert.Null(provider);
        Assert.Equal(BusinessString.InvalidProviderPostalAddressLength, exception.Message);
    }

    [Fact]
    public void ShouldThrowArgumentExceptionGivenInvalidEmptyProviderPostalAddress()
    {
        Provider? provider = null!;

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            provider = _providerBuilder
            .WithProviderId(1)
            .WithName("Alex")
            .WithPostalAddress(string.Empty)
            .WithCreatedDate(DateTime.Now)
            .WithType("domestic")
            .Build();
        });

        Assert.Null(provider);
        Assert.Equal(BusinessString.InvalidProviderPostalAddress, exception.Message);
    }

    [Fact]
    public void ShouldThrowArgumentExceptionGivenInvalidNullProviderPostalAddress()
    {
        Provider? provider = null!;

        var exception = Assert.Throws<ArgumentNullException>(() =>
        {
            provider = _providerBuilder
            .WithProviderId(1)
            .WithName("Alex")
            .WithPostalAddress(null!)
            .WithCreatedDate(DateTime.Now)
            .WithType("domestic")
            .Build();
        });

        Assert.Null(provider);
        Assert.Equal(String.Format("Value cannot be null. (Parameter '{0}')", BusinessString.InvalidProviderPostalAddress), exception.Message);
    }

    [Fact]
    public void ShouldThrowArgumentExceptionGivenInvalidProviderTypeWithLengthGraterThanFifteen()
    {
        Provider? provider = null!;

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            provider = _providerBuilder
            .WithProviderId(1)
            .WithName("Alex")
            .WithPostalAddress("2 rue des invalides, Paris")
            .WithCreatedDate(DateTime.Now)
            .WithType("domestic domestic")
            .Build();
        });

        Assert.Null(provider);
        Assert.Equal(BusinessString.InvalidProviderTypeLength, exception.Message);
    }

    [Fact]
    public void ShouldThrowArgumentExceptionGivenInvalidEmptyProviderType()
    {
        Provider? provider = null!;

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            provider = _providerBuilder
            .WithProviderId(1)
            .WithName("Alex")
            .WithPostalAddress("2 rue des invalides, Paris")
            .WithCreatedDate(DateTime.Now)
            .WithType(string.Empty)
            .Build();
        });

        Assert.Null(provider);
        Assert.Equal(BusinessString.InvalidProviderType, exception.Message);
    }

    [Fact]
    public void ShouldThrowArgumentExceptionGivenInvalidNullProviderType()
    {
        Provider? provider = null!;

        var exception = Assert.Throws<ArgumentNullException>(() =>
        {
            provider = _providerBuilder
            .WithProviderId(1)
            .WithName("Alex")
            .WithPostalAddress("2 rue des invalides, Paris")
            .WithCreatedDate(DateTime.Now)
            .WithType(null!)
            .Build();
        });

        Assert.Null(provider);
        Assert.Equal(String.Format("Value cannot be null. (Parameter '{0}')", BusinessString.InvalidProviderType), exception.Message);
    }

    [Fact]
    public void ShouldThrowArgumentExceptionGivenInvalidEmptyProviderCreationDate()
    {
        Provider? provider = null!;

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            provider = _providerBuilder
            .WithProviderId(1)
            .WithName("Alex")
            .WithPostalAddress("2 rue des invalides, Paris")
            .WithCreatedDate(DateTime.Today.AddDays(-1))
            .WithType("domestic")
            .Build();
        });

        Assert.Null(provider);
        Assert.Equal(BusinessString.InvalidProviderCreationDate, exception.Message);
    }
}
