using AxaTechAssessment.Providers.Domain.Common.Errors;

namespace AxaTechAssessment.Providers.Domain.Common.Results.Builders;

public interface IResultBuilder
{
    Result BuildSuccess();

    Result BuildFailure(Error error);
}
