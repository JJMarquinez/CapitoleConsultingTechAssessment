using AxaTechAssessment.Providers.Adapter.Persistence.Models;
using AxaTechAssessment.Providers.Application.Common.Results;

namespace AxaTechAssessment.Providers.Adapter.Common.Abstractions;

public interface IUnitOfWork
{
    IRepository<ProviderDb> GetProviderRepository();

    Task<ResultDto<int>> SaveAsync();
}
