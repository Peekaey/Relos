using Microsoft.Extensions.Logging;
using Relos.BusinessService.Interfaces;
using Relos.DataService.Interfaces;

namespace Relos.BusinessService.DatabaseServices;

public class CustomContactFieldTemplateBusinessService : ICustomContactFieldTemplateBusinessService
{
    private readonly ILogger<CustomContactFieldTemplateBusinessService> _logger;
    private readonly ICustomContactFieldTemplateService _customContactFieldTemplateService;
    
    public CustomContactFieldTemplateBusinessService(ILogger<CustomContactFieldTemplateBusinessService> logger, ICustomContactFieldTemplateService customContactFieldTemplateService)
    {
        _logger = logger;
        _customContactFieldTemplateService = customContactFieldTemplateService;
    }
    
    
}