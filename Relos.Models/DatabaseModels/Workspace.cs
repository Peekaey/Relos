using Relos.Models.Interfaces;

namespace Relos.Models.DatabaseModels;

public class Workspace : ISystemArchivableAuditable , IUserActionAuditable
{
    public Workspace()
    {
        CreatedDateTimeUtc = DateTime.UtcNow;
        LastUpdatedDateTimeUtc = DateTime.UtcNow;
    }
    
    public int Id { get; set; }
    public string WorkspaceName { get; set; }
    public string WorkspaceDescription { get; set; }
    public int WorkspaceOwnerId { get; set; }
    public User WorkspaceOwner { get; set; }
    // ISystemArchivableAuditable
    // IBaseAuditable
    public DateTime LastUpdatedDateTimeUtc { get; set; }
    public DateTime CreatedDateTimeUtc { get; set; }
    // IBaseArchivable
    public bool IsArchived { get; set; }
    public DateTime? ArchivedDateTimeUtc { get; set; }
    
    // IUserActionAuditable
    public int LastUpdatedByUserId { get; set; }
    public int CreatedByUserId { get; set; }
}