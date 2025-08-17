using Relos.Models.Pages;
using Relos.Models.Results;

namespace Relos.PageService.Interfaces;

public interface IWorkspacePageService
{
    Task<WorkspacesPage> GetUserWorkspacesAsync();
    Task<CreateWorkspaceSaveResult> CreateNewWorkspaceAsync(string workspaceName, string? workspaceDescription);
    Task<SaveResult> DeleteWorkspaceAsync(int workspaceId);
}