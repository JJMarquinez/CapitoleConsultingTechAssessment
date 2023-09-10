using AxaTechAssessment.Providers.Adapter.Common.Abstractions;
using AxaTechAssessment.Providers.Adapter.Persistence.Models;
using AxaTechAssessment.Providers.Application.Common.Results;
using AxaTechAssessment.Providers.Application.Common.Results.Builders;
using AxaTechAssessment.Providers.Infrastructure.Persistence;

namespace AxaTechAssessment.Providers.Infrastructure.UnitOfWorks;

public class UnitOfWork : IUnitOfWork, IDisposable
{ 
    private bool _disposed;
    private readonly ApplicationDbContext _context;
    private readonly IRepository<Provider> _providerRepository;
    private readonly IResultDtoBuilder<int> _genericResultDtoBuilder;

    public UnitOfWork(ApplicationDbContext context, IRepository<Provider> providerRepository, IResultDtoBuilder<int> genericResultDtoBuilder)
    {
        _context = context;
        _providerRepository = providerRepository;
        _genericResultDtoBuilder = genericResultDtoBuilder;
    }
    public IRepository<Provider> GetProviderRepository() => _providerRepository;

    public async Task<ResultDto<int>> SaveAsync()
        => _genericResultDtoBuilder.BuildSuccess(await _context.SaveChangesAsync().ConfigureAwait(false));

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
