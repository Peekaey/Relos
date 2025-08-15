using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Relos.BusinessService.Interfaces;
using Relos.Models.Dtos;
using Relos.Models.Pages;
using Relos.Models.Results;
using Relos.PageService.Interfaces;

namespace Relos.PageService;

public class WorkspacePageService : IWorkspacePageService
{
    private readonly ILogger<WorkspacePageService> _logger;
    private readonly IWorkspaceBusinessService  _workspaceBusinessService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public WorkspacePageService(ILogger<WorkspacePageService> logger, IWorkspaceBusinessService workspaceBusinessService,
        IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _workspaceBusinessService = workspaceBusinessService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<WorkspacesVm> GetUserWorkspacesAsync()
    {
        // TODO add a claim for UserId
        int userId = 1;
        List<WorkspaceDto> workspacesDtos = _workspaceBusinessService.GetWorkspacesByUserId(userId);

        return WorkspacesVm.AsLoadSuccess(workspacesDtos);
    }

    public async Task<CreateWorkspaceSaveResult> CreateNewUserWorkspaceAsync(string workspaceName, string? workspaceDescription)
    {
        int userId = 1;

        WorkspaceDto workspaceDto = new WorkspaceDto
        {
            Name = workspaceName,
            Description = workspaceDescription ?? string.Empty,
            CreatedOn = DateTime.UtcNow,
            OwnerId = userId
        };
        
        SaveResult saveResult = _workspaceBusinessService.CreateNewWorkspace(workspaceDto);
        
        if (!saveResult.WasCreated)
        {
            return CreateWorkspaceSaveResult.AsFailure("Workspace not created");
        }
        // TODO Implement pattern matching
        workspaceDto.Id = saveResult.CreatedIdValue;
        
        return CreateWorkspaceSaveResult.AsCreated(workspaceDto);
    }

    public async Task<SaveResult> DeleteWorkspaceAsync(int workspaceId)
    {
        int userId = 1;
        SaveResult deleteResult = _workspaceBusinessService.DeleteWorkspace(workspaceId);
        if (!deleteResult.WasDeleted)
        {
            return SaveResult.AsFailure("Failed to delete workspace");
        }
        
        return SaveResult.AsDeleted();
    }
    
}