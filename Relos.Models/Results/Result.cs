namespace Relos.Models.Results;

public abstract class Result
{
    public bool IsSuccess { get; protected set; }
    public bool IsFailure => !IsSuccess;
    protected string ErrorMessage { get; set; } = string.Empty;

    protected Result(bool isSuccess, string errorMessage = "")
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }

    // Template Method Pattern
    // https://refactoring.guru/design-patterns/template-method
    public void HandleResult()
    {
        if (IsSuccess)
        {
            OnSuccess();
        }
        else
        {
            OnFailure();
        }
    }

    protected virtual void OnSuccess()
    {
    }

    protected virtual void OnFailure()
    {
    }

    public override string ToString()
    {
        return IsSuccess ? "Success" : $"Failure: {ErrorMessage}";
    }
}