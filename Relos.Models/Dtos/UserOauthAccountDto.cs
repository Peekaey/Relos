using Relos.Models.Enums;

namespace Relos.Models.Dtos;

public class UserOauthAccountDto
{
    public int Id { get; set; }
    public string Username { get; set; } = "";
    public string? AvatarUrl { get; set; }
    public AuthProvider AuthProvider { get; set; }
}