using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Relos.Helpers.Authentication;

public class AuthExtensions : IAuthExtensions
{
    private readonly ILogger<AuthExtensions> _logger;
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthExtensions(ILogger<AuthExtensions> logger,
        AuthenticationStateProvider authenticationStateProvider, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _authenticationStateProvider = authenticationStateProvider;
        _httpContextAccessor = httpContextAccessor;
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

    public async Task AddWorkSpaceIdToClaims(int workspaceId)
    {
        var existingClaimsIdentity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
        existingClaimsIdentity.AddClaim(new Claim("WorkspaceId", workspaceId.ToString()));
    }

    public async Task<string> GetIdentityClaimWorkspaceId()
    {
        string? workspaceId = _authenticationStateProvider.GetAuthenticationStateAsync().Result.User
            .Claims.FirstOrDefault(c => c.Type == "WorkspaceId")?.Value;
        return workspaceId ?? string.Empty;
    }

    public async Task<int?> GetIdentityClaimWorkspaceIdAsInt()
    {
        string? workspaceIdString = await GetIdentityClaimWorkspaceId();

        if (string.IsNullOrEmpty(workspaceIdString))
        {
            return null;
        }
        return int.TryParse(workspaceIdString, out int workspaceId) ? workspaceId : null;
    }
    
}