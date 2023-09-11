using AutoMapper;
using AxaTechAssessment.Providers.Application.Common.Abstractions;
using AxaTechAssessment.Providers.Application.Common.Results;
using AxaTechAssessment.Providers.Application.Entities.Providers;
using AxaTechAssessment.Providers.Domain.Entities.Builders;
using MediatR;

namespace AxaTechAssessment.Providers.Application.UseCases.Providers.Commands.ImportProvider;

public class ImportProviderCommandHandler
    : IRequestHandler<ImportProviderCommand, ResultDto<List<ProviderDto>?>>
{
    private readonly IProviderAdapter _providerAdapter;
    private readonly IProviderBuilder _providerBuilder;
    private readonly IMapper _mapper;

    public ImportProviderCommandHandler(IProviderAdapter providerAdapter, IProviderBuilder providerBuilder, IMapper mapper)
    {
        _providerAdapter = providerAdapter;
        _providerBuilder = providerBuilder;
        _mapper = mapper;
    }

    public async Task<ResultDto<List<ProviderDto>?>> Handle(ImportProviderCommand request, CancellationToken cancellationToken)
    {
        var providerDtoList = new List<ProviderDto>();
        foreach (var providerDto in request.Providers!)
        {
            var provider = _providerBuilder
                .WithProviderId(providerDto.provider_id)
                .WithName(providerDto.name)
                .WithPostalAddress(providerDto.postal_address)
                .WithCreatedDate(providerDto.created_at)
                .WithType(providerDto.type)
                .Build(); 
            providerDtoList.Add(_mapper.Map<ProviderDto>(provider));
        }

        return await _providerAdapter.CreateProvidersAsync(providerDtoList); // It sends data to database framework through an adapter and gets its response
    }
}
