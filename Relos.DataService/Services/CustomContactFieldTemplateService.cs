using Microsoft.Extensions.Logging;
using Relos.DataService.Interfaces;

namespace Relos.DataService.Services;

public class CustomContactFieldTemplateService : ICustomContactFieldTemplateService
{
    private readonly ILogger<CustomContactFieldTemplateService> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly DataContext _dataContext;
    
    public CustomContactFieldTemplateService(ILogger<CustomContactFieldTemplateService> logger, IUnitOfWork unitOfWork, DataContext dataContext)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _dataContext = dataContext;
    }
    
}