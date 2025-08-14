using Relos.Models.Enums;
using Relos.Models.Interfaces;

namespace Relos.Models.DatabaseModels;

public class UserOauthAccount : IBaseAuditable
{
    public UserOauthAccount()
    {
        CreatedDateTimeUtc = DateTime.UtcNow;
        LastUpdatedDateTimeUtc = DateTime.UtcNow;
    }
    public int Id { get; set; }
    public int UserId { get; set; }
    public AuthProvider AuthProvider { get; set; }
    public int Uuid { get; set; }
    public string Username { get; set; }
    public string Avatar { get; set; }
    // IBaseAuditable
    public DateTime LastUpdatedDateTimeUtc { get; set; }
    public DateTime CreatedDateTimeUtc { get; set; }
    
    public User User { get; set; }
}