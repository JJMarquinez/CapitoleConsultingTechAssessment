namespace AxaTechAssessment.Providers.Application.Common.Errors.Builders;

public interface IErrorDtoBuilder
{
    IErrorDtoBuilder WithCode(string code);
    IErrorDtoBuilder WithDetail(string detail);
    IErrorDtoBuilder WithHttpStatusCode(int  httpStatusCode);
    ErrorDto Build();
}
