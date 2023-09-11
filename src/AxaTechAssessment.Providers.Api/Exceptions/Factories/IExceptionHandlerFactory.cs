using AxaTechAssessment.Providers.Api.Exceptions.Handlers;

namespace AxaTechAssessment.Providers.Api.Exceptions.Factories;

public interface IExceptionHandlerFactory
{
    IExceptionHandler CreateHandler<TException>(TException exception) where TException : Exception;
}
