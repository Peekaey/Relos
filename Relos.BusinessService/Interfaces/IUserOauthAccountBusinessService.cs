using Microsoft.Extensions.Logging;
using Relos.DataService.Interfaces;
using Relos.Models.DatabaseModels;
using Relos.Models.Dtos;
using Relos.Models.Results;

namespace Relos.BusinessService.Interfaces;

public interface IUserOauthAccountBusinessService
{
    UserOauthAccountDto? GetUserOauthAccountByUuid(string uuid);
    SaveResult UpdateLastLoginDate(int userOauthAccountId);
}