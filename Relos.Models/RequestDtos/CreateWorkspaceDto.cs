namespace Relos.Models.RequestDtos;

public class CreateWorkspaceDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int OwnerId { get; set; }
}