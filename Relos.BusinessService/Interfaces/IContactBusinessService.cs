using Relos.Models.Dtos;

namespace Relos.BusinessService.Interfaces;

public interface IContactBusinessService
{
    List<ContactDto> GetContactsByWorkspaceId(int workspaceId);
}