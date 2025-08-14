namespace Relos.Models.Interfaces;

public interface IUserActionAuditable : IBaseAuditable
{
    public int LastUpdatedByUserId { get; set; }
    public int CreatedByUserId { get; set; }
}