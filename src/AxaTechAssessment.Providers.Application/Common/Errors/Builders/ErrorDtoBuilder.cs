namespace AxaTechAssessment.Providers.Application.Common.Errors.Builders;

public class ErrorDtoBuilder : IErrorDtoBuilder
{
    private string _code = null!;
    private string _detail = null!;
    private int _httpStatusCode;
    public ErrorDto Build()
        => new ErrorDto { Code = _code, Detail = _detail, HttpStatusCode = _httpStatusCode }; 

    public IErrorDtoBuilder WithCode(string code)
    {
        _code = code;
        return this;
    }

    public IErrorDtoBuilder WithDetail(string detail)
    {
        _detail = detail;
        return this;
    }

    public IErrorDtoBuilder WithHttpStatusCode(int httpStatusCode)
    {
        _httpStatusCode = httpStatusCode;
        return this;
    }
}
