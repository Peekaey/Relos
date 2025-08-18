using System.ComponentModel.DataAnnotations;

namespace Relos.Models.RequestDtos;

public class CreateContactRequest
{
    [Required]
    [StringLength(100, ErrorMessage = "Name length can't be more than 100 characters.")]
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PrimaryNumber { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

}