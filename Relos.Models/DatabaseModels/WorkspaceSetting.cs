using System.ComponentModel.DataAnnotations;
using Relos.Models.Interfaces;

namespace Relos.Models.DatabaseModels;

public class WorkspaceSetting : IUserCreateAuditable, IUserLastUpdateAuditable
{
    public WorkspaceSetting()
    {
        CreatedOnUtc = DateTime.UtcNow;
        LastUpdatedOnUtc = DateTime.UtcNow;

    }
    // IUserCreateAuditable
    public DateTime CreatedOnUtc { get; set; }
    public User CreatedByUser { get; set; }
    public int CreatedByUserId { get; set; }
    // IUserLastUpdateAuditable
    public DateTime LastUpdatedOnUtc { get; set; }
    public User LastUpdatedByUser { get; set; }
    public int LastUpdatedByUserId { get; set; }
    
    public int Id { get; set; }
    [Required]
    public int WorkspaceId { get; set; }
    public Workspace Workspace { get; set; }
    public bool EnableGeminiAiWidget { get; set; } = false;
    
    
}