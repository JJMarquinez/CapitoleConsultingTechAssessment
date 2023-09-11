using AxaTechAssessment.Providers.Api.Exceptions.Factories;
using Microsoft.AspNetCore.Mvc;

namespace AxaTechAssessment.Providers.Api.Exceptions.Strategy;

public class ExceptionHandlerStrategy : IExceptionHandlerStrategy
{
    private readonly IExceptionHandlerFactory _exceptionHandlerFactory;

    public ExceptionHandlerStrategy(IExceptionHandlerFactory exceptionHandlerFactory)
    {
        _exceptionHandlerFactory = exceptionHandlerFactory;
    }

    public ObjectResult ExecuteHandling<TExecption>(TExecption exception) where TExecption : Exception
    {
        var handler = _exceptionHandlerFactory.CreateHandler(exception);
        return handler.Handle(exception);
    }
}
