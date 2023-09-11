using AxaTechAssessment.Providers.Adapter.Common.Abstractions;
using AxaTechAssessment.Providers.Adapter.Persistence.Models;
using AxaTechAssessment.Providers.Api.FunctionalTests.TestContext.Databases;
using AxaTechAssessment.Providers.Application.Entities.Providers;
using AxaTechAssessment.Providers.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace AxaTechAssessment.Providers.Api.FunctionalTests.TestContext;

public class ApiTestConext : IDisposable
{
    private static ITestDatabase _database = null!;
    private static ApiWebApplicationFactory _factory = null!;
    private static IServiceScopeFactory _scopeFactory = null!;

    public ApiTestConext()
    {
        _database = new MsSqlContainerTestDatabase();
        _database.InitialiseAsync().Wait();

        _factory = new ApiWebApplicationFactory(_database.GetDbConnection());

        _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
    }

    public async ValueTask<HttpResponseMessage> GetAsync(string? requestUri)
        => await _factory.CreateClient().GetAsync(requestUri).ConfigureAwait(false);
    public async ValueTask<HttpResponseMessage> PostAsync(string? requestUri, List<ProviderDto> providers)
        => await _factory.CreateClient().PostAsync(requestUri, new StringContent(JsonSerializer.Serialize(providers), Encoding.UTF8, new MediaTypeHeaderValue("application/json"))).ConfigureAwait(false);


    public async ValueTask<TEntity> AddAsync<TEntity>(TEntity entity)
        where TEntity : class
    {
        using var scope = _scopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var entityAdded = context.Add(entity).Entity;

        await context.SaveChangesAsync().ConfigureAwait(false);

        return entityAdded;
    }

    public async ValueTask<TEntity?> FindAsync<TEntity>(params object[] keyValues)
        where TEntity : class
    {
        using var scope = _scopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        return await context.FindAsync<TEntity>(keyValues);
    }

    public async Task ResetState()
    {
        await _database.ResetAsync();
    }

    public async void Dispose()
    {
        await _database.DisposeAsync();
        await _factory.DisposeAsync().ConfigureAwait(false);
    }

}