using Relos.Models.Dtos;

namespace Relos.Models.Pages;

public class WorkspacesVm
{
    public bool LoadSuccess { get; set; }
    public List<WorkspaceDto> Workspaces { get; set; }

    public WorkspacesVm(bool loadSuccess, List<WorkspaceDto> workspaces)
    {
        LoadSuccess = loadSuccess;
        Workspaces = workspaces;
    }

    public static WorkspacesVm AsLoadSuccess(List<WorkspaceDto> workspaces)
    {
        return new WorkspacesVm(true, workspaces);
    }

    public static WorkspacesVm AsLoadFail()
    {
        return new WorkspacesVm(false, new List<WorkspaceDto>());
    }
    
    
}