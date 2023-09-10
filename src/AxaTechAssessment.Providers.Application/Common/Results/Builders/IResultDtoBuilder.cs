using AxaTechAssessment.Providers.Application.Common.Errors;

namespace AxaTechAssessment.Providers.Application.Common.Results.Builders;

public interface IResultDtoBuilder
{
    ResultDto BuildSuccess();
    ResultDto BuildFailure(ErrorDto errorDto);
}
