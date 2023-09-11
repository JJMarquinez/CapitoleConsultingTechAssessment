using AxaTechAssessment.Providers.Api.Exceptions.Supporters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AxaTechAssessment.Providers.Api.Exceptions.Handlers;

public class GenericExceptionHandler : IExceptionHandler
{
    private readonly IExceptionSupporter<Exception> _exceptionSupporter;

    public GenericExceptionHandler(IExceptionSupporter<Exception> exceptionSupporter)
    {
        _exceptionSupporter = exceptionSupporter;
    }

    public ObjectResult Handle(Exception exception)
    {
        return new ObjectResult(new { errorCode = "InternalServerError", errorDescription = "An error server occured." })
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };
    }

    public bool Support(Type exceptionType) => _exceptionSupporter.IsSupported(exceptionType);
}
