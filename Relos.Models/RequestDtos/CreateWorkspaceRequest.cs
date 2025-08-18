using System.ComponentModel.DataAnnotations;

namespace Relos.Models.RequestDtos;

public class CreateWorkspaceRequest
{
    [Required]
    [StringLength(50, ErrorMessage = "Name length can't be more than 50 characters.")]
    public string Name { get; set; } = string.Empty;

    [StringLength(200, ErrorMessage = "Description length can't be more than 200 characters.")]
    public string Description { get; set; } = string.Empty;
}