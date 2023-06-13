using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using TerritorialHQ_APIS.Services;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Pages.Authentication
{
    public class ExternalLoginModel : PageModel
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly AppUserService _appUserService;

        public ExternalLoginModel(IHttpContextAccessor contextAccessor, AppUserService appUserService)
        {
            _contextAccessor = contextAccessor;
            _appUserService = appUserService;
        }

        public IActionResult OnGet() => RedirectToPage("./Login");

        public IActionResult OnPost(string? returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Page("./ExternalLogin", pageHandler: "Callback", values: new { returnUrl });

            var propertyItems = new Dictionary<string, string?>
            {
                { ".redirect", redirectUrl },
                { "LoginProvider", "Discord" }
            };

            var properties = new AuthenticationProperties(propertyItems)
            {
                RedirectUri = redirectUrl
            };

            return new ChallengeResult("Discord", properties);
        }

        public async Task<IActionResult> OnGetCallbackAsync(string? returnUrl = null, string? remoteError = null)
        {
            returnUrl ??= Url.Content("~/");
            if (remoteError != null)
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl, Error = "Remote Error" });

            var discordId = await GetAuthenticatedDiscordId();
            if (discordId == null)
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl, Error = "Discord authentication failed" });

            var existingUser = await _appUserService.FindAsync(discordId);
            if (existingUser != null)
            {
                SignInUser(existingUser);
            }
            else
            {
                var user = new AppUser()
                {
                    UserName = discordId,
                    DiscordId = ulong.Parse(discordId),
                    Created = DateTime.UtcNow
                };

                _appUserService.Add(user);
                await _appUserService.SaveChangesAsync();

                SignInUser(user);
            }

            return LocalRedirect(returnUrl);
        }

        private void SignInUser(AppUser appUser)
        {
            
        }

        private async Task<string?> GetAuthenticatedDiscordId()
        {
            var auth = await HttpContext.AuthenticateAsync("Discord");
            return auth?.Principal?.FindFirstValue(ClaimTypes.NameIdentifier); ;
        }
    }
}
