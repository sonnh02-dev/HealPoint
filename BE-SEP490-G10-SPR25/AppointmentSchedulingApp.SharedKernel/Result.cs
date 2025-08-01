namespace AppointmentSchedulingApp.SharedKernel;

public class Result
{
    public bool IsSuccess { get; init; }
    public string Message { get; init; } = string.Empty;
    public Error Error { get; init; } = Error.None;

    public static Result Success(string message = "Success") => new()
    {
        IsSuccess = true,
        Message = message
    };

    public static Result Failure(string message, Error? error = null) => new()
    {
        IsSuccess = false,
        Message = message,
        Error = error ?? Error.Failure("Default.Failure", message)
    };
}

public class Result<T> : Result
{
    public T? Data { get; init; }

    public static Result<T> Success(T data, string message = "Success") => new()
    {
        IsSuccess = true,
        Data = data,
        Message = message
    };

    public static Result<T> Failure(string message, Error? error = null) => new()
    {
        IsSuccess = false,
        Data = default,
        Message = message,
        Error = error ?? Error.Failure("Default.Failure", message)
    };
}
