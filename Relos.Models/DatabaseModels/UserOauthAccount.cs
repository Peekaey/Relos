using System.ComponentModel.DataAnnotations;
using Relos.Models.Enums;
using Relos.Models.Interfaces;

namespace Relos.Models.DatabaseModels;

public class UserOauthAccount : ISystemCreateAuditable, ISystemLastUpdateAuditable, ISystemArchiveAuditable
{
    public UserOauthAccount()
    {
        CreatedBySystemUtc = DateTime.UtcNow;
        LastUpdatedBySystemUtc = DateTime.UtcNow;
        IsArchived = false;
    }
    [Required]
    public int Id { get; set; }
    [Required]
    public int UserId { get; set; }
    public User User { get; set; }
    [Required]
    public AuthProvider AuthProvider { get; set; }
    [Required]
    public string Uuid { get; set; }
    [Required]
    public string Username { get; set; }
    public string? Avatar { get; set; }
    // ISystemCreateAuditable
    [Required]
    public DateTime CreatedBySystemUtc { get; set; }
    // ISystemLastUpdateAuditable
    public DateTime LastUpdatedBySystemUtc { get; set; }
    // ISystemArchiveAuditable
    public bool? IsArchived { get; set; }
    public DateTime? ArchivedBySystemUtc { get; set; }
    
}