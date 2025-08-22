using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext?.User.Identity?.IsAuthenticated != true)
        {
            throw new InvalidOperationException("User must be authenticated to add claims");
        }
        
        var identity = httpContext.User.Identity as ClaimsIdentity;
        if (identity == null)
        {
            throw new InvalidOperationException("User identity is not a ClaimsIdentity");
        }
        
        // Remove any existing claims before proceeding (incase they change workspace
        var existingClaim = identity.FindFirst("WorkspaceId");
        if (existingClaim != null)
        {
            identity.RemoveClaim(existingClaim);
        }
        
        identity.AddClaim(new Claim("WorkspaceId", workspaceId.ToString()));
        
        // Re-sign in the user with updated claims
        var newPrincipal = new ClaimsPrincipal(identity);
        await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, newPrincipal);
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

    public async Task<string> GetIdentifyClaimAvatar()
    {
        string? claimAvatar = _authenticationStateProvider.GetAuthenticationStateAsync().Result.User.Claims.FirstOrDefault(c => c.Type == "Avatar_url")?.Value;
        return claimAvatar ?? string.Empty;
    }
    
}