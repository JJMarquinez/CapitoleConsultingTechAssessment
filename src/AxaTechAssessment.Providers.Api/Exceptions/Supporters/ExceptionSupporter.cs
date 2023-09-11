namespace AxaTechAssessment.Providers.Api.Exceptions.Supporters;

public class ExceptionSupporter<TException> 
    : IExceptionSupporter<TException> 
    where TException : Exception
{
    public bool IsSupported(Type exceptionType)
        => typeof(TException).IsAssignableFrom(exceptionType);
}
