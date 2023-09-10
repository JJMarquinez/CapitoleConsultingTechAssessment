using AxaTechAssessment.Providers.Domain.Common.Errors;

namespace AxaTechAssessment.Providers.Domain.Common.Results.Builders;

public class ResultBuilder<TValue> : IResultBuilder<TValue>
{
    public Result<TValue?> BuildFailure(Error error) => Result.NewFailure<TValue?>(error);

    public Result<TValue> BuildSuccess(TValue value) => Result.NewSuccess(value);
}
