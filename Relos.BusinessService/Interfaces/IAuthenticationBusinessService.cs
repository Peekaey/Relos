using Relos.Models.Enums;
using Relos.Models.Results;

namespace Relos.BusinessService.Interfaces;

public interface IAuthenticationBusinessService
{
    AuthenticateResult ProcessOauthLogin(AuthProvider provider, string uuid, string userName, string avatar);
}