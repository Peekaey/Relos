using Relos.Models.Dtos;
using Relos.Models.Results;

namespace Relos.Models.RequestDtos;

public class CreateContactSaveResult : SaveResult
{
    public ContactDto? ContactDto { get; set; }

    protected CreateContactSaveResult(bool isSuccess, string errorMessage = "", bool wasCreated = false,
        bool wasUpdated = false,
        ContactDto? contactDto = null) : base(isSuccess, errorMessage, wasCreated, wasUpdated)
    {
        ContactDto = contactDto;
    }
    
    // Factory methods for creating instances
    public static CreateContactSaveResult AsCreated(ContactDto contactDto)
    {
        return new(true, wasCreated: true, contactDto: contactDto);
    }

    public static CreateContactSaveResult AsUpdated(ContactDto contactDto)
    {
        return new(true, wasUpdated: true, contactDto: contactDto);
    }

    public static new CreateContactSaveResult AsFailure(string errorMessage)
    {
        return new (false, errorMessage: errorMessage);
    }
    
    public bool HasContact => IsSuccess && ContactDto != null;

    public bool TryGetContact(out ContactDto? contact)
    {
        contact = IsSuccess ? ContactDto : null;
        return contact != null;
    }

    protected override void OnSuccess()
    {
    }

    protected override void OnFailure()
    {
        
    }
}