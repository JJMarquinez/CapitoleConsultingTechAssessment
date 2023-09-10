using AxaTechAssessment.Providers.Domain.Common.Errors;

namespace AxaTechAssessment.Providers.Domain.Common.Results.Builders;

public class ResultBuilder<TValue> : IResultBuilder<TValue>
{
    public Result<TValue?> BuildFailure(Error error) => Result.Failure<TValue?>(error);

    public Result<TValue> BuildSuccess(TValue value) => Result.Success(value);
}
