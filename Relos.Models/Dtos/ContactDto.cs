namespace Relos.Models.Dtos;

public class ContactDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PrimaryNumber { get; set; }
    public string CompanyName { get; set; }
    public string Address { get; set; }
    public int CreatedByUserId { get; set; }
    
}