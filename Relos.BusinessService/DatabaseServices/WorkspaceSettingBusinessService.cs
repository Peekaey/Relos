using Microsoft.Extensions.Logging;
using Relos.BusinessService.Interfaces;
using Relos.DataService.Interfaces;

namespace Relos.BusinessService.DatabaseServices;

public class WorkspaceSettingBusinessService : IWorkspaceSettingBusinessService
{
    private readonly ILogger<WorkspaceSettingBusinessService> _logger;
    private readonly IWorkspaceSettingService _workspaceSettingService;

    public WorkspaceSettingBusinessService(ILogger<WorkspaceSettingBusinessService> logger, IWorkspaceSettingService workspaceSettingService)
    {
        _logger = logger;
        _workspaceSettingService = workspaceSettingService;
    }
    
}