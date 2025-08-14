namespace Relos.Models.Interfaces;

public interface IBaseArchivable
{
    public bool IsArchived { get; set; }
    public DateTime? ArchivedDateTimeUtc { get; set; }
}