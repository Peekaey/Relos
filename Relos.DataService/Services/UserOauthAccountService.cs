using System.Data;
using Microsoft.EntityFrameworkCore;
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
        return _dataContext.UserOauthAccounts
            .FirstOrDefault(x => x.Uuid == uuid);
    }

    public int? GetUserIdByUuid(string uuid)
    {
        var userOauthAccount = _dataContext.UserOauthAccounts.FirstOrDefault(uoa => uoa.Uuid == uuid);
        return userOauthAccount?.UserId;
    }

    public SaveResult UpdateLastLoginDate(int userOauthAccountId)
    {
        UserOauthAccount? existingUserOauthAccount = _dataContext.UserOauthAccounts.FirstOrDefault(u => u.Id  == userOauthAccountId);
        if (existingUserOauthAccount == null)
        {
            return SaveResult.AsUpdated();
        }
        
        using (var transaction = _dataContext.Database.BeginTransaction())
        {
            try
            {
                existingUserOauthAccount.LastUpdatedBySystemUtc = DateTime.UtcNow;
                _dataContext.UserOauthAccounts.Update(existingUserOauthAccount);
                _dataContext.SaveChanges();
                transaction.Commit();
                return SaveResult.AsUpdated();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return SaveResult.AsFailure("Failed to update last login date");
            }
        }
    }
}