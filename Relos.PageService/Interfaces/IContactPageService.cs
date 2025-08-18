using Relos.Models.Dtos;
using Relos.Models.Pages;
using Relos.Models.RequestDtos;

namespace Relos.PageService.Interfaces;

public interface IContactPageService
{
    Task<ContactsPage> GetContactsForWorkspaceAsync();
    Task<CreateContactSaveResult> CrateNewContactAsync(CreateContactRequest createContactRequest);
    Task<List<ContactDto>> GetContactsForRadzenGridAsync();
}