namespace Nummora.Domain;

public class Result<T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }
    
    public static Result<T> Success(bool IsSuccess, string Message)
    {
        return new Result<T> { IsSuccess = true, Message = Message };
    }

    public static Result<T> Failure(bool IsSuccess, string Message)
    {
        return new Result<T> { IsSuccess = false, Message = Message };
    }
}