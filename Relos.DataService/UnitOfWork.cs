using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Relos.DataService.Interfaces;

namespace Relos.DataService;

public class UnitOfWork : IUnitOfWork
{
    private readonly ILogger<UnitOfWork> _logger;
    private readonly DataContext _context;
    
    public IUserRepository UserRepository { get; }
    public IUserOauthAccountRepository UserOauthAccountRepository { get; }
    public IWorkspaceRepository WorkspaceRepository { get; }
    public IContactRepository ContactRepository { get; }

    public UnitOfWork(ILogger<UnitOfWork> logger, DataContext context, IUserRepository userRepository, IUserOauthAccountRepository userOauthAccountRepository,
        IWorkspaceRepository workspaceRepository, IContactRepository contactRepository)
    {
        _logger = logger;
        _context = context;
        UserRepository = userRepository;
        UserOauthAccountRepository = userOauthAccountRepository;
        WorkspaceRepository = workspaceRepository;
        ContactRepository = contactRepository;
    }
    
    public IDbContextTransaction BeginTransaction()
    {
        return _context.Database.BeginTransaction();
    }

    public Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return _context.Database.BeginTransactionAsync();
    }
    
    public void CommitTransaction()
    {
        _context.Database.CommitTransaction();
    }
    
    public void RollbackTransaction()
    {
        _context.Database.RollbackTransaction();
    }
    
    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}