namespace BookStream.Application.Models.ViewModels;
public class ResultViewModel
{
    public ResultViewModel(bool isSuccess = true, string message = "")
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public bool IsSuccess { get; private set; }
    public string Message { get; private set; }
    public static ResultViewModel Success()
       => new();
    public static ResultViewModel Error(string message)
       => new(false, message);
}

public class ResultViewModel<T> : ResultViewModel
{
    public ResultViewModel(T? result, bool isSuccess = true, string message = "")
        : base(isSuccess, message)
    {
        Result = result;
    }

    public T? Result { get; private set; }
    public static ResultViewModel<T> Success(T? result)
        => new(result);

    public static new ResultViewModel<T> Error(string message)
        => new(default, false, message);
}
