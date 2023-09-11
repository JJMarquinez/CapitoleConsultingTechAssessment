using System.Data.Common;

namespace AxaTechAssessment.Providers.Api.FunctionalTests.TestContext.Databases;

public interface ITestDatabase
{
    Task InitialiseAsync();

    DbConnection GetDbConnection();

    ValueTask ResetAsync();

    ValueTask DisposeAsync();
}
