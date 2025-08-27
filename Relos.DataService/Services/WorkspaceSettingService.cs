using Microsoft.Extensions.Logging;
using Relos.DataService.Interfaces;

namespace Relos.DataService.Services;

public class WorkspaceSettingService : IWorkspaceSettingService
{
    private readonly ILogger<WorkspaceSettingService> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly DataContext _dataContext;
    
    public WorkspaceSettingService(ILogger<WorkspaceSettingService> logger, IUnitOfWork unitOfWork, DataContext dataContext)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _dataContext = dataContext;
    }
    
}