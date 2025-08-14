using Relos.Models.DatabaseModels;
using Relos.Models.Results;

namespace Relos.DataService.Interfaces;

public interface IUserOauthAccountService
{
    UserOauthAccount? GetUserOauthAccountByUuid(string uuid);

}