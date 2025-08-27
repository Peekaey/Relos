using Microsoft.Extensions.Logging;
using Relos.DataService.Interfaces;
using Relos.Models.DatabaseModels;

namespace Relos.DataService.Repositories;

public class WorkspaceSettingRepository : GenericRepository<WorkspaceSetting>, IWorkspaceSettingRepository
{
    private readonly ILogger<WorkspaceSettingRepository> _logger;
    public readonly DataContext _context;
    
    public WorkspaceSettingRepository(DataContext context, ILogger<WorkspaceSettingRepository> logger) : base(context)
    {
        _context = context;
        _logger = logger;
    }

}