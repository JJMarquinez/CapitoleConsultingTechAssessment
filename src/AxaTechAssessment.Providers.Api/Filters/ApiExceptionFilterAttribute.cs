using AxaTechAssessment.Providers.Adapter.Common.Abstractions;
using AxaTechAssessment.Providers.Api.Exceptions.Factories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AxaTechAssessment.Providers.Api.Filters;

public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly IApiLogger _logger;
    private readonly IExceptionHandlerFactory _exceptionHandlerFactory;

    public ApiExceptionFilterAttribute(IApiLogger logger, IExceptionHandlerFactory exceptionHandlerFactory)
    {
        _logger = logger;
        _exceptionHandlerFactory = exceptionHandlerFactory;
    }

    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        _logger.Error(exception, "Exception has occurred while executing the request with TraceIdIdentifier: {TraceIdentifier} and exception message: {Message}", context.HttpContext.TraceIdentifier, exception.Message);
        var handler = _exceptionHandlerFactory.CreateHandler(exception);
        context.Result = handler.Handle(exception);

        context.ExceptionHandled = true;

        base.OnException(context);
    }
}
