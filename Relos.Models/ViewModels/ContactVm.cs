namespace Relos.Models.ViewModels;

public class ContactVm
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PrimaryNumber { get; set; }
    public string SecondaryNumber { get; set; }
    public string Position { get; set; }
    public string CompanyName { get; set; }
    public string Location { get; set; }
    public DateTime CreatedOn { get; set; }
    public string CreatedByName { get; set; }
    public DateTime LastUpdatedOn { get; set; }
    public string LastUpdatedByName { get; set; }
    
}