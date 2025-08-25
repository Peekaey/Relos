using Relos.Models.DatabaseModels;
using Relos.Models.Results;

namespace Relos.DataService.Interfaces;

public interface IContactService
{
    IEnumerable<Contact> GetContactsByWorkspaceId(int workspaceId);
    SaveResult SaveNewContact(Contact contact);
    Contact? GetContactForVmById(int id);
    Contact? GetContactById(int id);
    SaveResult DeleteContact(Contact contact);
}