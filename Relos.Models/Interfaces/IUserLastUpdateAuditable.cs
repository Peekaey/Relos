using Relos.Models.DatabaseModels;

namespace Relos.Models.Interfaces;

public interface IUserLastUpdateAuditable
{
    public DateTime LastUpdatedOnUtc { get; set; }
    public User LastUpdatedByUser { get; set; }
    public int LastUpdatedByUserId { get; set; }
}