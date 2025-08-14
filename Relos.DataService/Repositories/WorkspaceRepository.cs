using Microsoft.Extensions.Logging;
using Relos.DataService.Interfaces;
using Relos.Models.DatabaseModels;

namespace Relos.DataService.Repositories;

public class WorkspaceRepository : GenericRepository<Workspace>, IWorkspaceRepository
{
    private readonly ILogger<WorkspaceRepository> _logger;
    private readonly DataContext _context;
    
    public WorkspaceRepository(DataContext context, ILogger<WorkspaceRepository> logger) : base(context)
    {
        _context = context;
        _logger = logger;
    }
    
}