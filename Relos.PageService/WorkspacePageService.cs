using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Relos.BusinessService.Interfaces;
using Relos.Helpers.Authentication;
using Relos.Models.Dtos;
using Relos.Models.Pages;
using Relos.Models.Results;
using Relos.PageService.Interfaces;

namespace Relos.PageService;

public class WorkspacePageService : IWorkspacePageService
{
    private readonly ILogger<WorkspacePageService> _logger;
    private readonly IWorkspaceBusinessService  _workspaceBusinessService;
    private readonly IAuthenticationStateProviderExtensions  _authenticationStateProviderExtensions;
    private readonly AuthenticationStateProvider  _authenticationStateProvider;
    
    public WorkspacePageService(ILogger<WorkspacePageService> logger, IWorkspaceBusinessService workspaceBusinessService,
        IAuthenticationStateProviderExtensions authenticationStateProviderExtensions, AuthenticationStateProvider authenticationStateProvider)
    {
        _logger = logger;
        _workspaceBusinessService = workspaceBusinessService;
        _authenticationStateProviderExtensions = authenticationStateProviderExtensions;
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<WorkspacesVm> GetUserWorkspacesAsync()
    {
        int? reloUserId = await _authenticationStateProviderExtensions.GetIdentityClaimReloUserIdAsInt();

        if (reloUserId == null)
        {
            WorkspacesVm.AsLoadFail();
        }

        List<WorkspaceDto> workspacesDtos = _workspaceBusinessService.GetWorkspacesByUserId(reloUserId.Value);

        return WorkspacesVm.AsLoadSuccess(workspacesDtos);
    }

    public async Task<CreateWorkspaceSaveResult> CreateNewUserWorkspaceAsync(string workspaceName, string? workspaceDescription)
    {
        int? reloUserId = await _authenticationStateProviderExtensions.GetIdentityClaimReloUserIdAsInt();
        if (reloUserId == null)
        {
            CreateWorkspaceSaveResult.AsFailure("Unable to determine User Id");
        }
        
        WorkspaceDto workspaceDto = new WorkspaceDto
        {
            Name = workspaceName,
            Description = workspaceDescription ?? string.Empty,
            CreatedOn = DateTime.UtcNow,
            OwnerId = reloUserId.Value
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
        int? reloId = await _authenticationStateProviderExtensions.GetIdentityClaimReloUserIdAsInt();
        if (reloId == null)
        {
           SaveResult.AsFailure("Unable to determine User Id");
        }
        
        SaveResult deleteResult = _workspaceBusinessService.DeleteWorkspace(workspaceId);
        if (!deleteResult.WasDeleted)
        {
            return SaveResult.AsFailure("Failed to delete workspace");
        }
        
        return SaveResult.AsDeleted();
    }
    
}