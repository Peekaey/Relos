using Relos.Models.Interfaces;

namespace Relos.Models.DatabaseModels;

public class User : ISystemArchivableAuditable
{
    public User()
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
    public UserOauthAccount UserOauthAccount { get; set; }
    //TODO Add User Profile
}