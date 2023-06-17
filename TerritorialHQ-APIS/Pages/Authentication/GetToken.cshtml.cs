using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TerritorialHQ_APIS.Services;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Pages.Authentication
{
    [Authorize(AuthenticationSchemes = "Discord")]
    public class GetTokenModel : PageModel
    {
        private readonly TokenClientService _tokenClientService;
        private readonly IConfiguration _configuration;
        private AppUserService _userService;

        public GetTokenModel(TokenClientService tokenClientService, IConfiguration configuration, AppUserService userService)
        {
            _tokenClientService = tokenClientService;
            _configuration = configuration;
            _userService = userService;
        }

        public async Task<IActionResult> OnGet(string? client)
        {
            if (client == null)
                throw new Exception("Missing token client.");

            var tokenClient = await _tokenClientService.GetByNameAsync(client) ?? throw new Exception("Unrecognized token client.");

            AppUser user = await GetOrCreateAppUser();

            var issuer = ConfigurationBinder.GetValue<string>(_configuration, "JWT_ISSUER");
            var audience = issuer;
            var key = ConfigurationBinder.GetValue<string>(_configuration, "JWT_ENCRYPTION_KEY");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();
            claims.Add(new Claim("Id", user.Id!));
            claims.Add(new Claim("DiscordId", user.UserName!));
            if (user.Role != null)
                claims.Add(new Claim(ClaimTypes.Role, user.Role.ToString()!));

            var token = new JwtSecurityToken(
                    issuer,
                    audience,
                    claims,
                    expires: DateTime.Now.AddHours(8),
                    signingCredentials: credentials
            );

            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);

            var returnUrl = Url.Page(tokenClient.ReturnUrl, new { token = jwt_token });

            return Redirect(tokenClient.ReturnUrl + "?token=" + jwt_token);
        }

        private async Task<AppUser> GetOrCreateAppUser()
        {
            var auth = await HttpContext.AuthenticateAsync("Discord");
            var username = auth?.Principal?.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new Exception("Missing authentication information.");

            var user = await _userService.FindAsync(username);
            if (user == null)
            {
                user = new AppUser() { UserName = username, DiscordId = ulong.Parse(username) };
                
                await _userService.Add(user);
                await _userService.SaveChangesAsync();
            }

            return user;
        }
    }
}
