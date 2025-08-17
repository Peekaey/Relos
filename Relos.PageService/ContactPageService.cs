using Microsoft.Extensions.Logging;
using Relos.BusinessService.Interfaces;
using Relos.Helpers.Authentication;
using Relos.Models.Dtos;
using Relos.Models.Pages;
using Relos.PageService.Interfaces;

namespace Relos.PageService;

public class ContactPageService : IContactPageService
{
    private readonly ILogger<ContactPageService> _logger;
    private readonly IContactBusinessService _contactBusinessService;
    private readonly IAuthExtensions _authExtensions;

    public ContactPageService(ILogger<ContactPageService> logger, IContactBusinessService contactBusinessService)
    {
        _logger = logger;
        _contactBusinessService = contactBusinessService;
    }

    public async Task<ContactsPage> GetContactsForWorkspace()
    {
        int? workspaceId =  await _authExtensions.GetIdentityClaimWorkspaceIdAsInt();
        
        if (workspaceId == null)
        {
            return ContactsPage.AsLoadFail("Unable to determine Workspace Id");
        }
        
        List<ContactDto> contacts = _contactBusinessService.GetContactsByWorkspaceId(workspaceId.Value);
        
        return ContactsPage.AsLoadSuccess(contacts);
    }

}