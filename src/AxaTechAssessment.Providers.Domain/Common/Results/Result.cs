﻿using AxaTechAssessment.Providers.Domain.Common.Errors;

namespace AxaTechAssessment.Providers.Domain.Common.Results;

public class Result
{
    private readonly bool _success;
    internal Error Error { get; }

    private Result() { }

    private protected Result(bool success, Error error)
    {
        Ensure.Argument.NotNull(error, string.Format("{0} cannot be null.", nameof(error)));
        _success = success;
        Error = error;
    }

    public bool IsSuccess() => _success;
    public bool IsFailure() => !IsSuccess();
    public static Result NewSuccess() => new(true, Error.None);
    public static Result NewFailure(Error error) => new(false, error);
    public static Result<TValue> NewSuccess<TValue>(TValue value) => Result<TValue>.NewInstance(value, true, Error.None);
    public static Result<TValue?> NewFailure<TValue>(Error error) => Result<TValue?>.NewInstance(default, false, error);
}