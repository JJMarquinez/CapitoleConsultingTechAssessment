namespace AxaTechAssessment.Providers.Domain.Common.Errors.Builders;

public class ErrorBuilder : IErrorBuilder, IErrorWithDetailBuilder, IErrorWithHttpStatusCodeBuilder, IErrorBuildBuilder
{
    private string _code = null!;
    private string _detail = null!;
    private int _httpStatusCode = 0;

    public Error Build() => Error.NewInstance(_code, _detail, _httpStatusCode);

    public IErrorWithHttpStatusCodeBuilder WithDetail(string detail)
    {
        _detail = detail;
        return this;
    }

    public IErrorBuildBuilder WithHttpStatusCode(int httpStatusCode)
    {
        _httpStatusCode = httpStatusCode;
        return this;
    }

    public IErrorWithDetailBuilder WithCode(string code)
    {
        _code = code;
        return this;
    }
}