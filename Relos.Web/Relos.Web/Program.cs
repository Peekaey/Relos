using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MudBlazor.Services;
using Relos.DataService;
using Relos.DataService.Interfaces;
using Relos.DataService.Repositories;
using Relos.Web.Components;

namespace Relos.Web;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Starting Relos....");
        var builder = WebApplication.CreateBuilder(args);
        
        string rootPath = AppContext.BaseDirectory;
        string rootProjectDirectory = Directory.GetParent(rootPath)?.Parent?.Parent?.Parent?.Parent?.Parent?.FullName ?? rootPath;
        string certPfx = ValidateCertificates(rootPath, rootProjectDirectory);

        // ConfigureKestrel(builder, certPfx);
        ConfigureOauth(builder);
        ConfigureServices(builder);
        ConfigureDatabaseServices(builder);
        ConfigureApplicationServices(builder);
        ConfigureLogging(builder);
        
        var app = builder.Build();
        InitialiseDatabase(app);
        ConfigureWebApplication(app);
        app.Run();
    }

    private static void ConfigureWebApplication(WebApplication app)
    {
        // Enabled so that @Assets[""] can fingerprint the files.
        // https://mudblazor.com/getting-started/installation#manual-install-add-references
        app.MapStaticAssets();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseAntiforgery();

        app.MapStaticAssets();
        app.MapControllers();
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode()
            .AddInteractiveWebAssemblyRenderMode()
            .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);
    }

    private static void ConfigureServices(WebApplicationBuilder builder)
    {
        // Add services to the container.
        builder.Services.AddRazorComponents().AddInteractiveServerComponents().AddInteractiveWebAssemblyComponents();
        builder.Services.AddMudServices();

        builder.Services.AddControllers();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddHttpClient();
    }

    private static void ConfigureApplicationServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserOauthAccountRepository, UserOauthAccountRepository>();
        builder.Services.AddScoped<IWorkspaceRepository, WorkspaceRepository>();
        builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

    }

    private static void ConfigureLogging(WebApplicationBuilder builder)
    {
        builder.Services.AddLogging(logOptions =>
        {
            logOptions.ClearProviders();
            logOptions.AddConsole();
            logOptions.AddDebug();
            logOptions.SetMinimumLevel(LogLevel.Trace);
        });
    }
    private static void ConfigureKestrel(WebApplicationBuilder builder, string certPfx)
    {
        // Configure Ports and HTTPS Cert
        builder.WebHost.ConfigureKestrel(options =>
        {
            options.ListenAnyIP(5037);
            options.ListenAnyIP(7265, listenOpts =>
                listenOpts.UseHttps(certPfx, ""));
        });
    }
    
    private static void ConfigureDatabaseServices(WebApplicationBuilder builder)
    {
        string postgresConnectionString = builder.Configuration["DatabaseConnectionString"];
        
        if (string.IsNullOrEmpty(postgresConnectionString))
        {
            Console.WriteLine("DatabaseConnectionString is missing");
            throw new ArgumentException("Postgres connection string is not configured.");
        }
        
        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseNpgsql(postgresConnectionString, npgsqlOptions =>
            {
                npgsqlOptions.MigrationsAssembly("Relos.DataService");
            });
            options.UseNpgsql(postgresConnectionString)
                .LogTo(Console.WriteLine, LogLevel.Information);
        });
    }
    
    private static void InitialiseDatabase(IHost host)
    {
        using (IServiceScope scope = host.Services.CreateScope())
        {
            try
            {
                DataContext dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
                if (!dbContext.Database.CanConnect())
                {
                    throw new ApplicationException("Unable to connect to database.");
                }

                dbContext.Database.Migrate();
                Console.WriteLine("Database initialisation complete.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred while initialising database: " + e.Message);
                throw;
            }
        }
    }

    private static void ConfigureOauth(WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "Github";
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.LoginPath = "/login";
                options.LogoutPath = "/api/v1/auth/logout";
                options.AccessDeniedPath = "/access-denied";
                options.ExpireTimeSpan = TimeSpan.FromDays(7);
                options.SlidingExpiration = true;
                options.Cookie.Name = "relos-cookie";
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.Lax;
            })

            .AddOAuth("Github", options =>
            {
                IConfigurationSection ghSection = builder.Configuration.GetSection("Authentication:Github");


                options.ClientId = ghSection["ClientId"];
                options.ClientSecret = ghSection["ClientSecret"];


                options.AuthorizationEndpoint = "https://github.com/login/oauth/authorize";
                options.TokenEndpoint = "https://github.com/login/oauth/access_token";
                options.UserInformationEndpoint = "https://api.github.com/user";

                options.CallbackPath = "/api/v1/auth/github/callback";


                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

                // Scopes
                options.Scope.Add("read:user");

                // Claim mapping
                options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
                options.ClaimActions.MapJsonKey(ClaimTypes.Name, "login");
                options.ClaimActions.MapJsonKey("avatar_url", "avatar_url");
                // options.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");

                options.Events = new OAuthEvents
                {
                    OnCreatingTicket = async context =>
                    {
                        var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);

                        var response = await context.Backchannel.SendAsync(request,
                            HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
                        response.EnsureSuccessStatusCode();

                        var json = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
                        context.RunClaimActions(json.RootElement);
                    },
                    OnTicketReceived = context =>
                    {
                        
                        string githubId = context.Principal.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
                        string login = context.Principal.FindFirst(ClaimTypes.Name)?.Value ?? "";
                        string avatarUrl = context.Principal.FindFirst("avatar_url")?.Value ?? "";

                        var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
                        logger.LogInformation("User {Login} (ID: {GitHubId}) authenticated successfully", login, githubId);
                        
                        return Task.CompletedTask;
                    }
                };
            });
    }

    private static string ValidateCertificates(string rootPath, string rootProjectDirectory)
    {
        // Validate HTTPS Cert
        string certPath = Path.Combine(rootProjectDirectory, "Certs");
        
        if (!Directory.Exists(certPath))
        {
            Console.WriteLine($"Certs directory not found at {certPath}. Please ensure the directory exists and contains the localhost.pfx file.");
            throw new DirectoryNotFoundException($"Certs directory not found at {certPath}. Please ensure the directory exists and contains the localhost.pfx file.");
        }
        
        string certPfx = Path.Combine(certPath, "localhost.pfx");
        if (!File.Exists(certPfx))
        {
            Console.WriteLine($"Certificate file not found at {certPfx}. Please ensure the file exists.");
            throw new FileNotFoundException($"Certificate file not found at {certPfx}. Please ensure the file exists.");
        }
        return certPfx;
    }
    
}