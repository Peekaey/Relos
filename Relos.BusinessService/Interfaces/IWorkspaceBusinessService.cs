using Relos.Models.Dtos;
using Relos.Models.RequestDtos;
using Relos.Models.Results;

namespace Relos.BusinessService.Interfaces;

public interface IWorkspaceBusinessService
{
    SaveResult CreateNewWorkspace(WorkspaceDto workspaceDto);
    List<WorkspaceDto> GetWorkspacesByUserId(int userId);
    SaveResult DeleteWorkspace(int workspaceId);

}