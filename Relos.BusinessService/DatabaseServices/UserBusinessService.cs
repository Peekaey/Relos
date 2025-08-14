using Microsoft.Extensions.Logging;
using Relos.BusinessService.Interfaces;
using Relos.DataService.Interfaces;
using Relos.DataService.Services;
using Relos.Models.DatabaseModels;
using Relos.Models.Dtos;
using Relos.Models.Enums;
using Relos.Models.Results;

namespace Relos.BusinessService.DatabaseServices;

public class UserBusinessService : IUserBusinessService
{
    private readonly ILogger<UserBusinessService> _logger;
    private readonly IUserService _userService;

    public UserBusinessService(ILogger<UserBusinessService> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }
    
    public SaveResult CreateAndSaveNewUser(AuthProvider provider, string uuid, string userName, string avatar)
    {
        User newUser = new User
        {
            UserOauthAccount = new UserOauthAccount
            {
                Uuid = uuid,
                Avatar = avatar,
                Username = userName
            }
        };
        return _userService.SaveNewUser(newUser);
    }
    
}