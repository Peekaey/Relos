using System.ComponentModel.DataAnnotations;
using Relos.Models.Interfaces;

namespace Relos.Models.DatabaseModels;

public class Contact : IUserCreateAuditable, IUserLastUpdateAuditable, IUserArchiveAuditable
{

    public Contact()
    {
        CreatedOnUtc = DateTime.UtcNow;
        LastUpdatedOnUtc = DateTime.UtcNow;
        IsArchived = false;
    }
    
    public int Id { get; set; }
    // IUserCreateAuditable
    [Required]
    public DateTime CreatedOnUtc { get; set; }
    public User CreatedByUser { get; set; }
    [Required]
    public int CreatedByUserId { get; set; }
    
    // IUserLastUpdateAuditable
    [Required]
    public DateTime LastUpdatedOnUtc { get; set; }
    public User LastUpdatedByUser { get; set; }
    [Required]
    public int LastUpdatedByUserId { get; set; }
    // IUserArchiveAuditable
    public bool? IsArchived { get; set; }
    public DateTime? ArchivedOnUtc { get; set; }
    public User? ArchivedByUser { get; set; }
    public int? ArchivedByUserId { get; set; }
    [Required]
    public string Name { get; set; }
    public string? Email { get; set; }
    public string? PrimaryNumber { get; set; }
    public string? SecondaryNumber { get; set; }
    public string? Position { get; set; }
    [Required]
    public string CompanyName { get; set; }
    public string? Location { get; set; }
    [Required]
    public int WorkspaceId { get; set; }
    public Workspace Workspace { get; set; }
    
    public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
}