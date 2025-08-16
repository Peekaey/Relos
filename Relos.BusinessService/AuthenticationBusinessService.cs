using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Relos.BusinessService.Interfaces;
using Relos.DataService.Interfaces;
using Relos.Models.DatabaseModels;
using Relos.Models.Dtos;
using Relos.Models.Enums;
using Relos.Models.Results;

namespace Relos.BusinessService;

public class AuthenticationBusinessService : IAuthenticationBusinessService
{
    private readonly IUserOauthAccountBusinessService _userOauthAccountBusinessService;
    private readonly IUserBusinessService _userBusinessService;
    private readonly ILogger<AuthenticationBusinessService> _logger;


    public AuthenticationBusinessService(IUserOauthAccountBusinessService userOauthAccountBusinessService,
        IUserBusinessService userBusinessService, ILogger<AuthenticationBusinessService> logger)
    {
        _userOauthAccountBusinessService = userOauthAccountBusinessService;
        _userBusinessService = userBusinessService;
        _logger = logger;
    }
    
    public AuthenticateResult ProcessOauthLogin(AuthProvider provider, string uuid, string userName, string avatar)
    {
        UserOauthAccountDto? userOauthAccountDto = _userOauthAccountBusinessService.GetUserOauthAccountByUuid(uuid);

        if (userOauthAccountDto != null)
        {
            return AuthenticateResult.AsSuccess(userOauthAccountDto.Id);
        }
        SaveResult saveNewUserResult = _userBusinessService.CreateAndSaveNewUser(provider, uuid, userName, avatar);

        if (!saveNewUserResult.IsSuccess)
        {
            return AuthenticateResult.AsFailure("Failed to create new user");
        }
        return AuthenticateResult.AsSuccess(saveNewUserResult.CreatedIdValue);
    }
    
    
    
}