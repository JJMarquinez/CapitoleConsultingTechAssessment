using AxaTechAssessment.Providers.Adapter.Common.Abstractions;
using AxaTechAssessment.Providers.Adapter.Persistence.Models;
using AxaTechAssessment.Providers.Application.Common.Results;
using AxaTechAssessment.Providers.Application.Common.Results.Builders;
using AxaTechAssessment.Providers.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AxaTechAssessment.Providers.Infrastructure.UnitOfWorks;

public class UnitOfWork : IUnitOfWork, IDisposable
{ 
    private bool _disposed;
    private readonly ApplicationDbContext _context;
    private readonly IRepository<ProviderDb> _providerRepository;
    private readonly IResultDtoBuilder<int> _genericResultDtoBuilder;

    public UnitOfWork(ApplicationDbContext context, IRepository<ProviderDb> providerRepository, IResultDtoBuilder<int> genericResultDtoBuilder)
    {
        _context = context;
        _providerRepository = providerRepository;
        _genericResultDtoBuilder = genericResultDtoBuilder;
    }
    public IRepository<ProviderDb> GetProviderRepository() => _providerRepository;

    public async Task<ResultDto<int>> SaveAsync()
    {
        // Insert explicit values into SQL Server IDENTITY fails by default; this is a workaround.
        _context.Database.OpenConnection();
        await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Provider ON").ConfigureAwait(false);
        var result = _genericResultDtoBuilder.BuildSuccess(await _context.SaveChangesAsync().ConfigureAwait(false));
        await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Provider OFF").ConfigureAwait(false);
        _context.Database.CloseConnection();
        return result;

    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            this._disposed = true;
        }
    }
}
