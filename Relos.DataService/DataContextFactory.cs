using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Relos.DataService;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<DataContext> optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        // TODO Move to getting connection string from json config file
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=relos;Username=relos;Password=relos;"); 
        return new DataContext(optionsBuilder.Options);
    }
}