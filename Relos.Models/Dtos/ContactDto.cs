using Relos.Models.DatabaseModels;

namespace Relos.Models.Dtos;

public class ContactDto
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
    public User CreatedByUser { get; set; }
    public DateTime LastUpdatedOn { get; set; }
    public User LastUpdatedByUser { get; set; }
}