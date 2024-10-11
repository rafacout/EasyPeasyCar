namespace EasyPeasy.Application.DTOs;

public class ResultViewModel<T>
{
    private ResultViewModel(T? data, bool isSuccess = true, string message = "")
    {
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
    }

    public bool IsSuccess { get; private set; }
    public string Message { get; private set; }
    public T? Data { get; private set; }
    
    
    public static ResultViewModel<T> Success() => new ResultViewModel<T>(default, true);
    public static ResultViewModel<T> Success(T data, string message = "") => new ResultViewModel<T>(data, true, message);
    public static ResultViewModel<T> Failure(string message) => new ResultViewModel<T>(default, false, message);
}