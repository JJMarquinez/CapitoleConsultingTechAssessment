namespace AxaTechAssessment.Providers.Domain.Common.Errors.Builders;

public interface IErrorBuilder
{
    IErrorWithDetailBuilder WithCode(string code);
}