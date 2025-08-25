namespace Relos.Models.Results;

public class LoadResult<T> : Result
{
    protected LoadResult(bool isSuccess, string errorMessage = "") 
        : base(isSuccess, errorMessage)
    {
    }
    
    public T? Data { get; set; }

    public static LoadResult<T> AsSuccess(T data)
    {
        return new LoadResult<T>(isSuccess: true, errorMessage : string.Empty) { Data = data };
    }
    
    public static LoadResult<T> AsFailure(string errorMessage)
    {
        return new LoadResult<T>(isSuccess: false, errorMessage);
    }

    public string GetErrorMessage()
    {
        return ErrorMessage;
    }
    
    
    
    
}