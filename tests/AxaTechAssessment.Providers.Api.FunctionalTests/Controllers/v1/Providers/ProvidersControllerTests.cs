using AxaTechAssessment.Providers.Adapter.Persistence.Models;
using AxaTechAssessment.Providers.Adapter.Persistence.Models.Builders;
using AxaTechAssessment.Providers.Api.FunctionalTests.TestContext;
using AxaTechAssessment.Providers.Application.Entities.Providers;
using AxaTechAssessment.Providers.Application.Entities.Providers.Builders;
using System.Net;
using System.Text.Json;

namespace AxaTechAssessment.Providers.Api.FunctionalTests.Controllers.v1.Providers;

[Collection(nameof(ApiTestConextCollection))]
public class ProvidersControllerTests : IAsyncLifetime
{
    private readonly ApiTestConext _testContext;
    private readonly Func<Task> _resetDatabase;
    private readonly IProviderDbBuilder _providerDbBuilder;
    private readonly IProviderDtoBuilder _providerDtoBuilder;

    public ProvidersControllerTests(ApiTestConext testContext)
    {
        _testContext = testContext;
        _resetDatabase = _testContext.ResetState;
        _providerDbBuilder = new ProviderDbBuilder();
        _providerDtoBuilder = new ProviderDtoBuilder();
    }

    public Task DisposeAsync() => _resetDatabase();

    public Task InitializeAsync() => Task.CompletedTask;

    [Fact]
    public async Task ShouldGetProviderById()
    {
        var provider = await _testContext.AddAsync(
            _providerDbBuilder
            .WithName("Alex")
            .WithPostalAddres("2 rue des invalides, Paris")
            .WithCreatedDate(DateTime.Today)
            .WithType("domestic")
            .Build());
        var providerId = provider.ProviderId;

        var response = await _testContext.GetAsync(string.Format("{0}{1}",ApiUrl.GetProvierByIdAsync(), providerId));
        var result = await response.Content.ReadAsStringAsync();
        var providerDto = JsonSerializer.Deserialize<ProviderDto>(result);

        Assert.NotNull(response);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(providerDto);
    }

