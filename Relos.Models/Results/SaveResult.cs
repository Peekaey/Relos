namespace Relos.Models.Results;

public class SaveResult : Result
{
    public bool WasCreated { get; protected set; }
    public bool WasUpdated { get; protected set; }

    protected SaveResult(bool isSuccess, string errorMessage = "" , bool wasCreated = false, bool wasUpdated = false) : base(isSuccess)
    {
        WasCreated = wasCreated;
        WasUpdated = wasUpdated;
    }

    // Factory Method Pattern
    // https://refactoring.guru/design-patterns/factory-method
    public static SaveResult AsCreated()
    { 
        return new(true, wasCreated: true);
    }

    public static SaveResult AsUpdated()
    {
        return new(true, wasUpdated: true);
    }

    public static SaveResult AsFailure(string errorMessage)
    {
        return new(false, errorMessage);
    }
    
    protected override void OnSuccess()
    {
    }

    protected override void OnFailure()
    {
    }
}