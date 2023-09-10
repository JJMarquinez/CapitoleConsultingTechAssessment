using AxaTechAssessment.Providers.Application.Common.Errors;

namespace AxaTechAssessment.Providers.Application.Common.Results.Builders;

public class ResultDtoBuilder : IResultDtoBuilder
{
    public ResultDto BuildFailure(ErrorDto error) => ResultDto.NewFailure(error);

    public ResultDto BuildSuccess() => ResultDto.NewSuccess();
}
