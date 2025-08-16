using Microsoft.Extensions.Logging;
using Relos.BusinessService.Interfaces;
using Relos.DataService.Interfaces;

namespace Relos.BusinessService.DatabaseServices;

public class ContactBusinessService : IContactBusinessService
{
    private readonly ILogger<ContactBusinessService> _logger;
    private readonly IContactService  _contactService;

    public ContactBusinessService(ILogger<ContactBusinessService> logger, IContactService contactService)
    {
        _logger = logger;
        _contactService = contactService;
    }
    
}