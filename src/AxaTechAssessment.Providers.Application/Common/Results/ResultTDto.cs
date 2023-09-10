using AutoMapper;
using AxaTechAssessment.Providers.Application.Common.Errors;
using AxaTechAssessment.Providers.Application.Mappings;
using AxaTechAssessment.Providers.Domain.Common.Results;

namespace AxaTechAssessment.Providers.Application.Common.Results;

public class ResultDto<TValue> : IMapFrom<Result<TValue>>
{
    public bool Success { get; set; }
    public ErrorDto Error { get; set; }
    public TValue? Value { get; set; }

    public static ResultDto<TValue> NewSuccess(TValue value) => new() { Value = value, Success = true, Error = ErrorDto.None };

    public static ResultDto<TValue?> NewFailure(ErrorDto error) => new() { Value = default, Success = false, Error = error };

    public void Mapping(Profile profile)
    {
        profile.CreateMap(typeof(Result<>), typeof(ResultDto<>))
            .ForMember("Success", opt => opt.MapFrom(nameof(Result<object>.IsSuccess)));
    }
}
