using Microsoft.Extensions.Logging;
using Relos.DataService.Interfaces;
using Relos.Models.DatabaseModels;

namespace Relos.DataService.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ILogger<UserRepository> _logger;
    private readonly DataContext _context;
    
    public UserRepository(DataContext context, ILogger<UserRepository> logger) : base(context)
    {
        _context = context;
        _logger = logger;
    }

}