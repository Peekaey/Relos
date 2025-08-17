using Microsoft.EntityFrameworkCore;
using Relos.Models.DatabaseModels;

namespace Relos.DataService;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOauthAccount> UserOauthAccounts { get; set; }
    public DbSet<Workspace> Workspaces { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    
}