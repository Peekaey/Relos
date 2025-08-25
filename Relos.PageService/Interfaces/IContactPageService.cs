using Relos.Models.Dtos;
using Relos.Models.Pages;
using Relos.Models.RequestDtos;
using Relos.Models.Results;
using Relos.Models.ViewModels;

namespace Relos.PageService.Interfaces;

public interface IContactPageService
{
    Task<ContactsPage> GetContactsForWorkspaceAsync();
    Task<CreateContactSaveResult> CreateNewContactAsync(CreateContactRequest createContactRequest);
    Task<List<ContactDto>> GetContactsForRadzenGridAsync();
     ContactVm? GetContactVmByIdAsync(int contactId);
     Task<LoadResult<ContactVm?>> GetContactForView(int contactId);
     Task<SaveResult> DeleteContactAsync(int contactId);
}