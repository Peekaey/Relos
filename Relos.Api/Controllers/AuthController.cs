using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Relos.Helpers.Authentication;

namespace Relos.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthExtensions _authExtensions;

    public AuthController(ILogger<AuthController> logger, IAuthExtensions authExtensions)
    {
        _logger = logger;
        _authExtensions = authExtensions;
    }

    
    [HttpGet("github/signin")]
    [AllowAnonymous]
    public IActionResult SignInWithGithub()
    {
        var properties = new AuthenticationProperties
        {
            RedirectUri = "/workspaces",
            IsPersistent = true
        };
        
        return Challenge(properties, "Github");
    }
    
    [HttpGet("github/callback")]
    [AllowAnonymous]
    public IActionResult GitHubCallback()
    {
        return Redirect("/workspaces");
    }

    [HttpGet("logout")]
    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        _logger.LogInformation("User {Username} logged out", User.Identity?.Name);
        return Redirect("/login");
    }

    [HttpGet("status")]
    public IActionResult GetAuthStatus()
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            return Ok(new
            {
                IsAuthenticated = true,
                Username = User.FindFirst("UserName")?.Value,
                ReloUserId = User.FindFirst("ReloUserId")?.Value,
                Uuid = User.FindFirst("Uuid")?.Value,
                Issuer = User.FindFirst("Issuer")?.Value,
                AvatarUrl = User.FindFirst("Avatar_url")?.Value,
            });
        }

        return Ok(new { IsAuthenticated = false });
    }
    
    [HttpGet("set-workspace/{workspaceId}")]
    [Authorize]
    public async Task<IActionResult> SelectWorkspace(int workspaceId)
    {
        try
        {
            await _authExtensions.AddWorkSpaceIdToClaims(workspaceId);
            return Redirect("/inbox");
        }
        catch (Exception ex)
        {
            return Redirect("/error");
        }
    }
    

}