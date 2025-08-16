using Microsoft.Extensions.Logging;
using Relos.BusinessService.Interfaces;
using Relos.PageService.Interfaces;

namespace Relos.PageService;

public class ContactPageService : IContactPageService
{
    private readonly ILogger<ContactPageService> _logger;
    private readonly IContactBusinessService _contactBusinessService;

    public ContactPageService(ILogger<ContactPageService> logger, IContactBusinessService contactBusinessService)
    {
        _logger = logger;
        _contactBusinessService = contactBusinessService;
    }

}