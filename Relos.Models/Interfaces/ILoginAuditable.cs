namespace Relos.Models.Interfaces;

public interface ILoginAuditable
{
    public DateTime LastLoginUtc { get; set; }
}