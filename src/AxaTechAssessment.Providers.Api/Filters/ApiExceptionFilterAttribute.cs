using AxaTechAssessment.Providers.Adapter.Common.Abstractions;
using AxaTechAssessment.Providers.Api.Exceptions.Strategy;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AxaTechAssessment.Providers.Api.Filters;

public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly IApiLogger _logger;
    private readonly IExceptionHandlerStrategy _exceptionHandlerStrategy;

    public ApiExceptionFilterAttribute(IApiLogger logger, IExceptionHandlerStrategy exceptionHandlerStrategy)
    {
        _logger = logger;
        _exceptionHandlerStrategy = exceptionHandlerStrategy;
    }

    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        _logger.Error(exception, "Exception has occurred while executing the request with TraceIdIdentifier: {TraceIdentifier} and exception message: {Message}", context.HttpContext.TraceIdentifier, exception.Message);
        context.Result = _exceptionHandlerStrategy.ExecuteHandling(exception);
        context.ExceptionHandled = true;

        base.OnException(context);
    }
}
