using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;

namespace Relos.Helpers.Authentication;

public class AuthenticationStateProviderExtensions : IAuthenticationStateProviderExtensions
{
    private readonly ILogger<AuthenticationStateProviderExtensions> _logger;
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AuthenticationStateProviderExtensions(ILogger<AuthenticationStateProviderExtensions> logger,
        AuthenticationStateProvider authenticationStateProvider)
    {
        _logger = logger;
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<string> GetIdentityClaimReloUserId()
    {
        string? reloUserId = _authenticationStateProvider.GetAuthenticationStateAsync().Result.User
            .Claims.FirstOrDefault(c => c.Type == "ReloUserId")?.Value;
        return reloUserId ?? string.Empty;
    }

    public async Task<int?> GetIdentityClaimReloUserIdAsInt()
    {
        string? userIdString = await GetIdentityClaimReloUserId();

        if (string.IsNullOrEmpty(userIdString))
        {
            return null;
        }
        
        return int.TryParse(userIdString, out int reloUserId) ? reloUserId : null;
        
    }
    
    
}