using Relos.Models.DatabaseModels;

namespace Relos.Models.Interfaces;

public interface IUserArchiveAuditable
{
    public bool? IsArchived { get; set; }
    public DateTime? ArchivedOnUtc { get; set; }
    public User? ArchivedByUser { get; set; }
    public int? ArchivedByUserId { get; set; }
}