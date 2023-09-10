using AxaTechAssessment.Providers.Adapter.Persistence.Models;
using AxaTechAssessment.Providers.Application.Common.Results;

namespace AxaTechAssessment.Providers.Adapter.Common.Abstractions;

public interface IUnitOfWork
{
    IRepository<Provider> GetProviderRepository();

    Task<ResultDto<int>> SaveAsync();
}
