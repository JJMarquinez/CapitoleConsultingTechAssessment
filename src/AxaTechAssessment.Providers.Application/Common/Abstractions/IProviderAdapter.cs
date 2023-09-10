using AxaTechAssessment.Providers.Application.Common.Results;
using AxaTechAssessment.Providers.Application.Entities.Providers;

namespace AxaTechAssessment.Providers.Application.Common.Abstractions;

public interface IProviderAdapter
{
    Task<ResultDto<ProviderDto?>> GetByIdAsync(int providerId);
    Task<ResultDto<List<ProviderDto>?>> CreateProvidersAsync(List<ProviderDto> providerDtoList);
}
