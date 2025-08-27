using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Relos.Models.Interfaces;

namespace Relos.Models.DatabaseModels;

public class User : ISystemCreateAuditable , ISystemArchiveAuditable, ISystemLastUpdateAuditable, ILoginAuditable
{
    public User()
    {
        CreatedBySystemUtc = DateTime.UtcNow;
        LastUpdatedBySystemUtc = DateTime.UtcNow;
        IsArchived = false;
    }
    public int Id { get; set; }
    // ISystemCreateAuditable
    [Required]
    public DateTime CreatedBySystemUtc { get; set; } 
    // ISystemUpdateAuditable
    [Required]
    public DateTime LastUpdatedBySystemUtc { get; set; }
    // ISystemArchiveAuditable
    public bool? IsArchived { get; set; }
    public DateTime? ArchivedBySystemUtc { get; set; }
    // ILoginAuditable
    [Required]
    public DateTime LastLoginUtc { get; set; }
    public UserOauthAccount UserOauthAccount { get; set; }

}