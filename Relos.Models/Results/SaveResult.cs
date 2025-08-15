namespace Relos.Models.Results;

public class SaveResult : Result
{
    public bool WasCreated { get; protected set; }
    public bool WasUpdated { get; protected set; }
    public bool WasDeleted { get; protected set; }
    public int? CreatedId { get; set; }
    
    public int CreatedIdValue 
    { 
        get 
        {
            if (!WasCreated || !CreatedId.HasValue)
                throw new InvalidOperationException("CreatedId is only available when WasCreated is true");
            return CreatedId.Value;
        } 
    }

    protected SaveResult(bool isSuccess, string errorMessage = "", bool wasCreated = false, bool wasUpdated = false, bool wasDeleted = false, int? createdId = null) : base(isSuccess)
    {
        WasCreated = wasCreated;
        WasUpdated = wasUpdated;
        ErrorMessage = errorMessage;
        CreatedId = createdId;
        WasDeleted = wasDeleted;
    }

    // Factory Method Pattern
    // https://refactoring.guru/design-patterns/factory-method
    public static SaveResult AsCreated(int createdId)
    { 
        return new(true, wasCreated: true, createdId: createdId);
    }

    public static SaveResult AsUpdated()
    {
        return new(true, wasUpdated: true);
    }

    public static SaveResult AsFailure(string errorMessage)
    {
        return new(false, errorMessage);
    }

    public static SaveResult AsDeleted()
    {
        return new (true, wasDeleted: true);
    }
    
    protected override void OnSuccess()
    {
    }

    protected override void OnFailure()
    {
    }
}