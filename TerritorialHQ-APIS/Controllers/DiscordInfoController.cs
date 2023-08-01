using DSharpPlus.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TerritorialHQ_APIS.Services;
using TerritorialHQ_Library.API.Reponses;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscordInfoController : ControllerBase
    {
        private readonly IMemoryCache _cache;
        private readonly DiscordBotService _discordBotService;

        public DiscordInfoController(IMemoryCache cache, DiscordBotService discordBotService)
        {
            _cache = cache;
            _discordBotService = discordBotService;
        }

        [HttpGet("{id}")]
        public virtual async Task<DiscordInfoResponse?> Get(ulong? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            DiscordUser? user = null;
            if (_cache.TryGetValue(id.ToString()!, out DiscordUser? cachedUser))
            {
                user = cachedUser;
            }
            else
            {
                user = await _discordBotService.GetDiscordUserAsync(id.Value);
                if (user != null)
                    _cache.Set<DiscordUser>(id.ToString()!, user);   
            }

            DiscordInfoResponse response = new DiscordInfoResponse();
            if (user != null)
            {
                response.Id = user.Id;
                response.Username = user.Username;
                response.Avatar = user.AvatarHash;
                response.AvatarUrl = user.AvatarUrl;
                response.MfaEnabled = user.MfaEnabled;
            }

            return response;
        }

        [Authorize]
        [HttpGet("Validate")]
        public bool Get()
        {
            return true;
        }
    }
}
