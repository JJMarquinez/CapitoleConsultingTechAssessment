using AutoMapper;
using AxaTechAssessment.Providers.Application.Common.Errors;
using AxaTechAssessment.Providers.Application.Mappings;
using AxaTechAssessment.Providers.Domain.Common.Results;

namespace AxaTechAssessment.Providers.Application.Common.Results;

public class ResultDto : IMapFrom<Result>
{

    public bool Success { get; set; }
    public ErrorDto Error { get; set; }

    public static ResultDto NewSuccess() => new ResultDto { Success = true, Error = ErrorDto.None };

    public static ResultDto NewFailure(ErrorDto error) => new ResultDto { Success = false, Error = error };

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Result, ResultDto>()
            .ForMember(d => d.Success, opt => opt.MapFrom(s => s.IsSuccess()));
    }
}