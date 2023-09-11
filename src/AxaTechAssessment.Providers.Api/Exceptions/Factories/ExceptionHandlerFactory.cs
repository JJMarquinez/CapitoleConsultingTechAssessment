using AxaTechAssessment.Providers.Api.Exceptions.Handlers;

namespace AxaTechAssessment.Providers.Api.Exceptions.Factories;

public class ExceptionHandlerFactory : IExceptionHandlerFactory
{
    private readonly IReadOnlyList<IExceptionHandler> _exceptionHandlers;

    public ExceptionHandlerFactory(IEnumerable<IExceptionHandler> exceptionHandlers)
    {
        _exceptionHandlers = exceptionHandlers.ToList().AsReadOnly();
    }

    public IExceptionHandler CreateHandler<TException>(TException exception) 
        where TException : Exception
    {
        IExceptionHandler handler = null!;
        var handlers = _exceptionHandlers.Where(handler => handler.IsHandled(exception.GetType())).ToList();
        var genericHandler = handlers.FirstOrDefault(handler => handler is GenericExceptionHandler);

        handlers.Remove(genericHandler!);

        if (handlers.Count == 0)
            handler = genericHandler!;
        else if (handlers.Count == 1)
            handler = handlers.First();
        else
            throw new Exception("Ambiguous exception handler to use. There must be just one registered.");

        return handler;
    }
}
