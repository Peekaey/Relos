using System.Data;
using Microsoft.Extensions.Logging;
using Relos.DataService.Interfaces;
using Relos.Models.DatabaseModels;
using Relos.Models.Enums;
using Relos.Models.Results;

namespace Relos.DataService.Services;

public class UserOauthAccountService : IUserOauthAccountService
{
    private readonly ILogger<UserOauthAccountService> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly DataContext _dataContext;

    public UserOauthAccountService(ILogger<UserOauthAccountService> logger, IUnitOfWork unitOfWork, DataContext dataContext)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _dataContext = dataContext;
    }

    public UserOauthAccount? GetUserOauthAccountByUuid(string uuid)
    {
        return _dataContext.UserOauthAccounts.FirstOrDefault(x => x.Uuid == uuid);
    }
}