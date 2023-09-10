namespace AxaTechAssessment.Providers.Domain.Common.Errors;

public class Error
{
    internal string Code { get; }
    internal string Detail { get; }
    internal int HttpStatusCode { get; }

    private Error(string code, string detail, int httpStatusCode)
    {
        Ensure.Argument.NotNullOrEmpty(code, string.Format("{0} cannot be null or empty.", nameof(code)));
        Ensure.Argument.NotNullOrEmpty(detail, string.Format("{0} cannot be null or empty.", nameof(detail)));
        Ensure.Argument.IsNot(httpStatusCode == default, string.Format("{0} cannot be default int value.", nameof(httpStatusCode)));
        Code = code;
        Detail = detail;
        HttpStatusCode = httpStatusCode;
    }

    internal static Error NewInstance(string code, string detail, int httpStatusCode) => new(code, detail, httpStatusCode);

    public static implicit operator string(Error error) => error.Code;

    public static Error None = new("None", "None", 200);

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        Error other = (Error)obj;
        return string.Equals(Code, other.Code, StringComparison.Ordinal)
            && string.Equals(Detail, other.Detail, StringComparison.Ordinal)
            && HttpStatusCode == other.HttpStatusCode;
    }
}
