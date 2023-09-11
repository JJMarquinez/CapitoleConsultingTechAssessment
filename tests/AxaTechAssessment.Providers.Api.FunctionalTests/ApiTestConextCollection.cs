using AxaTechAssessment.Providers.Api.FunctionalTests.TestContext;

namespace AxaTechAssessment.Providers.Api.FunctionalTests;

[CollectionDefinition(nameof(ApiTestConextCollection))]
public class ApiTestConextCollection : ICollectionFixture<ApiTestConext>
{
}
