using Microsoft.Extensions.Logging;
using Relos.DataService.Interfaces;
using Relos.Models.DatabaseModels;

namespace Relos.DataService.Repositories;

public class UserOauthAccountRepository : GenericRepository<UserOauthAccount>, IUserOauthAccountRepository
{
    private readonly ILogger<UserOauthAccountRepository> _logger;
    private readonly DataContext _context;
    
    public UserOauthAccountRepository(DataContext context, ILogger<UserOauthAccountRepository> logger) : base(context)
    {
        _context = context;
        _logger = logger;
    }
    
}