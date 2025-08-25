namespace Relos.Models.ViewModels;

public class ContactVm
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PrimaryNumber { get; set; }
    public string CompanyName { get; set; }
    public string Address { get; set; }
    public DateTime CreatedOn { get; set; }
    public string CreatedByName { get; set; }
    public DateTime LastUpdatedOn { get; set; }
    public string LastUpdatedByName { get; set; }
    
}