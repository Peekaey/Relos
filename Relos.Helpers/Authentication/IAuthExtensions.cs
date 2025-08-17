namespace Relos.Helpers.Authentication;

public interface IAuthExtensions
{
    Task<string> GetIdentityClaimReloUserId();
    Task<int?> GetIdentityClaimReloUserIdAsInt();
    Task AddWorkSpaceIdToClaims(int workspaceId);
    Task<string> GetIdentityClaimWorkspaceId();
    Task<int?> GetIdentityClaimWorkspaceIdAsInt();
}