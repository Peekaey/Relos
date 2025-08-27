namespace Relos.Models.Interfaces;

public interface ISystemLastUpdateAuditable
{
    public DateTime LastUpdatedBySystemUtc { get; set; }
}