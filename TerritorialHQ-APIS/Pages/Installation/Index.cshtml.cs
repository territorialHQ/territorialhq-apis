using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TerritorialHQ_APIS.Services;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Pages.Installation
{
    public class IndexModel : PageModel
    {
        private readonly AppUserService _userService;
        private readonly TokenClientService _tokenClientService;

        public IndexModel(AppUserService userService, TokenClientService tokenClientService)
        {
            _userService = userService;
            _tokenClientService = tokenClientService;
        }

        [BindProperty]
        [Display(Name ="Discord ID of Initial Administrator")]
        [Required]
        public string? InitialDiscordId { get; set; }

        [BindProperty]
        [Display(Name = "Initial Token Client")]
        [Required]
        public string? InitialTokenClient { get; set; }

        [BindProperty]
        [Display(Name = "Initial Token Client Return URL")]
        [DataType(DataType.Url)]
        [Required]
        public string? InitialTokenClientUrl { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            await ValidateSystemState();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await ValidateSystemState();

            ulong discordId;
            if (!ulong.TryParse(InitialDiscordId, out discordId))
                ModelState.AddModelError("InitialDiscordId", "Invalid format. Please enter a valid Discord ID containing only numbers.");
            

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = new AppUser
            {
                UserName = InitialDiscordId,
                DiscordId = discordId,
                Role = AppUserRole.Administrator
            };
            await _userService.Add(user);
            await _userService.SaveChangesAsync();

            var client = new TokenClient()
            {
                Name = InitialTokenClient,
                ReturnUrl = InitialTokenClientUrl
            };
            await _tokenClientService.Add(client);
            await _tokenClientService.SaveChangesAsync();

            return RedirectToPage("./Success");
        }

        private async Task ValidateSystemState()
        {
            var existingUsers = await _userService.GetAllAsync();
            var existingTokens = await _tokenClientService.GetAllAsync();

            if (existingUsers.Count > 0 || existingTokens.Count > 0)
                throw new Exception("APIS is already initialized.");
        }
    }
}
