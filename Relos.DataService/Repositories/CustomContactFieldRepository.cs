using Microsoft.Extensions.Logging;
using Relos.DataService.Interfaces;
using Relos.Models.DatabaseModels;

namespace Relos.DataService.Repositories;

public class CustomContactFieldRepository : GenericRepository<CustomContactField>, ICustomContactFieldRepository
{
    private readonly ILogger<CustomContactFieldRepository> _logger;
    private readonly DataContext _context;

    public CustomContactFieldRepository(ILogger<CustomContactFieldRepository> logger, DataContext context) : base(context)
    {
        _logger = logger;
        _context = context;
    }
    
}