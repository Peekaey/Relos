using Relos.Models.DatabaseModels;

namespace Relos.Models.Interfaces;

public interface IUserCreateAuditable
{
    public DateTime CreatedOnUtc { get; set; }
    public User CreatedByUser { get; set; }
    public int CreatedByUserId { get; set; }
}