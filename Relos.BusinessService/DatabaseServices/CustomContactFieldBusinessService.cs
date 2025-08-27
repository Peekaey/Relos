using Microsoft.Extensions.Logging;
using Relos.BusinessService.Interfaces;
using Relos.DataService.Interfaces;

namespace Relos.BusinessService.DatabaseServices;

public class CustomContactFieldBusinessService : ICustomContactFieldBusinessService
{
    private readonly ILogger<CustomContactFieldBusinessService> _logger;
    private readonly ICustomContactFieldService _customContactFieldService;
    
    public CustomContactFieldBusinessService(ILogger<CustomContactFieldBusinessService> logger, ICustomContactFieldService customContactFieldService)
    {
        _logger = logger;
        _customContactFieldService = customContactFieldService;
    }
    
}