using Microsoft.EntityFrameworkCore.Storage;

namespace Relos.DataService.Interfaces;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IUserOauthAccountRepository UserOauthAccountRepository { get; }
    IWorkspaceRepository WorkspaceRepository { get; }

    IDbContextTransaction BeginTransaction();
    Task<IDbContextTransaction> BeginTransactionAsync();
    void CommitTransaction();
    void RollbackTransaction();
    void SaveChanges();
}