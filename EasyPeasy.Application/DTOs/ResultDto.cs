namespace EasyPeasy.Application.DTOs;

public class ResultDto<T>
{
    private ResultDto(T? data, bool isSuccess = true, string message = "")
    {
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
    }

    public bool IsSuccess { get; private set; }
    public string Message { get; private set; }
    public T? Data { get; private set; }
    
    
    public static ResultDto<T> Success() => new ResultDto<T>(default, true);
    public static ResultDto<T> Success(T data, string message = "") => new ResultDto<T>(data, true, message);
    public static ResultDto<T> Failure(string message) => new ResultDto<T>(default, false, message);
}