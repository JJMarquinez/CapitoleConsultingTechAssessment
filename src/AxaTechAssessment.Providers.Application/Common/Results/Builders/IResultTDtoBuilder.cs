using AxaTechAssessment.Providers.Application.Common.Errors;

namespace AxaTechAssessment.Providers.Application.Common.Results.Builders;

internal interface IResultDtoBuilder<TValue>
{
    ResultDto<TValue> BuildSuccess(TValue value);
    ResultDto<TValue?> BuildFailure(ErrorDto error);
}
