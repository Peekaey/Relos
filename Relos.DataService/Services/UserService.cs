using Microsoft.Extensions.Logging;
using Relos.DataService.Interfaces;
using Relos.Models.DatabaseModels;
using Relos.Models.Results;

namespace Relos.DataService.Services;

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly DataContext _dataContext;

    public UserService(ILogger<UserService> logger, IUnitOfWork unitOfWork, DataContext dataContext)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _dataContext = dataContext;
    }
    
    public SaveResult SaveNewUser(User user)
    {
        using (var transaction = _dataContext.Database.BeginTransaction())
        {
            try
            {
                _dataContext.Users.Add(user);
                _dataContext.SaveChanges();
                transaction.Commit();
                return SaveResult.AsCreated();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return SaveResult.AsFailure(ex.Message);
            }
        }
    }
    
}