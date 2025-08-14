namespace Relos.Models.Interfaces;

public interface IBaseAuditable
{
    public DateTime LastUpdatedDateTimeUtc { get; set; }
    public DateTime CreatedDateTimeUtc { get; set; }
}