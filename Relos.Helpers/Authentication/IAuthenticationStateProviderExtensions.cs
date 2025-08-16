namespace Relos.Helpers.Authentication;

public interface IAuthenticationStateProviderExtensions
{
    Task<string> GetIdentityClaimReloUserId();
    Task<int?> GetIdentityClaimReloUserIdAsInt();
}