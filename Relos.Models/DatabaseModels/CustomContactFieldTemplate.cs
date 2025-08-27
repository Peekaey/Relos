using System.ComponentModel.DataAnnotations;
using Relos.Models.Enums;
using Relos.Models.Interfaces;

namespace Relos.Models.DatabaseModels;

public class CustomContactFieldTemplate : IUserCreateAuditable, IUserArchiveAuditable, IUserLastUpdateAuditable
{


    public CustomContactFieldTemplate()
    {
        CreatedOnUtc = DateTime.UtcNow;
        LastUpdatedOnUtc = DateTime.UtcNow;
        IsArchived = false;
    }
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
    
    public int Id {get; set;}
    [Required]
    public CustomContactFieldType ContactFieldType {get; set;}
    [Required]
    public string FieldName { get; set; }
    [Required]
    public int WorkspaceId { get; set; }
    public Workspace Workspace { get; set; }
    
}