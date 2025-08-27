using System.ComponentModel.DataAnnotations;

namespace Relos.Models.RequestDtos;

public class CreateContactRequest
{
    [Required]
    [StringLength(100, ErrorMessage = "Name length can't be more than 100 characters.")]
    public string Name { get; set; }
    public string Email { get; set; }
    public string PrimaryNumber { get; set; }
    public string SecondaryNumber { get; set; }
    public string Position { get; set; }
    public string CompanyName { get; set; }
    public string Location { get; set; }

}