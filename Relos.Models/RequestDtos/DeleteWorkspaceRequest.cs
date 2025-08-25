namespace Relos.Models.RequestDtos;

public class DeleteWorkspaceRequest
{
    public int WorkspaceId { get; set; }
    public string WorkspaceName { get; set; } = string.Empty;
}