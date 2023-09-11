using Microsoft.AspNetCore.Mvc;

namespace AxaTechAssessment.Providers.Api.Exceptions.Handlers;

public interface IExceptionHandler
{
    ObjectResult Handle(Exception exception);
    bool IsHandled(Type exceptionType);
}
