using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TerritorialHQ_APIS.Services;

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

            var tokenClient = await _tokenClientService.GetByNameAsync(client);
            if (tokenClient == null)
                throw new Exception("Unrecognized token client.");

            var auth = await HttpContext.AuthenticateAsync("Discord");
            var username = auth?.Principal?.FindFirstValue(ClaimTypes.NameIdentifier); ;
            if (username == null)
                throw new Exception("Missing authentication information.");

            var user = await _userService.GetByUsernameAsync(username);
            if (user == null)
                throw new Exception("Missing application user");


            var issuer = ConfigurationBinder.GetValue<string>(_configuration, "JWT_ISSUER");
            var audience = issuer;
            var key = ConfigurationBinder.GetValue<string>(_configuration, "JWT_ENCRYPTION_KEY");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.UserName));
            claims.Add(new Claim(ClaimTypes.Role, "Administrator"));

            var token = new JwtSecurityToken(
                    issuer,
                    audience,
                    claims,
                    expires: DateTime.Now.AddDays(7),
                    signingCredentials: credentials
            );

            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);

            var returnUrl = Url.Page(tokenClient.ReturnUrl, new { token = jwt_token });

            return Redirect(tokenClient.ReturnUrl + "?token=" + jwt_token);
        }
    }
}
