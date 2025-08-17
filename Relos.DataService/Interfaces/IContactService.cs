using Relos.Models.DatabaseModels;

namespace Relos.DataService.Interfaces;

public interface IContactService
{
    IEnumerable<Contact> GetContactsByWorkspaceId(int workspaceId);
}