using Relos.Models.Dtos;

namespace Relos.Models.Results;

public class CreateWorkspaceSaveResult : SaveResult
{
    public WorkspaceDto? WorkspaceDto { get; set; }

    protected CreateWorkspaceSaveResult(bool isSuccess, string errorMessage = "", bool wasCreated = false, bool wasUpdated = false,
        WorkspaceDto? workspaceDto = null) : base(isSuccess, errorMessage, wasCreated, wasUpdated)
    {
        WorkspaceDto = workspaceDto;
    }

    // Factory methods for creating instances
    public static CreateWorkspaceSaveResult AsCreated(WorkspaceDto workspaceDto)
    {
        return new(true, wasCreated: true, workspaceDto: workspaceDto);
    }

    public static CreateWorkspaceSaveResult AsUpdated(WorkspaceDto workspaceDto)
    {
        return new(true, wasUpdated: true, workspaceDto: workspaceDto);
    }

    public static new CreateWorkspaceSaveResult AsFailure(string errorMessage)
    {
        return new(false, errorMessage: errorMessage);
    }

    // Property to check if we have a valid workspace
    public bool HasWorkspace => IsSuccess && WorkspaceDto != null;
    
    
    public bool TryGetWorkspace(out WorkspaceDto? workspace)
    {
        workspace = IsSuccess ? WorkspaceDto : null;
        return HasWorkspace;
    }

    protected override void OnSuccess()
    {
    }

    protected override void OnFailure()
    {
    }
    
}