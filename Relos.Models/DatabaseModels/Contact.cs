using Relos.Models.Interfaces;

namespace Relos.Models.DatabaseModels;

public class Contact : ISystemArchivableAuditable
{
    public Contact() {}

    public Contact(int userId)
    {
        CreatedDateTimeUtc = DateTime.UtcNow;
        LastUpdatedDateTimeUtc = DateTime.UtcNow;
        CreatedByUserId = userId;
        LastUpdatedByUserId = userId;
    }
    
    public int Id { get; set; }
    // ISystemArchivableAuditable
    // IBaseAuditable
    public DateTime LastUpdatedDateTimeUtc { get; set; }
    public DateTime CreatedDateTimeUtc { get; set; }
    // IBaseArchivable
    public bool IsArchived { get; set; }
    public DateTime? ArchivedDateTimeUtc { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PrimaryNumber { get; set; }
    public string CompanyName { get; set; }
    public string Address { get; set; }
    public int WorkspaceId { get; set; }
    public Workspace Workspace { get; set; }
    public int CreatedByUserId { get; set; }
    public User CreatedByUser { get; set; }
    public int LastUpdatedByUserId { get; set; }
    public User LastUpdatedByUser { get; set; }
}