namespace EFM.Common.Application.Results;

/// <summary>
/// Represents the outcome of an operation, encapsulating success or failure information.
/// </summary>
/// <remarks>The <see cref="Result"/> class provides a way to represent the result of an operation, indicating
/// whether it succeeded or failed. For a successful result, <see cref="IsSuccess"/> will be <see langword="true"/> and
/// <see cref="Error"/> will be an empty string. For a failed result, <see cref="IsSuccess"/> will be <see
/// langword="false"/> and <see cref="Error"/> will contain a descriptive error message.</remarks>
public class Result
{
    public bool IsSuccess { get; }
    public string Error { get; }

    protected Result(bool isSuccess, string error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new Result(true, string.Empty);

    public static Result Failure(string error) => new Result(false, error);
}

public class Result<T> : Result
{
    public T Value { get; }

    private Result(T value, bool isSuccess, string error)
        : base(isSuccess, error)
    {
        Value = value;
    }

    public static Result<T> Success(T value) => new Result<T>(value, true, string.Empty);

    public static new Result<T> Failure(string error) => new Result<T>(default!, false, error);
}

