namespace Relos.Models.Results;

public class AuthenticateResult : Result
{
    public int? UserId { get; set; }
    protected AuthenticateResult(bool isSuccess, int? userId, string errorMessage = "", string errorCode = "") 
        : base(isSuccess, errorCode)
    {
    }

    // Factory Method Pattern
    // https://refactoring.guru/design-patterns/factory-method
    public static AuthenticateResult AsSuccess(int userId)
    {
        return new (true, userId,string.Empty, string.Empty);   
    }

    public static AuthenticateResult AsFailure(string errorMessage)
    {
        return new (false, null, errorMessage);
    }
    
    protected override void OnSuccess()
    {
    }

    protected override void OnFailure()
    {
    }
}