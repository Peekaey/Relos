using Relos.Models.Dtos;

namespace Relos.Models.Pages;

public class ContactsPage
{
    public bool LoadSuccess { get; set; }
    public List<ContactDto> Contacts { get; set; }
    public string? ErrorMessage { get; set; }
    
    public ContactsPage(bool loadSuccess, List<ContactDto> contacts, string? errorMessage = "")
    {
        LoadSuccess = loadSuccess;
        Contacts = contacts;
    }
    
    public static ContactsPage AsLoadSuccess(List<ContactDto> contacts)
    {
        return new ContactsPage(true, contacts);
    }
    
    public static ContactsPage AsLoadFail(string errorMessage)
    {
        return new ContactsPage(false, new List<ContactDto>(), errorMessage);
    }
}