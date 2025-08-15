using Microsoft.Extensions.Logging;
using Relos.DataService.Interfaces;
using Relos.Models.DatabaseModels;
using Relos.Models.Dtos;
using Relos.Models.Results;

namespace Relos.DataService.Services;

public class WorkspaceService : IWorkspaceService
{
    private readonly ILogger<WorkspaceService> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly DataContext _dataContext;

    public WorkspaceService(ILogger<WorkspaceService> logger, IUnitOfWork unitOfWork, DataContext dataContext)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _dataContext = dataContext;
    }
    
    public SaveResult SaveNewWorkspace(Workspace workspace)
    {
        using (var transaction = _dataContext.Database.BeginTransaction())
        {
            try
            {
                _dataContext.Workspaces.Add(workspace);
                _dataContext.SaveChanges();
                int newWorkspaceId = workspace.Id;
                transaction.Commit();
                return SaveResult.AsCreated(newWorkspaceId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return SaveResult.AsFailure(ex.Message);
            }
        }
    }

    public IEnumerable<Workspace> GetWorkspacesByUserId(int userId)
    {
        return _dataContext.Workspaces.Where(w => w.WorkspaceOwnerId == userId);
    }

    public Workspace? GetWorkspaceById(int id)
    {
        return _dataContext.Workspaces.FirstOrDefault(w => w.Id == id);
    }

    public SaveResult DeleteWorkspace(Workspace workspace)
    {
        using (var transaction = _dataContext.Database.BeginTransaction())
        {
            try
            {
                _dataContext.Workspaces.Remove(workspace);
                _dataContext.SaveChanges();
                transaction.Commit();
                return SaveResult.AsDeleted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return SaveResult.AsFailure(ex.Message);
            }
        }
    }
    
    
}