using Microsoft.Extensions.Logging;
using Relos.BusinessService.Interfaces;
using Relos.DataService.Interfaces;
using Relos.Models.DatabaseModels;
using Relos.Models.Dtos;
using Relos.Models.Enums;
using Relos.Models.Results;

namespace Relos.BusinessService.DatabaseServices;

public class UserOauthAccountBusinessService : IUserOauthAccountBusinessService
{
    private readonly IUserOauthAccountService _userOauthAccountService;
    private readonly ILogger<UserOauthAccountBusinessService> _logger;

    public UserOauthAccountBusinessService(IUserOauthAccountService userOauthAccountService,
        ILogger<UserOauthAccountBusinessService> logger)
    {
        _userOauthAccountService = userOauthAccountService;
        _logger = logger;
    }

    public UserOauthAccountDto? GetUserOauthAccountByUuid(string uuid)
    {
        UserOauthAccount? userOauthAccount = _userOauthAccountService.GetUserOauthAccountByUuid(uuid);

        if (userOauthAccount == null)
        {
            return null;
        }

        return new UserOauthAccountDto
        {
            AuthProvider = userOauthAccount.AuthProvider,
            Username = userOauthAccount.Username,
            AvatarUrl = userOauthAccount.Avatar
        };
    }
    
}