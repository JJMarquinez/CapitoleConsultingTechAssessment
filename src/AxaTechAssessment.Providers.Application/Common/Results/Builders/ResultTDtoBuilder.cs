using AxaTechAssessment.Providers.Application.Common.Errors;

namespace AxaTechAssessment.Providers.Application.Common.Results.Builders;

public class ResultDtoBuilder<TValue> : IResultDtoBuilder<TValue>
{
    public ResultDto<TValue?> BuildFailure(ErrorDto error) => ResultDto<TValue?>.NewFailure(error);

    public ResultDto<TValue> BuildSuccess(TValue value) => ResultDto<TValue>.NewSuccess(value);
}
