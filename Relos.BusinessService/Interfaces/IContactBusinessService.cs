using Relos.Models.Dtos;
using Relos.Models.Results;

namespace Relos.BusinessService.Interfaces;

public interface IContactBusinessService
{
    List<ContactDto> GetContactsByWorkspaceId(int workspaceId);
    SaveResult CreateNewContact(ContactDto contactDto, int workspaceId, int userId);
    ContactDto? GetContactDtoById(int contactId);
    SaveResult DeleteContact(int contactId);
}