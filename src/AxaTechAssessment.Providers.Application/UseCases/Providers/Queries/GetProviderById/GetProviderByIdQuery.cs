using AxaTechAssessment.Providers.Application.Common.Results;
using AxaTechAssessment.Providers.Application.Entities.Providers;
using MediatR;

namespace AxaTechAssessment.Providers.Application.UseCases.Providers.Queries.GetProviderById;

public record GetProviderByIdQuery : IRequest<ResultDto<ProviderDto?>>
{
    public int Id { get; init; }
}
