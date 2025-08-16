using Relos.Models.Interfaces;

namespace Relos.Models.DatabaseModels;

public class Contact : ISystemArchivableAuditable
{
    public Contact()
    {
        CreatedDateTimeUtc = DateTime.UtcNow;
        LastUpdatedDateTimeUtc = DateTime.UtcNow;
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
    
}