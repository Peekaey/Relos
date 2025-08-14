using Microsoft.Extensions.Logging;
using Relos.DataService.Interfaces;
using Relos.DataService.Services;
using Relos.Models.Enums;
using Relos.Models.Results;

namespace Relos.BusinessService.Interfaces;

public interface IUserBusinessService
{
    SaveResult CreateAndSaveNewUser(AuthProvider provider, string uuid, string userName, string avatar);
}