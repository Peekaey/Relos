using Microsoft.Extensions.Logging;
using Relos.DataService.Interfaces;

namespace Relos.DataService.Services;

public class ContactService : IContactService
{
    private readonly ILogger<ContactService> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly DataContext _dataContext;

    public ContactService(ILogger<ContactService> logger, IUnitOfWork unitOfWork, DataContext dataContext)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _dataContext = dataContext;
    }
    
    
}