using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AxaTechAssessment.Providers.Api.Exceptions.Handlers;

public class GenericExceptionHandler : IExceptionHandler
{
    public ObjectResult Handle(Exception exception)
    {
        return new ObjectResult(new { errorCode = "InternalServerError", errorDescription = "An error server occured." })
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };
    }

    public bool IsHandled(Type exceptionType)
        => typeof(Exception).IsAssignableFrom(exceptionType);

}
