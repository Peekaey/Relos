using Relos.Models.DatabaseModels;

namespace Relos.Models.Interfaces;

public interface ISystemArchiveAuditable
{
    public bool? IsArchived { get; set; }
    public DateTime? ArchivedBySystemUtc { get; set; }
}