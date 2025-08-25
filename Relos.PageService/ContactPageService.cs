using Microsoft.Extensions.Logging;
using Relos.BusinessService.Interfaces;
using Relos.Helpers.Authentication;
using Relos.Models.Dtos;
using Relos.Models.Pages;
using Relos.Models.RequestDtos;
using Relos.Models.Results;
using Relos.Models.ViewModels;
using Relos.PageService.Interfaces;

namespace Relos.PageService;

public class ContactPageService : IContactPageService
{
    private readonly ILogger<ContactPageService> _logger;
    private readonly IContactBusinessService _contactBusinessService;
    private readonly IAuthExtensions _authExtensions;

    public ContactPageService(ILogger<ContactPageService> logger, IContactBusinessService contactBusinessService, IAuthExtensions authExtensions)
    {
        _logger = logger;
        _contactBusinessService = contactBusinessService;
        _authExtensions = authExtensions;
    }

    public async Task<ContactsPage> GetContactsForWorkspaceAsync()
    {
        int? workspaceId =  await _authExtensions.GetIdentityClaimWorkspaceIdAsInt();
        
        if (workspaceId == null)
        {
            return ContactsPage.AsLoadFail("Unable to determine Workspace Id");
        }
        
        List<ContactDto> contacts = _contactBusinessService.GetContactsByWorkspaceId(workspaceId.Value);
        
        return ContactsPage.AsLoadSuccess(contacts);
    }

    public async Task<List<ContactDto>> GetContactsForRadzenGridAsync()
    {
        int? workspaceId =  await _authExtensions.GetIdentityClaimWorkspaceIdAsInt();
        
        if (workspaceId == null)
        {
            return new List<ContactDto>();
        }
        return  _contactBusinessService.GetContactsByWorkspaceId(workspaceId.Value);
    }

    public async Task<CreateContactSaveResult> CreateNewContactAsync(CreateContactRequest createContactRequest)
    {
        int? workspaceId = await _authExtensions.GetIdentityClaimWorkspaceIdAsInt();

        if (workspaceId == null)
        {
            return CreateContactSaveResult.AsFailure("Unable to determine Workspace Id");
        }

        int? userId = await _authExtensions.GetIdentityClaimReloUserIdAsInt();

        if (userId == null)
        {
            return CreateContactSaveResult.AsFailure("Unable to determine User Id");
        }

        ContactDto contactDto = new ContactDto
        {
            Name = createContactRequest.Name,
            Email = createContactRequest.Email,
            PrimaryNumber = createContactRequest.PrimaryNumber,
            CompanyName = createContactRequest.CompanyName,
            Address = createContactRequest.Address,
        };

        SaveResult saveResult = _contactBusinessService.CreateNewContact(contactDto, workspaceId.Value, userId.Value);

        if (!saveResult.IsSuccess)
        {
            return CreateContactSaveResult.AsFailure("Failed to create new contact");
        }
        
        return CreateContactSaveResult.AsCreated(contactDto);
    }

    public ContactVm? GetContactVmByIdAsync(int contactId)
    {
        ContactDto? contactDto =  _contactBusinessService.GetContactDtoById(contactId);

        if (contactDto == null)
        {
            return null;
        }

        return new ContactVm
        {
            Id = contactId,
            Name = contactDto.Name,
            Email = contactDto.Email,
            PrimaryNumber = contactDto.PrimaryNumber,
            CompanyName = contactDto.CompanyName,
            Address = contactDto.Address,
            CreatedByName = contactDto.CreatedByUser.UserOauthAccount.Username,
            CreatedOn = contactDto.CreatedOn,
            LastUpdatedByName = contactDto.LastUpdatedByUser.UserOauthAccount.Username,
            LastUpdatedOn = contactDto.LastUpdatedOn,
        };
    }

    public async Task<LoadResult<ContactVm?>> GetContactForView(int contactId)
    {
        ContactVm? contact = GetContactVmByIdAsync(contactId);
        
        if (contact == null)
        {
            return LoadResult<ContactVm?>.AsFailure("Contact not found");
        }
        
        return LoadResult<ContactVm?>.AsSuccess(contact);
    }

    public async Task<SaveResult> DeleteContactAsync(int contactId)
    {
        int? reloId = await _authExtensions.GetIdentityClaimReloUserIdAsInt();
        if (reloId == null)
        {
            return SaveResult.AsFailure("Unable to determine Relo Id");
        }
        
        SaveResult deleteResult = _contactBusinessService.DeleteContact(contactId);
        if (!deleteResult.WasDeleted)
        {
            return SaveResult.AsFailure("Failed to delete contact");
        }
        return SaveResult.AsDeleted();
    }
    

}