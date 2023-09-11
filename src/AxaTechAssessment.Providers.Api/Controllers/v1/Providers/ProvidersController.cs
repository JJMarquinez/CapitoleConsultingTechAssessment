using AxaTechAssessment.Providers.Application.Entities.Providers;
using AxaTechAssessment.Providers.Application.UseCases.Providers.Commands.ImportProvider;
using AxaTechAssessment.Providers.Application.UseCases.Providers.Queries.GetProviderById;
using Microsoft.AspNetCore.Mvc;

namespace AxaTechAssessment.Providers.Api.Controllers.v1.Providers;

[ApiVersion("1.0")]
public class ProvidersController : ApiControllerBase
{
    [HttpGet("{providerId}")]
    public async Task<IActionResult> GetByIdAsync(int providerId)    
    {
        return Ok(await Mediator.Send(new GetProviderByIdQuery { Id = providerId }));
    }

    [HttpPost("import")]
    public async Task<IActionResult> ImportAsync(List<ProviderDto> providers)
    {
        return Ok(await Mediator.Send(new ImportProviderCommand { Providers = providers }));
    }
}
