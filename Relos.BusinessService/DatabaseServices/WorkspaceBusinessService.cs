using Microsoft.Extensions.Logging;
using Relos.BusinessService.Interfaces;
using Relos.DataService.Interfaces;
using Relos.Helpers.Extensions;
using Relos.Models.DatabaseModels;
using Relos.Models.Dtos;
using Relos.Models.RequestDtos;
using Relos.Models.Results;

namespace Relos.BusinessService.DatabaseServices;

public class WorkspaceBusinessService : IWorkspaceBusinessService
{
    private readonly ILogger<WorkspaceBusinessService> _logger;
    private readonly IWorkspaceService  _workspaceService;

    public WorkspaceBusinessService(ILogger<WorkspaceBusinessService> logger, IWorkspaceService workspaceService)
    {
        _logger = logger;
        _workspaceService = workspaceService;
    }
    
    public SaveResult CreateNewWorkspace(WorkspaceDto workspaceDto)
    {
        Workspace workspace = new Workspace
        {
            WorkspaceName = workspaceDto.Name,
            WorkspaceDescription = workspaceDto.Description,
            WorkspaceOwnerId = workspaceDto.OwnerId,
            CreatedDateTimeUtc = workspaceDto.CreatedOn
        };
        
        return _workspaceService.SaveNewWorkspace(workspace);
        
    }

    public List<WorkspaceDto> GetWorkspacesByUserId(int userId)
    {
        List<Workspace> workspaces = _workspaceService.GetWorkspacesByUserId(userId).ToList();

        List<WorkspaceDto> workspaceDtos = workspaces.Select(w => new WorkspaceDto
        {
            Name = w.WorkspaceName,
            Description = w.WorkspaceDescription,
            OwnerId = w.WorkspaceOwnerId,
            CreatedOn = w.CreatedDateTimeUtc,
            Id = w.Id
        }).ToList().ConvertToAest();

        return workspaceDtos;
    }

    public SaveResult DeleteWorkspace(int workspaceId)
    {
        Workspace? workspace = _workspaceService.GetWorkspaceById(workspaceId);
        bool deleteSuccess = false;
        if (workspace == null)
        { 
            return SaveResult.AsDeleted();
        }
        
        SaveResult deleteResult = _workspaceService.DeleteWorkspace(workspace);

        if (!deleteResult.WasDeleted)
        {
            return SaveResult.AsFailure("Failed to delete workspace");
        }
        
        return SaveResult.AsDeleted();
        
    }
    
    

}