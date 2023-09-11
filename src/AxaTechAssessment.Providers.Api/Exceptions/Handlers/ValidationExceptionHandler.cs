using AxaTechAssessment.Providers.Api.Exceptions.Supporters;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AxaTechAssessment.Providers.Api.Exceptions.Handlers;

public class ValidationExceptionHandler : IExceptionHandler
{
    private readonly IExceptionSupporter<ValidationException> _exceptionSupporter;

    public ValidationExceptionHandler(IExceptionSupporter<ValidationException> exceptionSupporter)
    {
        _exceptionSupporter = exceptionSupporter;
    }

    public ObjectResult Handle(Exception exception)
    {
        var validationException = (ValidationException)exception;
        var errors = validationException.Errors.Select(error => error.ErrorMessage).Aggregate((i, j) => i + ", " + j);
        return new ObjectResult(new { errorCode = "Bad Request", errorDescription = errors })
        {
            StatusCode = StatusCodes.Status400BadRequest
        };
    }

    public bool Support(Type exceptionType) => _exceptionSupporter.IsSupported(exceptionType);
}
