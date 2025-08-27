using Microsoft.Extensions.Logging;
using Relos.DataService.Interfaces;
using Relos.Models.DatabaseModels;

namespace Relos.DataService.Repositories;

public class CustomContactFieldTemplateRepository : GenericRepository<CustomContactFieldTemplate> ,ICustomContactFieldTemplateRepository
{
    private readonly ILogger<CustomContactFieldTemplateRepository> _logger;
    private readonly DataContext _context;
    
    public CustomContactFieldTemplateRepository(DataContext context, ILogger<CustomContactFieldTemplateRepository> logger) : base(context)
    {
        _context = context;
        _logger = logger;
    }
    
}