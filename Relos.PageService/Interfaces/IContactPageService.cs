using Relos.Models.Pages;

namespace Relos.PageService.Interfaces;

public interface IContactPageService
{
    Task<ContactsPage> GetContactsForWorkspace();
}