    [Fact]
    public async Task ShouldGetNotFoundGivenNonExistingProviderId()
    {
        var providerId = 1593;

        var response = await _testContext.GetAsync(string.Format("{0}{1}", ApiUrl.GetProvierByIdAsync(), providerId));

        Assert.NotNull(response);
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task ShouldGetBadRequestGivenInvalidProvierId()
    {
        var providerId = 0;

        var response = await _testContext.GetAsync(string.Format("{0}{1}", ApiUrl.GetProvierByIdAsync(), providerId));

        Assert.NotNull(response);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task ShouldImportProviders()
    {
        var alexProviderDto = _providerDtoBuilder
            .WithProviderId(1)
            .WithName("Alex")
            .WithPostalAddress("2 rue des invalides, Paris")
            .WithCreatedDate(DateTime.Now)
            .WithType("domestic")
            .Build();
        var jameProviderDto = _providerDtoBuilder
            .WithProviderId(2)
            .WithName("Jame")
            .WithPostalAddress("1 rue de la paix, Paris")
            .WithCreatedDate(DateTime.Now)
            .WithType("roadside")
            .Build();
        var providers = new List<ProviderDto>() { alexProviderDto, jameProviderDto };

        var response = await _testContext.PostAsync(ApiUrl.ImportProviderAsync(), providers);
        var result = await response.Content.ReadAsStringAsync();
        var providerDtoList = JsonSerializer.Deserialize<List<ProviderDto>>(result);

        var alexProviderDb = await _testContext.FindAsync<ProviderDb>(alexProviderDto.provider_id);
        var jameProviderDb = await _testContext.FindAsync<ProviderDb>(jameProviderDto.provider_id);

        Assert.NotNull(response);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(providerDtoList);
        Assert.True(providerDtoList.Count() == 2);
        Assert.NotNull(alexProviderDb);
        Assert.Equal(alexProviderDto.name, alexProviderDb.Name);
        Assert.Equal(alexProviderDto.postal_address, alexProviderDb.PostalAddress);
        Assert.Equal(alexProviderDto.created_at, alexProviderDb.CreatedAt);
        Assert.Equal(alexProviderDto.type, alexProviderDb.Type);
        Assert.NotNull(jameProviderDb);
        Assert.Equal(jameProviderDto.name, jameProviderDb.Name);
        Assert.Equal(jameProviderDto.postal_address, jameProviderDb.PostalAddress);
        Assert.Equal(jameProviderDto.created_at, jameProviderDb.CreatedAt);
        Assert.Equal(jameProviderDto.type, jameProviderDb.Type);
    }

    [Fact]
    public async Task ShouldGetBadRequestGivenProviderWithInvalidProviderIdToImport()
    {
        var providers = new List<ProviderDto>()
        {
            _providerDtoBuilder
            .WithProviderId(0)
            .WithName("Alex")
            .WithPostalAddress("2 rue des invalides, Paris")
            .WithCreatedDate(DateTime.Now)
            .WithType("domestic")
            .Build()
        };
        var response = await _testContext.PostAsync(ApiUrl.ImportProviderAsync(), providers);

        Assert.NotNull(response);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task ShouldGetBadRequestGivenProviderWithInvalidProviderNameToImport()
    {
        var providers = new List<ProviderDto>()
        {
            _providerDtoBuilder
            .WithProviderId(1)
            .WithName(string.Empty)
            .WithPostalAddress("2 rue des invalides, Paris")
            .WithCreatedDate(DateTime.Now)
            .WithType("domestic")
            .Build()
        };
        var response = await _testContext.PostAsync(ApiUrl.ImportProviderAsync(), providers);

        Assert.NotNull(response);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task ShouldGetBadRequestGivenProviderWithInvalidProviderPostalAddressToImport()
    {
        var providers = new List<ProviderDto>()
        {
            _providerDtoBuilder
            .WithProviderId(1)
            .WithName("Alex")
            .WithPostalAddress(string.Empty)
            .WithCreatedDate(DateTime.Now)
            .WithType("domestic")
            .Build()
        };
        var response = await _testContext.PostAsync(ApiUrl.ImportProviderAsync(), providers);

        Assert.NotNull(response);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task ShouldGetBadRequestGivenProviderWithInvalidProviderCreationDateToImport()
    {
        var providers = new List<ProviderDto>()
        {
            _providerDtoBuilder
            .WithProviderId(1)
            .WithName("Alex")
            .WithPostalAddress("2 rue des invalides, Paris")
            .WithCreatedDate(DateTime.Now.AddDays(-1))
            .WithType("domestic")
            .Build()
        };
        var response = await _testContext.PostAsync(ApiUrl.ImportProviderAsync(), providers);

        Assert.NotNull(response);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task ShouldGetBadRequestGivenProviderWithInvalidProviderTypeToImport()
    {
        var providers = new List<ProviderDto>()
        {
            _providerDtoBuilder
            .WithProviderId(1)
            .WithName("Alex")
            .WithPostalAddress("2 rue des invalides, Paris")
            .WithCreatedDate(DateTime.Now)
            .WithType(string.Empty)
            .Build()
        };
        var response = await _testContext.PostAsync(ApiUrl.ImportProviderAsync(), providers);

        Assert.NotNull(response);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task ShouldGetInternalServerErrorGivenProviderNameWithLengthGraterThanThirtyToImport()
    {
        var providers = new List<ProviderDto>()
        {
            _providerDtoBuilder
            .WithProviderId(1)
            .WithName("Andres Javier Jorge Joe James Megan")
            .WithPostalAddress("2 rue des invalides, Paris")
            .WithCreatedDate(DateTime.Now)
            .WithType("domestic")
            .Build()
        };
        var response = await _testContext.PostAsync(ApiUrl.ImportProviderAsync(), providers);

        Assert.NotNull(response);
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }

    [Fact]
    public async Task ShouldGetInternalServerErrorGivenProviderPostalAddressWithLengthGraterThanTwoHundredToImport()
    {
        var providers = new List<ProviderDto>()
        {
            _providerDtoBuilder
            .WithProviderId(1)
            .WithName("Alex")
            .WithPostalAddress("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.")
            .WithCreatedDate(DateTime.Now)
            .WithType("domestic")
            .Build()
        };
        var response = await _testContext.PostAsync(ApiUrl.ImportProviderAsync(), providers);

        Assert.NotNull(response);
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }

    [Fact]
    public async Task ShouldGetInternalServerErrorGivenProviderTypeWithLengthGraterThanFifteenToImport()
    {
        var providers = new List<ProviderDto>()
        {
            _providerDtoBuilder
            .WithProviderId(1)
            .WithName("Alex")
            .WithPostalAddress("2 rue des invalides, Paris")
            .WithCreatedDate(DateTime.Now)
            .WithType("domestic domestic")
            .Build()
        };
        var response = await _testContext.PostAsync(ApiUrl.ImportProviderAsync(), providers);

        Assert.NotNull(response);
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }
}
