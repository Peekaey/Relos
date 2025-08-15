using Relos.Models.Pages;
using Relos.Models.Results;

namespace Relos.PageService.Interfaces;

public interface IWorkspacePageService
{
    Task<WorkspacesVm> GetUserWorkspacesAsync();
    Task<CreateWorkspaceSaveResult> CreateNewUserWorkspaceAsync(string workspaceName, string? workspaceDescription);
    Task<SaveResult> DeleteWorkspaceAsync(int workspaceId);
}