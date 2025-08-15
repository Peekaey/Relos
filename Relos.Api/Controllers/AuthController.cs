using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Relos.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
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
        return Redirect("/");
    }

    [HttpGet("status")]
    public IActionResult GetAuthStatus()
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            return Ok(new
            {
                IsAuthenticated = true,
                Username = User.Identity.Name,
                UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                AvatarUrl = User.FindFirst("avatar_url")?.Value,
                // Email = User.FindFirst(ClaimTypes.Email)?.Value
            });
        }

        return Ok(new { IsAuthenticated = false });
    }

}