namespace Relos.Models.Dtos;

public class WorkspaceDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int OwnerId { get; set; }
    public DateTime CreatedOn { get; set; }
}