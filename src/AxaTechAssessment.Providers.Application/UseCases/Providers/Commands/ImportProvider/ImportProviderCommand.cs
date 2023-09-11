using AxaTechAssessment.Providers.Application.Common.Results;
using AxaTechAssessment.Providers.Application.Entities.Providers;
using MediatR;

namespace AxaTechAssessment.Providers.Application.UseCases.Providers.Commands.ImportProvider;

public record ImportProviderCommand : IRequest<ResultDto<List<ProviderDto>?>>
{
    public List<ProviderDto>? Providers { get; init; }
}
