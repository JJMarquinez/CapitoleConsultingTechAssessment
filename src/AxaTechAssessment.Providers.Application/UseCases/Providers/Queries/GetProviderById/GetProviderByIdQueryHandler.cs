using AutoMapper;
using AxaTechAssessment.Providers.Application.Common.Abstractions;
using AxaTechAssessment.Providers.Application.Common.Results;
using AxaTechAssessment.Providers.Application.Entities.Providers;
using AxaTechAssessment.Providers.Domain.Entities.Builders;
using MediatR;

namespace AxaTechAssessment.Providers.Application.UseCases.Providers.Queries.GetProviderById;

public class GetProviderByIdQueryHandler
    : IRequestHandler<GetProviderByIdQuery, ResultDto<ProviderDto?>>
{
    private readonly IProviderAdapter _providerAdapter;
    private readonly IProviderBuilder _providerBuilder;
    private readonly IMapper _mapper;

    public GetProviderByIdQueryHandler(IProviderAdapter providerAdapter, IProviderBuilder providerBuilder, IMapper mapper)
    {
        _providerAdapter = providerAdapter;
        _providerBuilder = providerBuilder;
        _mapper = mapper;
    }

    public async Task<ResultDto<ProviderDto?>> Handle(GetProviderByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _providerAdapter.GetByIdAsync(request.Id);
        if (result.Success)
        {
            var providerDto = result.Value!;
            var provider = _providerBuilder
                .WithProviderId(providerDto.provider_id)
                .WithName(providerDto.name)
                .WithPostalAddress(providerDto.postal_address)
                .WithCreatedDate(providerDto.created_at)
                .WithType(providerDto.type)
                .Build(); // Creating the provider entity, it gets the provider critical bussiness rules executed

            result.Value = _mapper.Map<ProviderDto>(provider);
        }
        return result;
    }
}
