using Microsoft.Extensions.Logging;
using Relos.DataService.Interfaces;
using Relos.Models.DatabaseModels;
using Relos.Models.Results;

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

    public IEnumerable<Contact> GetContactsByWorkspaceId(int workspaceId)
    {
        return _dataContext.Contacts.Where(c => c.WorkspaceId == workspaceId);
    }

    public SaveResult SaveNewContact(Contact contact)
    {
        using (var transaction = _dataContext.Database.BeginTransaction())
        {
            try
            {
                _dataContext.Contacts.Add(contact);
                _dataContext.SaveChanges();
                int newContactId = contact.Id;
                transaction.Commit();
                return SaveResult.AsCreated(newContactId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return SaveResult.AsFailure("Failed to create contact");
            }
        }
    }
    
    
}