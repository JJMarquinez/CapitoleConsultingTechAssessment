using Microsoft.AspNetCore.Mvc;

namespace AxaTechAssessment.Providers.Api.Exceptions.Strategy;

public interface IExceptionHandlerStrategy
{
    ObjectResult ExecuteHandling<TExecption>(TExecption exception) where TExecption : Exception;
}
