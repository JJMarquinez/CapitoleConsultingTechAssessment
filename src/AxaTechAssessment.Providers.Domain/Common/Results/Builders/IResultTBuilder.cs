using AxaTechAssessment.Providers.Domain.Common.Errors;

namespace AxaTechAssessment.Providers.Domain.Common.Results.Builders;

public interface IResultBuilder<TValue>
{
    Result<TValue> BuildSuccess(TValue value);
    Result<TValue?> BuildFailure(Error error);
}
