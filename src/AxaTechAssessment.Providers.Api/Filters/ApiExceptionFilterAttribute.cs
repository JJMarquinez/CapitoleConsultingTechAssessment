using AxaTechAssessment.Providers.Adapter.Common.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AxaTechAssessment.Providers.Api.Filters;

public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly IApiLogger _logger;

    public ApiExceptionFilterAttribute(IApiLogger logger)
    {
        _logger = logger;
    }

    public override void OnException(ExceptionContext context)
    {
        _logger.Error(context.Exception, "Exception has occurred while executing the request with TraceIdIdentifier: {TraceIdentifier} and exception message: {Message}", context.HttpContext.TraceIdentifier, context.Exception.Message);

        context.Result = new ObjectResult(new { errorCode = "InternalServerError", errorDescription = "An error server occured." })
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };

        context.ExceptionHandled = true;

        base.OnException(context);
    }
}
