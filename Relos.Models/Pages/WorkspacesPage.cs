using Relos.Models.Dtos;

namespace Relos.Models.Pages;

public class WorkspacesPage
{
    public bool LoadSuccess { get; set; }
    public List<WorkspaceDto> Workspaces { get; set; }
    public string? ErrorMessage { get; set; }

    public WorkspacesPage(bool loadSuccess, List<WorkspaceDto> workspaces, string? errorMessage = "")
    {
        LoadSuccess = loadSuccess;
        Workspaces = workspaces;
        ErrorMessage = errorMessage;
    }

    public static WorkspacesPage AsLoadSuccess(List<WorkspaceDto> workspaces)
    {
        return new WorkspacesPage(true, workspaces);
    }

    public static WorkspacesPage AsLoadFail(string errorMessage = "")
    {
        return new WorkspacesPage(false, new List<WorkspaceDto>(), errorMessage);
    }
}