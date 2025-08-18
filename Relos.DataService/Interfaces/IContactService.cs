using Relos.Models.DatabaseModels;
using Relos.Models.Results;

namespace Relos.DataService.Interfaces;

public interface IContactService
{
    IEnumerable<Contact> GetContactsByWorkspaceId(int workspaceId);
    SaveResult SaveNewContact(Contact contact);
}