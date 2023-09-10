using AxaTechAssessment.Providers.Adapter.Common.Abstractions;
using AxaTechAssessment.Providers.Adapter.Persistence.Models;
using AxaTechAssessment.Providers.Adapter.Persistence.Models.Builders;
using AxaTechAssessment.Providers.Application.Common.Abstractions;
using AxaTechAssessment.Providers.Application.Common.Results;
using AxaTechAssessment.Providers.Application.Common.Results.Builders;
using AxaTechAssessment.Providers.Application.Entities.Providers;
using AxaTechAssessment.Providers.Application.Entities.Providers.Builders;
using System.Text.Json;

namespace AxaTechAssessment.Providers.Adapter.Providers;

public class ProviderAdapter : IProviderAdapter
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IResultDtoBuilder<ProviderDto?> _providerResultBuilder;
    private readonly IResultDtoBuilder<List<ProviderDto>?> _providerListResultBuilder;
    private readonly IProviderDtoBuilder _providerDtoBuilder;
    private readonly IProviderBuilder _providerBuilder;

    public ProviderAdapter(
        IUnitOfWork unitOfWork,
        IResultDtoBuilder<ProviderDto?> genericResultDtoBuilder,
        IResultDtoBuilder<List<ProviderDto>?> genericListResultDtoBuilder,
        IProviderDtoBuilder providerDtoBuilder,
        IProviderBuilder providerBuilder)
    {
        _unitOfWork = unitOfWork;
        _providerResultBuilder = genericResultDtoBuilder;
        _providerListResultBuilder = genericListResultDtoBuilder;
        _providerDtoBuilder = providerDtoBuilder;
        _providerBuilder = providerBuilder;
    }

    public async Task<ResultDto<List<ProviderDto>?>> CreateProvidersAsync(List<ProviderDto> providerDtoList)
    {
        ResultDto<List<ProviderDto>?> resultDto = null!;
        bool errorOccourred = false;

        foreach(var providerDto in providerDtoList) 
        {
            var provider = _providerBuilder
                .WithProviderId(providerDto.provider_id)
                .WithName(providerDto.name)
                .WithPostalAddres(providerDto.postal_address)
                .WithCreationDate(providerDto.created_at)
                .WithType(providerDto.type)
                .Build();

            var response = await _unitOfWork.GetProviderRepository().InsertAsync(provider);

            if (!response.Success)
            {
                errorOccourred = true;
                resultDto = _providerListResultBuilder.BuildFailure(response.Error);
                break;
            }
        }

        if (!errorOccourred)
        {
            await _unitOfWork.SaveAsync();
            resultDto = _providerListResultBuilder.BuildSuccess(providerDtoList);
        }

        return resultDto;
    }

    public async Task<ResultDto<ProviderDto?>> GetByIdAsync(int providerId)
    {
        var response = await _unitOfWork.GetProviderRepository().GetByIdAsync(providerId);
        ResultDto<ProviderDto?> resultDto; 
        if (response.Success)
        {
            var provider = JsonSerializer.Deserialize<Provider>(response.Value!);
            var providerDto = _providerDtoBuilder
                .WithProviderId(provider!.ProviderId)
                .WithName(provider.Name)
                .WithPostalAddres(provider.PostalAddress)
                .WithCreationDate(provider.CreatedAt)
                .WithType(provider.Type)
                .Build();
            resultDto = _providerResultBuilder.BuildSuccess(providerDto);
        }
        else
            resultDto = _providerResultBuilder.BuildFailure(response.Error);
        
        return resultDto;
    }
}
