using Relos.Models.DatabaseModels;
using Relos.Models.Results;

namespace Relos.DataService.Interfaces;

public interface IWorkspaceService
{
    SaveResult SaveNewWorkspace(Workspace workspace);
    IEnumerable<Workspace> GetWorkspacesByUserId(int userId);
    Workspace? GetWorkspaceById(int id);
    SaveResult DeleteWorkspace(Workspace workspace);
}