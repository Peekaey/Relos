namespace Relos.Models.Interfaces;

public interface ISystemCreateAuditable
{
    public DateTime CreatedBySystemUtc { get; set; }
}