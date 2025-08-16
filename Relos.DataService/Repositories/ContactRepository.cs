using Microsoft.Extensions.Logging;
using Relos.DataService.Interfaces;
using Relos.Models.DatabaseModels;

namespace Relos.DataService.Repositories;

public class ContactRepository : GenericRepository<Contact>, IContactRepository
{
    private readonly ILogger<ContactRepository> _logger;
    private readonly DataContext _context;

    public ContactRepository(ILogger<ContactRepository> logger, DataContext context) : base(context)
    {
        _logger = logger;
        _context = context;
    }
    
    
    
    
}