using AxaTechAssessment.Providers.Application.Common.Results;
using AxaTechAssessment.Providers.Infrastructure.Persistence.Models;
using AxaTechAssessment.Providers.Infrastructure.Repositories;

namespace AxaTechAssessment.Providers.Infrastructure.UnitOfWorks;

public interface IUnitOfWork 
{
    IRepository<Provider> GetProviderRepository();

    Task<ResultDto<int>> SaveAsync();
}
