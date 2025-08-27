using Microsoft.Extensions.Logging;
using Relos.DataService.Interfaces;

namespace Relos.DataService.Services;

public class CustomContactFieldService : ICustomContactFieldService
{
    private readonly ILogger<CustomContactFieldService> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly DataContext _dataContext;
    
    public CustomContactFieldService(ILogger<CustomContactFieldService> logger, IUnitOfWork unitOfWork, DataContext dataContext)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _dataContext = dataContext;
    }
    
}