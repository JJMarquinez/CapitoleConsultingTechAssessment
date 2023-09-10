using AxaTechAssessment.Providers.Domain.Common.Errors;

namespace AxaTechAssessment.Providers.Domain.Common.Results.Builders;

public class ResultBuilder : IResultBuilder
{
    public Result BuildFailure(Error error) => Result.NewFailure(error);

    public Result BuildSuccess() => Result.NewSuccess();
}
