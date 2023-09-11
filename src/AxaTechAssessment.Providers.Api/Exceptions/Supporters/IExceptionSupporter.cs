namespace AxaTechAssessment.Providers.Api.Exceptions.Supporters;

public interface IExceptionSupporter<TException> where TException : Exception
{
    bool IsSupported(Type exceptionType);
}
