namespace Relos.Models.Results;

public class ServiceResult : Result
{
    protected ServiceResult(bool isSuccess, string errorMessage = "", string errorCode = "") 
        : base(isSuccess, errorCode)
    {
    }

    // Factory Method Pattern
    // https://refactoring.guru/design-patterns/factory-method
    public static ServiceResult AsSuccess()
    {
     return new (true, string.Empty, string.Empty);   
    }

    public static ServiceResult AsFailure(string errorMessage)
    {
        return new (false,errorMessage);
    }
    
    protected override void OnSuccess()
    {
    }

    protected override void OnFailure()
    {
    }
}