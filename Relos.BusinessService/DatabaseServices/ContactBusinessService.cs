using Microsoft.Extensions.Logging;
using Relos.BusinessService.Interfaces;
using Relos.DataService.Interfaces;
using Relos.Helpers.Extensions;
using Relos.Models.DatabaseModels;
using Relos.Models.Dtos;
using Relos.Models.Results;

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
            SecondaryNumber = c.SecondaryNumber,
            CompanyName = c.CompanyName,
            Position = c.Position,
            Location = c.Location,
        }).ToList();
        
        return contactDtos;
    }

    public SaveResult CreateNewContact(ContactDto contactDto, int workspaceId, int userId)
    {
        Contact contact = new Contact
        {
            Name = contactDto.Name,
            Email = contactDto.Email,
            PrimaryNumber = contactDto.PrimaryNumber,
            SecondaryNumber = contactDto.SecondaryNumber,
            CompanyName = contactDto.CompanyName,
            Position = contactDto.Position,
            Location = contactDto.Location,
            CreatedByUserId = userId,
            WorkspaceId = workspaceId,
            LastUpdatedByUserId = userId,
        };

        return _contactService.SaveNewContact(contact);
    }

    public ContactDto? GetContactDtoById(int contactId)
    {
        Contact? contact = _contactService.GetContactForVmById(contactId);

        if (contact == null)
        {
            return null;
        }

        return new ContactDto
        {
            Id = contact.Id,
            Name = contact.Name,
            Email = contact.Email,
            PrimaryNumber = contact.PrimaryNumber,
            SecondaryNumber = contact.SecondaryNumber,
            CompanyName = contact.CompanyName,
            Position = contact.Position,
            Location = contact.Location,
            CreatedByUser = contact.CreatedByUser,
            CreatedOn = contact.CreatedOnUtc,
            LastUpdatedByUser = contact.LastUpdatedByUser,
            LastUpdatedOn = contact.LastUpdatedOnUtc,
        };
    }

    public SaveResult DeleteContact(int contactId)
    {
        Contact? contact = _contactService.GetContactForVmById(contactId);
        bool deleteSuccess = false;
        if (contact == null)
        {
            return SaveResult.AsDeleted();
        }

        SaveResult deleteResult = _contactService.DeleteContact(contact);

        if (deleteResult.WasDeleted == false)
        {
            return SaveResult.AsFailure("Failed to delete contact");
        }
        
        return SaveResult.AsDeleted();

    }
    
}