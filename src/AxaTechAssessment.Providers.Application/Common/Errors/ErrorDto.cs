using AxaTechAssessment.Providers.Application.Mappings;
using AxaTechAssessment.Providers.Domain.Common.Errors;

namespace AxaTechAssessment.Providers.Application.Common.Errors;

public class ErrorDto : IMapFrom<Error>
{
    public string Code { get; set; }

    public string Detail { get; set; }

    public int HttpStatusCode { get; set; }

    public static ErrorDto None = new ErrorDto
    {
        Code = "None",
        Detail = "None",
        HttpStatusCode = 200
    };
}