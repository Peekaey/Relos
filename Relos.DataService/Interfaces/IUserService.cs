using Relos.Models.DatabaseModels;
using Relos.Models.Results;

namespace Relos.DataService.Interfaces;

public interface IUserService
{
    SaveResult SaveNewUser(User user);
    SaveResult UpdateLastLoginDate(int userId, DateTime lastLoginDate);
}