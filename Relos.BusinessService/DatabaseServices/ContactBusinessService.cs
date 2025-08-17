using Microsoft.Extensions.Logging;
using Relos.BusinessService.Interfaces;
using Relos.DataService.Interfaces;
using Relos.Models.DatabaseModels;
using Relos.Models.Dtos;

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

    public List<ContactDto> GetContactsByWorkspaceId(int workspaceId)
    {
        List<Contact> contacts = _contactService.GetContactsByWorkspaceId(workspaceId).ToList();

        List<ContactDto> contactDtos = contacts.Select(c => new ContactDto
        {
            Id = c.Id,
            Name = c.Name,
            Email = c.Email,
            PrimaryNumber = c.PrimaryNumber,
            CompanyName = c.CompanyName,
            Address = c.Address,
        }).ToList();
        
        return contactDtos;

    }
    
}